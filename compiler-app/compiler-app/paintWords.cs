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
        Regex number = new Regex("^[0-9]+$");
        Regex decimalNumber = new Regex("^[0-9]+[.][0-9]+$");
        Regex boolean = new Regex("^verdadero|falso|VERDADERO|FALSO$");
        Regex character = new Regex("^[a-z]|[A-Z]$");
        Regex symbol = new Regex("[()!|&<>=/*+-]");
        Regex separator = new Regex("([\\t{}():;]|/+)");

        private int errorCounter = 0;
        private int lineCounter = 0;
        private Color defaultTextColor;
        private ArrayList reservedWord;
        private ArrayList doubleSymbol;
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
            Boolean wrote = false;

            //START PAINTING
            try
            {
                string word = "";

                for (int i = 0; i < arrayChars.Length; i++)
                {
                    isJumpLine(arrayChars[i]);

                    if (i < arrayChars.Length - 1)
                    {
                        if (isShortComment(arrayChars[i], arrayChars[i + 1]) == true)
                        {
                            do//here´s esaier, i just need to expect a jumpline buuut, te comment can be in a last line, so that´s why the condition || x>length
                            {
                                paint(codeRichTextBox, arrayChars[i], Color.Red);
                                i++;
                            } while (arrayChars[i] != '\n' && i<arrayChars.Length);
                            isJumpLine(arrayChars[i]);
                        }
                        
                        if (isbeginLongComment(arrayChars[i], arrayChars[i + 1]) == true)
                        {
                            paint2chars(codeRichTextBox, arrayChars[i], arrayChars[i + 1], Color.Red);
                            i += 2;
                            while (isEndLongComment(arrayChars[i], arrayChars[i + 1]) == false && i < arrayChars.Length - 1)//if we get here, IDM what comes, is a comment until get a */
                            {
                                isJumpLine(arrayChars[i]);//counts
                                paint(codeRichTextBox, arrayChars[i], Color.Red);
                                i++;
                            }

                            if (i >= arrayChars.Length)
                            {
                                if (!isEndLongComment(arrayChars[i], arrayChars[i + 1]))
                                {
                                    this.errorController.addError(errorGridViewer, this.lineCounter, 1);//error, no */ found
                                }
                            }
                            else {
                                if (isEndLongComment(arrayChars[i], arrayChars[i + 1]))
                                {
                                    paint2chars(codeRichTextBox, arrayChars[i], arrayChars[i + 1], Color.Red);
                                    i += 2;
                                }
                            }
                        }
                        
                        if (this.doubleSymbol.Contains("" + arrayChars[i] + arrayChars[i + 1]) && wrote ==false)
                        {
                            paint2chars(codeRichTextBox, arrayChars[i], arrayChars[i], Color.Blue);
                            wrote = true;
                            i += 2;
                        }
                        isJumpLine(arrayChars[i]);
                    }
                    //MAYBE A STRING
                    if (arrayChars[i] == '"' && wrote == false)
                    {
                        do
                        {
                            if (isJumpLine(arrayChars[i]))//never found a " so is an error
                            {
                                errorController.addError(errorGridViewer, this.lineCounter, 2);
                                word += arrayChars[i];
                                wrote = true;
                                i++;
                            }
                            else
                            {
                                word += arrayChars[i];
                            }
                            i++;
                        } while (arrayChars[i] != '"' && wrote == false);

                        if (wrote == false) {//this is 'cause the only way to stop a string is with a \n giving an error or closing the "
                            word += arrayChars[i];
                            i++;
                        }
                        paintString(word, Color.LightGreen, codeRichTextBox);
                    }

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

                    if (i < arrayChars.Length) { 
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

        private Boolean isNumber(string word)
        {
            if (this.number.IsMatch(word))
                return true;

            return false;
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