using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace compiler_app
{
    public partial class Form1 : Form
    {

        private Archive archiver;

        public Form1()
        {
            this.archiver = new Archive();
            InitializeComponent();
            myConfig();
        }

        private void myConfig() {
            this.codeTabControl.Visible = false;
            this.pathTextBox.Text = null;
        }

       //  --------------------------------------------- -ARCHIVES ---------------------------------------------------- //
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (this.archiver.openArchive(this.openFileDialog1)) {
                this.codeTabControl.Visible = true;
                this.codeRichTextBox.Text = this.archiver.getTextFound();
                this.pathTextBox.Text = this.archiver.getPath();
            }
        }

        private void registrarExtensionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            extensionRegister tmp = new extensionRegister();
            tmp.registerExtension();
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        // ---------------------------- TOOLSTRIP ITEMS ---------------------------- //

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.codeTabControl.Visible == true){
                if (this.pathTextBox.Text == null || this.pathTextBox.Text == "") {
                    saveAsToolStripMenuItem_Click(sender, e);
                }else {
                    this.archiver.saveArchive(this.codeRichTextBox.Text);
                }
            }else {
                MessageBox.Show("No hay documentos abiertos");
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e) {
            if (this.archiver.saveAsArchive(this.saveFileDialog1, codeRichTextBox.Text)) {
                this.pathTextBox.Text = this.archiver.getPath();
            }
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
            saveToolStripMenuItem_Click(sender,e);
        }

        private void archiveToolStripButton_Click(object sender, EventArgs e)
        {
            openToolStripMenuItem_Click(sender,e);
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            newToolStripMenuItem_Click(sender, e);
        }

        // ---------------------------- CUSTOM ---------------------------- //

        private void fontColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.colorDialog1.ShowDialog() != System.Windows.Forms.DialogResult.Cancel)
            {
                this.codeRichTextBox.ForeColor = this.colorDialog1.Color;
            }
        }

        private void consoleColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.colorDialog1.ShowDialog() != System.Windows.Forms.DialogResult.Cancel) {
                this.codeRichTextBox.BackColor = this.colorDialog1.Color;
            }
        }
    }
}
