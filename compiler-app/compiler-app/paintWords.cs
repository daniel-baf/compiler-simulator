﻿using DocumentFormat.OpenXml.Vml.Spreadsheet;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace compiler_app
{
    class paintWords
    {
        //NUMBERS--STATES... regex
        private Regex number = new Regex("[0-9]");
        private Regex letter = new Regex("[a-z]|[A-Z]");
        private readonly Regex symbol = new Regex("[{}()!|&<>/*+:`~!#$%^,.-]");

        private int lineCounter = 0;
        private Color defaultTextColor;
        private ArrayList reservedWord;
        private ArrayList specialWords;
        private ErrorControl errorController;

        /*
         * split the text and makes tokens, then paint it
         */
        public paintWords(Color defaultTextColor)
        {
            this.defaultTextColor = defaultTextColor;
            this.reservedWord = new ArrayList();
            this.specialWords = new ArrayList();
            addWords();
        }

        /*
         * saves my reserved words, only gets my special info
         */
        private void addWords()
        {
            //some partial REGEX
            Regex number = new Regex("^[0-9]*$");
            Regex letter = new Regex("^[A-Z]*|[a-z]$");

            //reserved words
            this.reservedWord.Add("SI");
            this.reservedWord.Add("SINO");
            this.reservedWord.Add("SINO_SI");
            this.reservedWord.Add("MIENTRAS");
            this.reservedWord.Add("HACER");
            this.reservedWord.Add("DESDE");
            this.reservedWord.Add("HASTA");
            this.reservedWord.Add("INCREMENTO");
            this.reservedWord.Add("ENTONCES");

            this.specialWords.Add("entero");
            this.specialWords.Add("decimal");
            this.specialWords.Add("cadena");
            this.specialWords.Add("booleano");
            this.specialWords.Add("carácter");
            this.specialWords.Add("caracter");
        }

        /*
         * get the text and gives colors
         */
        public void paintTestint(String text, RichTextBox codeRichTextBox, DataGridView errorGridViewer)
        {
            errorController = new ErrorControl();//adds errors
            codeRichTextBox.SelectionColor = this.defaultTextColor;//the default text color
            char[] arrayChars = text.ToCharArray();//each char in the code

            Boolean actionActive = false;//we r looking comments or a sentence
            int caseActive = 0;//1 is short comment, 2 is long commetn, 3 is a string
            Boolean continueD = false;

            String actualToken = "";

            Color actualColor = this.defaultTextColor;
            for (int i = 0; i < arrayChars.Length; i++) {
                if (i < arrayChars.Length - 1)
                {
                    if (isShortComment(arrayChars[i], arrayChars[i + 1]))//only a doble / open the special case 1
                    {
                        actualToken += arrayChars[i].ToString() + arrayChars[i + 1].ToString();
                        i += 2;
                        if (i < arrayChars.Length) do
                            {
                                actualToken += arrayChars[i].ToString();
                                continueD = arrayChars[i] != '\n';
                                i++;
                            } while (continueD && i < arrayChars.Length);
                        paintString(actualToken, Color.Red, codeRichTextBox);
                        actualToken = "";//restart
                    } else if (isbeginLongComment(arrayChars[i], arrayChars[i + 1])) { // this ends anly with an * /
                        actualToken += arrayChars[i].ToString() + arrayChars[i + 1].ToString();
                        i += 2;
                        if (i < arrayChars.Length - 1) do
                            {
                                actionActive = true;
                                actualToken += arrayChars[i].ToString();
                                continueD = !isEndLongComment(arrayChars[i], arrayChars[i + 1]);
                                i++;
                                if (!continueD) {
                                    actualToken += arrayChars[i].ToString() + arrayChars[i + 1].ToString();
                                    i += 2;
                                    actionActive = false;
                                }
                            } while (continueD && i < arrayChars.Length - 1);
                        paintString(actualToken, Color.Red, codeRichTextBox);
                        actualToken = "";// i have to add the token
                    }

                    //MANAGE ERROR
                    if (actionActive) {
                        actionActive = false;
                        MessageBox.Show("agregar el error de  no cierre");
                    }
                }
                //looking a "text"
                if (arrayChars[i] == '"' && i < arrayChars.Length) {
                    do
                    {
                        actionActive = true;
                        actualToken += arrayChars[i].ToString();
                        i++;
                        continueD = i < arrayChars.Length;
                        if (continueD && arrayChars[i] == '"')
                        {
                            continueD = false;
                            actionActive = false;
                            actualToken += arrayChars[i].ToString();
                            i++;
                        }
                    } while (continueD && arrayChars[i] != '\n');
                    paintString(actualToken, Color.Gray, codeRichTextBox);
                    actualToken = "";//add a token to lexical analythics
                    // MANAGE ERROR
                    if (actionActive)
                    {
                        actionActive = false;
                        MessageBox.Show("tengo que agregar error de no cierre string");
                    }
                }

                //searching symbols
                if (i < arrayChars.Length) {
                    if (arrayChars[i] == '=' || arrayChars[i] == ';')
                    {
                        actualToken = arrayChars[i].ToString();
                        paint(codeRichTextBox, arrayChars[i], Color.Pink);
                        i++;
                        actualToken = "";//add to token list
                    }
                }

                if (this.symbol.IsMatch(arrayChars[i].ToString()) && i < arrayChars.Length) do
                    {
                        actualToken += arrayChars[i];
                        paint(codeRichTextBox, arrayChars[i], Color.DarkBlue);
                        i++;
                        continueD = i < arrayChars.Length;
                        if (continueD)
                            continueD = this.symbol.IsMatch(arrayChars[i].ToString());
                        if (!continueD) {
                            actualToken = ""; // add to token list
                        }
                    } while (continueD);
                else if (this.number.IsMatch(arrayChars[i].ToString()) && i < arrayChars.Length) {
                    int dotCounter = 0;
                    do
                    {
                        actualToken += arrayChars[i].ToString();
                        i++;
                        continueD = i < arrayChars.Length;
                        if (continueD) { 
                            continueD = this.number.IsMatch(arrayChars[i].ToString()) || arrayChars[i] == '.';
                            if (arrayChars[i] == '.') {
                                dotCounter++;
                            }
                        }
                    } while (continueD);
                    if (dotCounter > 1)
                    {
                        MessageBox.Show("tengo que mostrar error de más de 2 puntos en numeros");
                    }
                    else if (dotCounter == 0)
                    {
                        paintString(actualToken, Color.Purple, codeRichTextBox);
                        actualToken = "";//add to token list
                    }
                    else {
                        paintString(actualToken, Color.Cyan, codeRichTextBox);
                        actualToken = "";//add to token list
                    }
                } else if (this.letter.IsMatch(arrayChars[i].ToString()) && i < arrayChars.Length)//search reserved words or id
                {
                    do
                    {
                        actualToken += arrayChars[i].ToString();
                        i++;
                        continueD = i < arrayChars.Length;
                        if (continueD)
                            continueD = this.letter.IsMatch(arrayChars[i].ToString()) || this.number.IsMatch(arrayChars[i].ToString());
                    } while (continueD);

                    String aux = actualToken.ToLower();

                    if (actualToken.Length == 1)
                    {
                        paintString(actualToken, Color.Brown, codeRichTextBox);
                        actualToken = "";//add to token list
                    }
                    else if (this.reservedWord.Contains(actualToken))
                    {
                        paintString(actualToken, Color.Green, codeRichTextBox);
                        actualToken = "";//add to token list
                    }
                    else if (this.specialWords.Contains(actualToken))
                    {
                        paintString(actualToken, Color.Yellow, codeRichTextBox);
                        actualToken = "";//add to token list
                    }
                    else if (aux == "verdadero" || aux == "falso")
                    {
                        paintString(actualToken, Color.Orange, codeRichTextBox);
                        actualToken = "";//add to token list
                    }
                    else {
                        paintString(actualToken, this.defaultTextColor, codeRichTextBox);
                        actualToken = "";//add to token list
                    }
                }
                
                if(i < arrayChars.Length){
                    paint(codeRichTextBox, arrayChars[i], actualColor);
                }   
            }
        }

        private void paintString(string txt, Color color, RichTextBox codeRichTextBox)
        {
            codeRichTextBox.SelectionColor = color;
            codeRichTextBox.SelectedText = txt;
        }

        private Boolean searchReservedWord(string word)
        {
            return this.reservedWord.Contains(word);
        }

        private Boolean isJumpLine(char c)
        {
            if (c == '\n')
                this.lineCounter++;
            return c == '\n';
        }

        private void paint2chars(RichTextBox codeRichTextBox, char c1, char c2, Color color)
        {
            codeRichTextBox.SelectionColor = color;
            codeRichTextBox.SelectedText = "" + c1 + c2;
        }

        private void paint(RichTextBox codeRichTextBox, char c, Color color)
        {
            codeRichTextBox.SelectionColor = color;
            codeRichTextBox.SelectedText = "" + c;
        }

        private Boolean isbeginLongComment(char c1, char c2)
        {
            return c1 == '/' && c2 == '*';
        }

        private Boolean isEndLongComment(char c1, char c2)
        {
            return c1 == '*' && c2 == '/';
        }
        public Boolean isShortComment(char c1, char c2)
        {
            return c1 == c2 && c1 == '/';
        }
    }
}