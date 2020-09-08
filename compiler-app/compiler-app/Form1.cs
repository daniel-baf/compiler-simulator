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

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void registrarExtensionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            extensionRegister tmp = new extensionRegister();
            tmp.registerExtension();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.archiver.saveAsArchive(this.saveFileDialog1, codeRichTextBox.Text)){
                this.pathTextBox.Text = this.archiver.getPath();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
