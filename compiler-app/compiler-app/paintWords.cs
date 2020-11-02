using DocumentFormat.OpenXml.Vml.Spreadsheet;
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
        private Regex symbol = new Regex("[{}()!|&<>?/*+:`~!#$%^,.-]");

        private int lineCounter = 0;
        private int idCounter = 0;
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
            this.reservedWord.Add("PRINCIPAL");
            this.reservedWord.Add("IMPRIMIR");
            this.reservedWord.Add("LEER");
            this.reservedWord.Add("PROCESO");
            this.reservedWord.Add("SUB_PROCESO");
            this.reservedWord.Add("ESCRIBIR");
            this.reservedWord.Add("APLICACION");

            this.specialWords.Add("entero");
            this.specialWords.Add("decimal");
            this.specialWords.Add("cadena");
            this.specialWords.Add("booleano");
            this.specialWords.Add("caracter");
        }

        /*
         * get the text and gives colors
         */
        public void paintTestint(String text, RichTextBox codeRichTextBox, DataGridView errorGridViewer)
        {

            List<Token> tokens = new List<Token>();

            errorController = new ErrorControl();//adds errors
            
            codeRichTextBox.SelectionColor = this.defaultTextColor;//the default text color
            char[] arrayChars = text.ToCharArray();//each char in the code

            Boolean actionActive = false;//we r looking comments or a sentence
            Boolean continueD = false;

            String actualToken = "";

            Color actualColor = this.defaultTextColor;
            for (int i = 0; i < arrayChars.Length; i++) {
                isJumpLine(arrayChars[i]);
                //looking a "text"
                if (arrayChars[i] == '\"' && i < arrayChars.Length) {
                    do
                    {
                        isJumpLine(arrayChars[i]);
                        actionActive = true;
                        actualToken += arrayChars[i].ToString();
                        i++;

                        continueD = i < arrayChars.Length;
                        
                        if (continueD) {
                            if (arrayChars[i] == '\"')
                            {
                                continueD = false;
                                actionActive = false;
                                actualToken += arrayChars[i].ToString();
                                i++;
                                isJumpLine(arrayChars[i]);
                            }
                            else if (arrayChars[i] == '\n') {
                                continueD = false;
                                isJumpLine(arrayChars[i]);
                            }
                        }
                    } while (continueD);
                    paintString(actualToken, Color.Gray, codeRichTextBox);
                    tokens.Add(new Token(actualToken, "string", this.lineCounter, this.idCounter));
                    this.idCounter++;
                    actualToken = "";//add a token to lexical analythics
                    // MANAGE ERROR
                    if (actionActive)
                    {
                        actionActive = false;
                        errorController.addError(errorGridViewer,lineCounter,1);
                    }
                }

                //searching symbols
                if (i < arrayChars.Length) {
                    if (arrayChars[i] == '=' || arrayChars[i] == ';')
                    {
                        isJumpLine(arrayChars[i]);
                        actualToken = arrayChars[i].ToString();
                        actualColor = Color.Pink;
                        i++;
                        isJumpLine(arrayChars[i]);
                        try 
                        {
                            if (arrayChars[i] == arrayChars[i - 1] && arrayChars[i] == '=') {
                                actualColor = Color.DarkBlue;
                                actualToken += arrayChars[i];
                                i++;
                                isJumpLine(arrayChars[i]);
                            }
                        }
                        catch (Exception e)
                        {
                            actualColor = Color.Pink;
                        }
                        finally {
                            paintString(actualToken,actualColor,codeRichTextBox);
                            tokens.Add(new Token(actualToken,"asign",this.lineCounter,this.idCounter));
                            this.idCounter++;
                            actualToken = "";//add to token list
                        }
                    }
                }

                if (this.symbol.IsMatch(arrayChars[i].ToString()) && i < arrayChars.Length) do
                    {
                        isJumpLine(arrayChars[i]);
                        actualToken += arrayChars[i];
                        paint(codeRichTextBox, arrayChars[i], Color.DarkBlue);
                        i++;
                        continueD = i < arrayChars.Length;
                        if (continueD)
                            continueD = this.symbol.IsMatch(arrayChars[i].ToString());
                        if (!continueD) {
                            tokens.Add(new Token(actualToken, "symbol", this.lineCounter, this.idCounter));
                            this.idCounter++;
                            actualToken = ""; // add to token list
                        }
                    } while (continueD);
                else if (this.number.IsMatch(arrayChars[i].ToString()) && i < arrayChars.Length) {
                    int dotCounter = 0;
                    do
                    {
                        isJumpLine(arrayChars[i]);
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
                        tokens.Add(new Token(actualToken, "error", this.lineCounter, this.idCounter));
                        this.idCounter++;
                        MessageBox.Show("tengo que mostrar error de más de 2 puntos en numeros");
                    }
                    else if (dotCounter == 0)
                    {
                        paintString(actualToken, Color.Purple, codeRichTextBox);
                        tokens.Add(new Token(actualToken, "int", this.lineCounter, this.idCounter));
                        this.idCounter++;
                        actualToken = "";//add to token list
                    }
                    else {
                        paintString(actualToken, Color.Cyan, codeRichTextBox);
                        tokens.Add(new Token(actualToken, "double", this.lineCounter, this.idCounter));
                        this.idCounter++;
                        actualToken = "";//add to token list
                    }
                } else if (this.letter.IsMatch(arrayChars[i].ToString()) && i < arrayChars.Length)//search reserved words or id
                {
                    do
                    {
                        isJumpLine(arrayChars[i]);
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
                        tokens.Add(new Token(actualToken, "char", this.lineCounter, this.idCounter));
                        this.idCounter++;
                        actualToken = "";//add to token list
                    }
                    else if (this.reservedWord.Contains(actualToken))
                    {
                        paintString(actualToken, Color.Green, codeRichTextBox);
                        tokens.Add(new Token(actualToken, "reservedWord", this.lineCounter, this.idCounter));
                        this.idCounter++;
                        actualToken = "";//add to token list
                    }
                    else if (this.specialWords.Contains(actualToken))
                    {
                        paintString(actualToken, Color.Yellow, codeRichTextBox);
                        tokens.Add(new Token(actualToken, "specialWord", this.lineCounter, this.idCounter));
                        this.idCounter++;
                        actualToken = "";//add to token list
                    }
                    else if (aux == "verdadero" || aux == "falso")
                    {
                        paintString(actualToken, Color.Orange, codeRichTextBox);
                        tokens.Add(new Token(actualToken, "boolean", this.lineCounter, this.idCounter));
                        this.idCounter++;
                        actualToken = "";//add to token list
                    }
                    else {
                        paintString(actualToken, this.defaultTextColor, codeRichTextBox);
                        tokens.Add(new Token(actualToken, "id", this.lineCounter, this.idCounter));
                        this.idCounter++;
                        actualToken = "";//add to token list
                    }
                }

                if (i < arrayChars.Length - 1)
                {
                    if (isShortComment(arrayChars[i], arrayChars[i + 1]))//only a doble / open the special case 1
                    {
                        actualToken += arrayChars[i].ToString() + arrayChars[i + 1].ToString();
                        i += 2;
                        isJumpLine(arrayChars[i]);
                        if (i < arrayChars.Length) do
                            {
                                actualToken += arrayChars[i].ToString();
                                continueD = arrayChars[i] != '\n';
                                i++;
                                isJumpLine(arrayChars[i]);
                            } while (continueD && i < arrayChars.Length);
                        paintString(actualToken, Color.Red, codeRichTextBox);
                        actualToken = "";//restart
                    }
                    else if (isbeginLongComment(arrayChars[i], arrayChars[i + 1]))
                    { // this ends anly with an * /
                        actualToken += arrayChars[i].ToString() + arrayChars[i + 1].ToString();
                        i += 2;
                        isJumpLine(arrayChars[i]);
                        if (i < arrayChars.Length - 1) do
                            {
                                actionActive = true;
                                actualToken += arrayChars[i].ToString();
                                continueD = !isEndLongComment(arrayChars[i], arrayChars[i + 1]);
                                i++;
                                isJumpLine(arrayChars[i]);
                                if (!continueD)
                                {
                                    actualToken += arrayChars[i].ToString() + arrayChars[i + 1].ToString();
                                    i += 2;
                                    isJumpLine(arrayChars[i]);
                                    actionActive = false;
                                }
                            } while (continueD && i < arrayChars.Length - 1);
                        paintString(actualToken, Color.Red, codeRichTextBox);
                        actualToken = "";// i have to add the token
                    }

                    //MANAGE ERROR
                    if (actionActive)
                    {
                        actionActive = false;
                        errorController.addError(errorGridViewer, lineCounter, 0);//0 is for long comments no close
                    }
                }

                if (i < arrayChars.Length){
                    isJumpLine(arrayChars[i]);
                    paint(codeRichTextBox, arrayChars[i], actualColor);
                }   
            }
        }

        private void paintString(string txt, Color color, RichTextBox codeRichTextBox)
        {
            codeRichTextBox.SelectionColor = color;
            codeRichTextBox.SelectedText = txt;
        }

        private Boolean isJumpLine(char c)
        {
            if (c == '\n')
                this.lineCounter++;
            return c == '\n';
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