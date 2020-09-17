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

        private string[] errorToken = new string[] { "/*", "*/", "comillas", "SINO", "SINO_SI"};
        private string[] errorMessage = new string[] { "No se colocó apertura", "No se colocó cierre",
                "Has colocado comillas y no se han cerrado antes de dar un salto de linea",
                "No se completó la palabra SINO", "No se ha completado un SINO_SI"};
        private string[] IDerrors = new string[] { "AA-01", "AA-02", "AA-02", "AA-03","AA-04"};

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
