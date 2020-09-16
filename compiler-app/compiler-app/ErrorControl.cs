using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace compiler_app
{
    class ErrorControl
    {

        private string[] errorToken = new string[] { "/*", "*/" };
        private string[] errorMessage = new string[] { "Hemos encontrado un cierre de comentario largo pero no apertura",
                "Hemos encontrado una apertura de comentario largo pero no un cierre"};

        public ErrorControl(){ 
            
        }

        public void addError(DataGridView errorGridViewer, int ID, int line, int errorCode) {
            string tokenMessage = "NA";
            string message = "No reconocemos tu error, trabajaremos en ello";
            tokenMessage = this.errorToken[errorCode]; 
            message = this.errorMessage[errorCode];
            
            DataGridViewRow row = new DataGridViewRow();
            row.CreateCells(errorGridViewer);
            row.Cells[0].Value = ID;
            row.Cells[1].Value = line;
            row.Cells[2].Value = tokenMessage;
            row.Cells[3].Value = errorMessage;
            errorGridViewer.Rows.Add(row);
        }
    }
}
