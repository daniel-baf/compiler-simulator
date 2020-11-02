using System;
using System.Drawing;
using System.Windows.Forms;

namespace compiler_app
{
    public partial class IDE : Form
    {

        private Archive archiver;//open, save... documents
        private aboutMe aboutApp; //show info
        private paintWords painter;

        public IDE()
        {
            InitializeComponent();
            this.archiver = new Archive();
            this.aboutApp = new aboutMe();
            myConfig();
        }

        /*
         * the path is null
         */
        private void myConfig()
        {
            this.codeTabControl.Visible = false;
            this.pathTextBox.Text = null;
            this.codeRichTextBox.SelectionColor = Color.Red;
        }

        //  --------------------------------------------- -ARCHIVES ---------------------------------------------------- //
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.archiver.openArchive(this.openFileDialogGT))
            {
                this.codeTabControl.Visible = true;
                this.codeRichTextBox.Text = this.archiver.getTextFound();
                this.pathTextBox.Text = this.archiver.getPath();
            }
        }

        private void registrarExtensionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            extensionRegister tmp = new extensionRegister();
            if (tmp.registerExtension())
                MessageBox.Show("Extension registrada");
            else
                MessageBox.Show("Error al registrar las extensiones gt y gtE");
        }


        private void Form1_Load(object sender, EventArgs e) { }

        // ---------------------------- TOOLSTRIP ITEMS ---------------------------- //

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.codeTabControl.Visible == true)
            {
                if (this.pathTextBox.Text == null || this.pathTextBox.Text == "")
                    saveAsToolStripMenuItem_Click(sender, e);
                else
                    this.archiver.saveArchive(this.codeRichTextBox.Text);
            }
            else
            {
                MessageBox.Show("No hay documentos abiertos");
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.archiver.saveAsArchive(this.saveFileDialogGT, codeRichTextBox.Text))
                this.pathTextBox.Text = this.archiver.getPath();
        }


        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.codeTabControl.Visible == false)
                this.codeTabControl.Visible = true;
            this.codeRichTextBox.Text = "";
            this.pathTextBox.Text = "";
        }

        // ---------------------------- BUTTON ---------------------------- //

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            saveToolStripMenuItem_Click(sender, e);
        }

        private void archiveToolStripButton_Click(object sender, EventArgs e)
        {
            openToolStripMenuItem_Click(sender, e);
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            newToolStripMenuItem_Click(sender, e);
        }

        private void compileToolStripButton_Click(object sender, EventArgs e)
        {
            this.painter = new paintWords(this.codeRichTextBox.ForeColor);
            saveToolStripMenuItem_Click(sender, e);
            string tmpText = this.codeRichTextBox.Text;
            this.codeRichTextBox.Text = null;
            this.painter.paintTestint(tmpText,this.codeRichTextBox,this.errorGridViewer, this.saveFileDialog1);
        }

        private void stopToolStripButton_Click(object sender, EventArgs e)
        {}

        private void exportToolStripButton1_Click(object sender, EventArgs e)
        {
            if (this.archiver.exportArchive(this.errorGridViewer, this.saveFileDialogGTE))
            {
                MessageBox.Show("Archivo guardado");
                this.pathTextBox.Text = this.archiver.getPath();
            }
            else {
                MessageBox.Show("No se logro guardar el archivo");
            }
        }

        // ---------------------------- CUSTOM ---------------------------- //

        private void fontColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.colorDialog1.ShowDialog() != System.Windows.Forms.DialogResult.Cancel)
                this.codeRichTextBox.ForeColor = this.colorDialog1.Color;
        }

        private void consoleColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.colorDialog1.ShowDialog() != System.Windows.Forms.DialogResult.Cancel)
                this.codeRichTextBox.BackColor = this.colorDialog1.Color;
        }

        // ---------------------------- HELP ---------------------------- //
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            aboutApp.Visible = true;
        }

        private void seeHelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("TENGO QUE AGREGAR UNA INFORMACIÓN O CREAR UN TXT Y ABRIRLO");
        }

        private void tESTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string tmp = codeRichTextBox.Text;
            this.codeRichTextBox.Text = null;
            this.codeRichTextBox.Font = new Font("Arial Rounded MT", 15, FontStyle.Regular);
            this.codeRichTextBox.ForeColor = Color.White;
            this.codeRichTextBox.BackColor = Color.Black;
            this.codeRichTextBox.Text = tmp;
            
        }

        // ---------------------------- EXPORT ---------------------------- //
        private void abrirArchivoGTEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.archiver.openArchive(this.openFileDialogGTE))
            {
                this.codeRichTextBox.Visible = true;
                this.codeTabControl.Visible = true;
                this.exportationOppens.Text = this.archiver.getTextFound();
                this.gtePathLabel.Text = this.archiver.getPath();
            }
        }

        private void clearnErrorButton_Click(object sender, EventArgs e)
        {
            this.errorGridViewer = null;
        }

        private void hideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.codeTabControl.Visible = false;
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.codeTabControl.Visible = true;
        }
    }
}
