using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace compiler_app
{
    class paintWords
    {
        private int errorCounter = 0;
        private int lineCounter = 0;
        private Color defaultTextColor;

        private ErrorControl errorController;
        public paintWords(Color defaultTextColor)
        {
            this.defaultTextColor = defaultTextColor;
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

            //START PAINTIN
            for (int i = 0; i < arrayChars.Length; i++)
            {
                if (i < arrayChars.Length - 1)
                {
                    if (isbeginLongComment(arrayChars[i], arrayChars[i + 1]))
                    {
                        do
                        {
                            isJumpLine(arrayChars[i]);//counts
                            paint(codeRichTextBox, arrayChars[i], Color.Red);
                            i++;
                            if (i < arrayChars.Length - 1 && isEndLongComment(arrayChars[i], arrayChars[i + 1], errorGridViewer))
                            {
                                continueD = false;
                            }
                        } while (continueD && i < arrayChars.Length);
                        if (continueD == false)
                        {
                            string tmp = arrayChars[i] + arrayChars[i + 1] + "";
                            paint2chars(codeRichTextBox, tmp, Color.Red);
                            i += 2;
                        }
                        else if(i >= arrayChars.Length){
                            errorController.addError(errorGridViewer, this.errorCounter, this.lineCounter, 1);
                            this.errorCounter++;
                            continueD = true;
                        }
                    }
                    else if (isShortComment(arrayChars[i], arrayChars[i + 1]))
                    {
                        do
                        {
                            paint(codeRichTextBox, arrayChars[i], Color.Red);
                            i++;
                            if (arrayChars[i] == '\n')
                                continueD = false;
                        } while (continueD && i < arrayChars.Length);
                    }

                    if (i < arrayChars.Length)
                        paint(codeRichTextBox, arrayChars[i], this.defaultTextColor);
                }
            }
        }

        private void isJumpLine(char c) {
            if (c == '\n')
                this.lineCounter++;
        }

        private void paint2chars(RichTextBox codeRichTextBox, string c, Color color)
        {
            codeRichTextBox.SelectionColor = color;
            codeRichTextBox.SelectedText = c;
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

        private Boolean isEndLongComment(char c1, char c2, DataGridView errorGridViewer)
        {
            if (c1 == '*' && c2 == '/')
                return true;
            else return false;
        }

        public Boolean isShortComment(char c1, char c2)
        {
            return c1 == c2 && c1 == '/';
        }
    }
}