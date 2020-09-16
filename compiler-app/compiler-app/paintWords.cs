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
        private int errorCounter = 0;
        private int lineCounter = 0;
        private Color defaultTextColor;
        private ArrayList reservedWord;
        private ArrayList doubleSymbol;
        Regex symbol = new Regex("[()!|&<>=/*+-]");
        private ErrorControl errorController;

        public paintWords(Color defaultTextColor)
        {
            this.defaultTextColor = defaultTextColor;
            reservedWord = new ArrayList();
            doubleSymbol = new ArrayList();
            addWords();
        }

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

            this.reservedWord.Add("entero");
            this.reservedWord.Add("decimal");
            this.reservedWord.Add("cadena");
            this.reservedWord.Add("booleano");
            this.reservedWord.Add("carácter");
            this.reservedWord.Add("caracter");
            //symbols
            this.doubleSymbol.Add("++");
            this.doubleSymbol.Add("--");
            this.doubleSymbol.Add(">=");
            this.doubleSymbol.Add("<=");
            this.doubleSymbol.Add("==");
            this.doubleSymbol.Add("!=");
            this.doubleSymbol.Add("||");
            this.doubleSymbol.Add("&&");
        }

        public void paintBox(String text, RichTextBox codeRichTextBox, DataGridView errorGridViewer)
        {
            errorController = new ErrorControl();

            //DEFAULT COLOR
            codeRichTextBox.SelectionColor = this.defaultTextColor;

            //CHARS TO ANALICE
            char[] arrayChars = text.ToCharArray();

            //COMMENTS CONTROLLER
            Boolean continueD = true;
            Boolean wrote = false;

            //START PAINTING
            try
            {
                string word = "";
                for (int i = 0; i < arrayChars.Length; i++)
                {
                    paint(codeRichTextBox, arrayChars[i], this.defaultTextColor);
                }

                codeRichTextBox.SelectedText = "\n-------------------\n";

                for (int i = 0; i < arrayChars.Length; i++)
                {
                    isJumpLine(arrayChars[i]);//if we have a \n counts it

                    if (i < arrayChars.Length - 1)
                    {
                        if (isShortComment(arrayChars[i], arrayChars[i + 1]) == true && wrote == false)
                        {
                            do//here´s esaier, i just need to expect a jumpline buuut, te comment can be in a last line, so that´s why the condition || x>length
                            {
                                if (isJumpLine(arrayChars[i]) || i >= arrayChars.Length)
                                {//when the jumplines is make stop painting
                                    continueD = false;
                                }
                                else
                                {
                                    paint(codeRichTextBox, arrayChars[i], Color.Red);
                                    i++;
                                }
                            } while (continueD == true);
                            wrote = true;
                        }

                        if (isbeginLongComment(arrayChars[i], arrayChars[i + 1]) == true && wrote == false)
                        {
                            do//if we get here, IDM what comes, is a comment until get a */
                            {
                                if (i >= arrayChars.Length - 1 || isEndLongComment(arrayChars[i], arrayChars[i + 1]))
                                {
                                    continueD = false;
                                }
                                else
                                {
                                    isJumpLine(arrayChars[i]);//counts
                                    paint(codeRichTextBox, arrayChars[i], Color.Red);
                                    i++;
                                }
                            } while (continueD == true);

                            if (i < arrayChars.Length)//here, we found a */ so ther is no problem
                            {
                                paint2chars(codeRichTextBox, arrayChars[i], arrayChars[i + 1], Color.Red);
                                i += 2;
                            }
                            else
                            {//ended all the program and found no */ so gets a error
                                errorController.addError(errorGridViewer, this.lineCounter, 1);
                                this.errorCounter++;
                                continueD = true;
                            }
                            wrote = true;
                        }

                        if (this.doubleSymbol.Contains("" + arrayChars[i] + arrayChars[i+1]))
                        {
                            paint2chars(codeRichTextBox, arrayChars[i], arrayChars[i], Color.Blue);
                            wrote = true;
                            i+=2;
                        }
                    }

                    if (arrayChars[i] == ' ')
                    {//this part is ´cause we r reading step by step, and maybe, we get an e or space after a comment or sign
                        paint(codeRichTextBox, arrayChars[i], this.defaultTextColor);
                        i++;
                    }

                    if (arrayChars[i] == '"' && wrote == false)
                    {
                        do
                        {
                            if (isJumpLine(arrayChars[i]))
                            {
                                errorController.addError(errorGridViewer, this.lineCounter, 2);
                                paintString(word, Color.LightGreen, codeRichTextBox);
                                word = "\n";
                                wrote = true;
                            }
                            else
                            {
                                word += arrayChars[i];
                            }
                            i++;
                        } while (arrayChars[i] != '"' && wrote == false);
                        
                        if (wrote == false) {
                            word += arrayChars[i];
                            i++;
                        }
                        paintString(word, Color.LightGreen, codeRichTextBox);
                        wrote = true;
                        
                    }//if isnt a comment

                    if (wrote == false)//LOOKING ESPECIFY WORDS
                    {
                        if (symbol.IsMatch("" + arrayChars[i]))
                        {
                            paint(codeRichTextBox, arrayChars[i], Color.Blue);
                            wrote = true;
                            i++;
                        }
                        else if (arrayChars[i] == '=' || arrayChars[i] == ';')//this are special words, onlty this two are pink
                        {
                            paint(codeRichTextBox, arrayChars[i], Color.DeepPink);
                            wrote = true;
                            i++;
                        }
                        else {//to make it easier, i think look for a reserved word is good idead
                            
                        }

                        /*do
                        {
                            word += arrayChars[i];
                            if (searchReservedWord(word) == true)//lookiing for SI/SINO/...
                            {
                                paintString(word, Color.Green, codeRichTextBox);
                                wrote = true;
                                word = "";
                            }
                            i++;
                        } while (arrayChars[i] != '\n');*/
                    }

                    if (i < arrayChars.Length)
                    {
                        paint(codeRichTextBox, arrayChars[i], this.defaultTextColor);
                    }
                    wrote = false;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
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

        private void registerError()
        {
            this.errorCounter++;
        }

        private Boolean isJumpLine(char c)
        {
            if (c == '\n')
            {
                this.lineCounter++;
                return true;
            }
            return false;
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
            if (c1 == '/' && c2 == '*')
                return true;
            else
                return false;
        }

        private Boolean isEndLongComment(char c1, char c2)
        {
            if (c1 == '*' && c2 == '/')
                return true;
            else return false;
        }

        public Boolean isShortComment(char c1, char c2)
        {
            Boolean match = false;
            if (c1 == c2)
            {
                if (c1 == '/')
                    match = true;
            }
            return match;
        }
    }
}