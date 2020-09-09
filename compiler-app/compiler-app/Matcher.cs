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
        Regex reservedWord = new Regex("^(SI|SINO|SINO_SI|MIENTRAS|HACER|DESDE|HASTA|INCREMENTO|si)$");
        Regex aritmethicOperator = new Regex("^(+|,|-|,|*|,|/|,|++|--)$");
        Regex relationalOperator = new Regex("^(<|>|<=|>=|==|!=)$");
        Regex logicalOperator = new Regex("^(&&|!|(||))$");
        // ****************************************** END SPECIAL WORDS ****************************************** //

        // ****************************************** START REGEX ****************************************** //
        Regex separator = new Regex("([ \\t{}():;])");
        // ------------------------------------------------------------------------------------------------- //
        Regex integer = new Regex("^(ENTERO|entero)$");
        Regex doubleRgx = new Regex("^(DECIMAL|decimal)$");
        Regex stringRgx = new Regex("^(CADENA|cadena)$");
        Regex booleanRgx = new Regex("^(BOOLEANO|booleano)$");
        Regex charRgx = new Regex("^(CARACTER|caracter|carácter|CARÁCTER))$");
        // ------------------------------------------------------------------------------------------------- //
        Regex doubleN = new Regex("^$");
        Regex doubleN = new Regex("^$");
        // ****************************************** END REGEX ****************************************** //

        public Matcher()
        {
        }

        public void addFilter(RichTextBox codeRichTextBox, string text) {
            Regex jumpLine = new Regex("\\n");
            String[] lines = jumpLine.Split(text);
            foreach (string tmp in lines) {
                ParseLine(tmp,codeRichTextBox);
            }
        }

        void ParseLine(string line, RichTextBox codeRichTextBox)
        {
            





            String[] tokens = separator.Split(line);
            foreach (string token in tokens)
            {
                // Set the tokens default color and font.  
                codeRichTextBox.SelectionColor = codeRichTextBox.ForeColor;
                // Check whether the token is a keyword.
                for (int i = 0; i < reservedWord.Length; i++)
                {
                    if (reservedWord.IsMatch(token))
                    {
                        // Apply alternative color and font to highlight keyword.  
                        codeRichTextBox.SelectionColor = Color.Green;
                        codeRichTextBox.SelectionFont = new Font("Courier New", 10, FontStyle.Bold);
                        break;
                    }                }
                codeRichTextBox.SelectedText = token;
            }
            codeRichTextBox.SelectedText = "\n";
        }
    }
}
