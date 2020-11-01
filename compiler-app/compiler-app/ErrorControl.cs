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

        private string[] errorToken = new string[] {"/*","\""};
        private string[] errorMessage = new string[] {"No se ha cerrado el comentario largo", 
            "No se ha cerrado la asignación de la cadena"};
        private string[] IDerrors = new string[] {"E-001", "E'002"};

        public ErrorControl(){ 
            
        }

        public void addError(DataGridView errorGridViewer, int line, int errorCode) {
            string ID = this.IDerrors[errorCode];
            string tokenMessage = "NA";
            string message = "No reconocemos tu error, trabajaremos en ello";
            tokenMessage = this.errorToken[errorCode]; 
            message = this.errorMessage[errorCode];
            
            DataGridViewRow row = new DataGridViewRow();
            row.CreateCells(errorGridViewer);
            row.Cells[0].Value = ID;
            row.Cells[1].Value = line;
            row.Cells[2].Value = tokenMessage;
            row.Cells[3].Value = message;
            errorGridViewer.Rows.Add(row);
        }
    }
}
