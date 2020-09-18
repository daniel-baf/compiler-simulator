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
        private Regex number = new Regex("^[0-9]+$");
        private Regex boolean = new Regex("^verdadero|falso|VERDADERO|FALSO$");
        private Regex letter = new Regex("[a-z]|[A-Z]");
        private Regex symbol = new Regex("[{}()!|&<>/*+-]");

        private int lineCounter = 0;
        private Color defaultTextColor;
        private ArrayList reservedWord;
        private ArrayList specialWords;
        private ArrayList doubleSymbol;
        private ErrorControl errorController;

        public paintWords(Color defaultTextColor)
        {
            this.defaultTextColor = defaultTextColor;
            this.reservedWord = new ArrayList();
            this.doubleSymbol = new ArrayList();
            this.specialWords = new ArrayList();
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

            this.specialWords.Add("entero");
            this.specialWords.Add("decimal");
            this.specialWords.Add("cadena");
            this.specialWords.Add("booleano");
            this.specialWords.Add("carácter");
            this.specialWords.Add("caracter");
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

        public void paintTestint(String text, RichTextBox codeRichTextBox, DataGridView errorGridViewer) {
            errorController = new ErrorControl();
            codeRichTextBox.SelectionColor = this.defaultTextColor;
            char[] arrayChars = text.ToCharArray();

            Boolean actionActive = false;
            int caseActive = 0;//1 is short comment, 2 is long commetn, 3 is a string

            try
            {
                Color actualColor = this.defaultTextColor;
                //special things
                for (int i = 0; i < arrayChars.Length; i++)
                {

                    //looking 2 by two
                    if (i < arrayChars.Length - 1)
                    {//open the comment
                        if (isShortComment(arrayChars[i], arrayChars[i + 1]) == true && actionActive == false)//only a doble / open the special case 1
                        {
                            paint2chars(codeRichTextBox, arrayChars[i], arrayChars[i + 1],Color.Red);
                            actualColor = Color.Red;
                            caseActive = 1;
                            actionActive = true;
                            i += 2;
                        }
                        else if (isbeginLongComment(arrayChars[i], arrayChars[i + 1]) == true && actionActive == false)// i want a /* to open case 2
                        {
                            paint2chars(codeRichTextBox, arrayChars[i], arrayChars[i + 1], Color.Red);
                            actualColor = Color.Red;
                            caseActive = 2;
                            actionActive = true;
                            i += 2;
                        } else if (this.doubleSymbol.Contains("" + arrayChars[i] + arrayChars[i + 1]) && actionActive == false)//not a special case, but make it easeir 4 me
                        {
                            paint2chars(codeRichTextBox, arrayChars[i], arrayChars[i + 1], Color.Blue);
                            i += 2;
                        }

                    }
                    //looking a "
                    if (arrayChars[i] == '"' && actionActive == false) {
                        paint(codeRichTextBox, arrayChars[i], Color.Gray);
                        i++;
                        actualColor = Color.Gray;
                        caseActive = 3;
                        actionActive = true;
                    }

                    if (actionActive == false) {
                        actualColor = this.defaultTextColor;

                        //search words
                        if (i > 0 && i < arrayChars.Length - 1) {
                            if (!letter.IsMatch(arrayChars[i - 1] + "") && !letter.IsMatch(arrayChars[i + 1] + "")) {
                                actualColor = Color.Brown;
                            }
                        }

                        //search a number
                        string tmp = "";
                        if (this.number.IsMatch(arrayChars[i] + "")) {
                            while (this.number.IsMatch(arrayChars[i] + "")) {
                                tmp += arrayChars[i];
                                i++;
                            }
                            if (i < arrayChars.Length) {
                                if (arrayChars[i] != '.') {
                                    paintString(tmp,Color.Purple,codeRichTextBox);
                                }
                            }
                        }

                        //SEARCH SPECIAL WORDS
                        Boolean wordFound = false;
                        if (letter.IsMatch(arrayChars[i] + "") && i <arrayChars.Length-1) {
                            tmp = "";
                            while (letter.IsMatch(arrayChars[i] + "")) {
                                tmp += arrayChars[i];
                                if (this.boolean.IsMatch(tmp))
                                {
                                    paintString(tmp, Color.Orange, codeRichTextBox);
                                    wordFound = true;
                                }
                                else if (specialWords.Contains(tmp)) {
                                    paintString(tmp, Color.Coral, codeRichTextBox);
                                    wordFound = true;
                                }

                                if (searchReservedWord(tmp))
                                {
                                    Boolean paintNow = false;
                                    int aux = this.reservedWord.IndexOf(tmp);
                                    if (aux == 0)
                                    {
                                        if (arrayChars[i + 1] != 'N') {
                                            paintNow = true;
                                        }
                                    }
                                    else if (aux == 1) {
                                        if (arrayChars[i + 1] != '_')
                                        {
                                            paintNow = true;
                                        }
                                    }
                                    else
                                    {
                                        paintNow = true;
                                    }

                                    if(paintNow == true)
                                        paintString(tmp, Color.Green, codeRichTextBox);
                                    wordFound = true;
                                }
                                i++;
                            }
                            if (wordFound == false) {
                                i -=tmp.Length;
                            }

                        }

                        //search a symbol
                        if (this.symbol.IsMatch(arrayChars[i] + ""))
                            actualColor = Color.Blue;
                        else if (arrayChars[i] == '=' || arrayChars[i] == ';')
                            actualColor = Color.Pink;
                    }

                    isJumpLine(arrayChars[i]);
                    paint(codeRichTextBox,arrayChars[i],actualColor);

                    //CLOSING ACTIVE CASES
                    if (actionActive == true) {
                        if (caseActive == 1)
                        {
                            if (arrayChars[i] == '\n') {
                                actionActive = false;
                                caseActive = 0;
                                actualColor = this.defaultTextColor;
                            }
                        }
                        else if (caseActive == 2 && i <arrayChars.Length-1)
                        {
                            if (isEndLongComment(arrayChars[i], arrayChars[i + 1])){
                                paint(codeRichTextBox, arrayChars[i+1], actualColor);
                                i++;
                                actionActive = false;
                                caseActive = 0;
                                actualColor = this.defaultTextColor;
                            }
                            int k = i+1;
                            if (k >= arrayChars.Length-1 && actionActive == true)
                                this.errorController.addError(errorGridViewer, this.lineCounter, 0);
                        }
                        else if (caseActive == 3) {
                            if (arrayChars[i] == '"')
                            {
                                actionActive = false;
                                caseActive = 0;
                                actualColor = this.defaultTextColor;
                            }
                            else if (arrayChars[i] == '\n' &&actionActive == true) {
                                this.errorController.addError(errorGridViewer, this.lineCounter, 2);
                                actionActive = false;
                                caseActive = 0;
                                actualColor = this.defaultTextColor;
                            }
                        }

                        if (i >= arrayChars.Length && caseActive == 2)
                        {
                            this.errorController.addError(errorGridViewer, this.lineCounter, 1);
                        }
                    }
                }
            }
            catch (Exception e) {
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