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
        private aboutMe aboutApp = new aboutMe();
        private Matcher matcher = new Matcher();

        public Form1()
        {
            InitializeComponent();
            this.archiver = new Archive();
            myConfig();
        }

        private void myConfig() {
            this.codeTabControl.Visible = false;
            this.pathTextBox.Text = null;
            this.codeRichTextBox.ScrollBars = RichTextBoxScrollBars.ForcedBoth;
            this.codeRichTextBox.Dock = DockStyle.Fill;
            this.codeRichTextBox.SelectionColor = Color.Red;
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

        private void compileToolStripButton_Click(object sender, EventArgs e)
        {
            saveToolStripMenuItem_Click(sender, e);
            string tmpText = this.codeRichTextBox.Text;
            this.codeRichTextBox.Text = "";
            this.matcher.addFilter(this.codeRichTextBox, tmpText);
        }

        private void stopToolStripButton_Click(object sender, EventArgs e)
        {

        }

        private void exportToolStripButton1_Click(object sender, EventArgs e)
        {

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

        // ---------------------------- HELP ---------------------------- //
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            aboutApp.Visible = true;
        }

        private void seeHelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("TENGO QUE AGREGAR UNA INFORMACIÓN O CREAR UN TXT Y ABRIRLO");
        }
    }
}
