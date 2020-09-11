using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using DocumentFormat.OpenXml.EMMA;
using System.Windows.Forms;
using System.Drawing;

namespace compiler_app
{
    class Matcher
    {
        // ****************************************** START SPECIAL WORDS ****************************************** //
        private String[] reservedWord = new String[] { "SI", "SINO", "SINO_SI", "MIENTRAS", "HACER", "DESDE", "HASTA", "INCREMENTO", "ENTONCES" };
        private String[] relationalOpertaor = new string[] { "<", ">", "<=", ">=", "==", "!=" };
        private String[] aritmethicOperator = new String[] { "+", "-", "*", "/", "++", "--" };
        private String[] logicalOperator = new String[] { "&&", "!", "||" };
        // ****************************************** END SPECIAL WORDS ****************************************** //

        // ****************************************** START REGEX ****************************************** //
        Regex separator = new Regex("([\\t{}():;])");
        // ------------------------------------------------------------------------------------------------- //
        // ****************************************** END REGEX ****************************************** //

        public Matcher()
        {
        }

        public void addFilter(RichTextBox codeRichTextBox, string text)
        {
            string[] lines = text.Split('\n');
            Color fontColor = codeRichTextBox.ForeColor;
            Boolean isComment = false;


            int n = 0;
            foreach (string tmp in lines)
            {
                //verify a commnent
                string[] lookingComment = tmp.Split(' ');
                for (int i = 0; i < lookingComment.Length - 1; i++) {
                    if (lookingComment[i] == lookingComment[i + 1]) {
                        isComment = true;
                    }
                }

                codeRichTextBox.SelectionColor = fontColor;
                codeRichTextBox.SelectionFont = new Font("Arial Rounded MT", 15, FontStyle.Regular);

                if (!isComment)
                {
                    ParseLine(tmp, codeRichTextBox);
                }
                else {
                    codeRichTextBox.SelectionColor = Color.Red;
                    codeRichTextBox.SelectedText = tmp + " ";
                }

                if (n < lines.Length - 1)
                {
                    codeRichTextBox.SelectedText = "\n";
                    n++;
                }
            }
        }

        private void ParseLine(string line, RichTextBox codeRichTextBox)
        {
            Color fontColor = codeRichTextBox.ForeColor;
            string[] tokens = separator.Split(line);
            foreach (string token in tokens)
            {
                splitParseLine(token, codeRichTextBox);
            }
        }

        private void splitParseLine(string subToken, RichTextBox codeRichTextBox)
        {
            Color defaultFontColor = codeRichTextBox.ForeColor;
            string[] auxSplitWord = subToken.Split(' ');

            Boolean done = false;

            foreach (var word in auxSplitWord)
            {
                codeRichTextBox.SelectionFont = new Font("Arial Rounded MT", 15, FontStyle.Regular);
                codeRichTextBox.SelectionColor = defaultFontColor;

                if (word != "" && word != null)
                {

                    if (word == "entero")
                    {
                        codeRichTextBox.SelectionColor = Color.Purple;
                        done = true;
                    }
                    else if (word == "decimal")
                    {
                        codeRichTextBox.SelectionColor = Color.Cyan;
                        done = true;
                    }
                    else if (word == "cadena")
                    {
                        codeRichTextBox.SelectionColor = Color.Gray;
                        done = true;
                    }
                    else if (word == "booleano")
                    {
                        codeRichTextBox.SelectionColor = Color.Orange;
                        done = true;
                    }
                    else if (word == "caracter")
                    {
                        codeRichTextBox.SelectionColor = Color.Brown;
                        done = true;
                    }
                    else if (word == "(" || word == ")")
                    {
                        codeRichTextBox.SelectionColor = Color.Blue;
                        done = true;
                    }
                    else if (word == "=" || word == ";")
                    {
                        codeRichTextBox.SelectionColor = Color.Black;
                        done = false;
                    }

                    if (done == false)
                    {
                        for (int i = 0; i < reservedWord.Length; i++)
                        {
                            if (reservedWord[i] == word)
                            {
                                // Apply alternative color and font to highlight keyword.  
                                codeRichTextBox.SelectionColor = Color.Green;
                                codeRichTextBox.SelectionFont = new Font("Arial Rounded MT", 15, FontStyle.Bold);
                                done = true;
                                break;
                            }
                        }

                        if (done == false)
                        {
                            for (int i = 0; i < relationalOpertaor.Length; i++)
                            {
                                if (relationalOpertaor[i] == word)
                                {
                                    // Apply alternative color and font to highlight keyword.  
                                    codeRichTextBox.SelectionColor = Color.Blue;
                                    done = true;
                                    break;
                                }
                            }
                        }

                        if (done == false)
                        {
                            for (int i = 0; i < aritmethicOperator.Length; i++)
                            {
                                if (aritmethicOperator[i] == word)
                                {
                                    // Apply alternative color and font to highlight keyword.  
                                    codeRichTextBox.SelectionColor = Color.Blue;
                                    done = true;
                                    break;
                                }
                            }
                        }

                        if (done == false)
                        {
                            for (int i = 0; i < logicalOperator.Length; i++)
                            {
                                if (logicalOperator[i] == word)
                                {
                                    // Apply alternative color and font to highlight keyword.  
                                    codeRichTextBox.SelectionColor = Color.Blue;
                                    done = true;
                                    break;
                                }
                            }
                        }
                    }
                    codeRichTextBox.SelectedText = word + " ";
                    done = false;
                }
            }
        }
    }
}
