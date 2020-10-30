namespace compiler_app
{
    partial class IDE
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IDE));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirArchivoGTEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.herramientasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fontColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consoleColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.ayudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.seeHelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registrarExtensionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ventanaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStrip = new System.Windows.Forms.ToolStrip();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.openToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.archiveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.compileToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.stopToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exportToolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.clearnErrorButton = new System.Windows.Forms.ToolStripButton();
            this.codeTabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.codeRichTextBox = new System.Windows.Forms.RichTextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.exportationOppens = new System.Windows.Forms.RichTextBox();
            this.errorTextBox = new System.Windows.Forms.TextBox();
            this.errorGridViewer = new System.Windows.Forms.DataGridView();
            this.ID_error = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.line_error = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.text_error = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.message = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saveFileDialogGT = new System.Windows.Forms.SaveFileDialog();
            this.pathTextBox = new System.Windows.Forms.TextBox();
            this.openFileDialogGT = new System.Windows.Forms.OpenFileDialog();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.openFileDialogGTE = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialogGTE = new System.Windows.Forms.SaveFileDialog();
            this.gtePathLabel = new System.Windows.Forms.Label();
            this.autocompleteMenu1 = new AutocompleteMenuNS.AutocompleteMenu();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.menuStrip1.SuspendLayout();
            this.toolsToolStrip.SuspendLayout();
            this.codeTabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorGridViewer)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.herramientasToolStripMenuItem,
            this.ayudaToolStripMenuItem,
            this.registrarExtensionToolStripMenuItem,
            this.ventanaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1069, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.newToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.abrirArchivoGTEToolStripMenuItem});
            this.archivoToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.archivoToolStripMenuItem.Image = global::compiler_app.Properties.Resources.folder;
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.openToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.openToolStripMenuItem.Image = global::compiler_app.Properties.Resources.open_file;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.openToolStripMenuItem.Text = "Abrir";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.newToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.newToolStripMenuItem.Image = global::compiler_app.Properties.Resources.new_doc;
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.newToolStripMenuItem.Text = "Nuevo";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.saveToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.saveToolStripMenuItem.Image = global::compiler_app.Properties.Resources.floppy_disk;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.saveToolStripMenuItem.Text = "Guardar";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.saveAsToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.saveAsToolStripMenuItem.Image = global::compiler_app.Properties.Resources.floppy_disk;
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.saveAsToolStripMenuItem.Text = "Guardar Como";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // abrirArchivoGTEToolStripMenuItem
            // 
            this.abrirArchivoGTEToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.abrirArchivoGTEToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.abrirArchivoGTEToolStripMenuItem.Image = global::compiler_app.Properties.Resources.add_tab;
            this.abrirArchivoGTEToolStripMenuItem.Name = "abrirArchivoGTEToolStripMenuItem";
            this.abrirArchivoGTEToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.abrirArchivoGTEToolStripMenuItem.Text = "Abrir Archivo GTE";
            this.abrirArchivoGTEToolStripMenuItem.Click += new System.EventHandler(this.abrirArchivoGTEToolStripMenuItem_Click);
            // 
            // herramientasToolStripMenuItem
            // 
            this.herramientasToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.herramientasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.customToolStripMenuItem,
            this.testToolStrip});
            this.herramientasToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.herramientasToolStripMenuItem.Image = global::compiler_app.Properties.Resources.tools;
            this.herramientasToolStripMenuItem.Name = "herramientasToolStripMenuItem";
            this.herramientasToolStripMenuItem.Size = new System.Drawing.Size(106, 20);
            this.herramientasToolStripMenuItem.Text = "Herramientas";
            // 
            // customToolStripMenuItem
            // 
            this.customToolStripMenuItem.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.customToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fontColorToolStripMenuItem,
            this.consoleColorToolStripMenuItem});
            this.customToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.customToolStripMenuItem.Image = global::compiler_app.Properties.Resources.pantone_guide;
            this.customToolStripMenuItem.Name = "customToolStripMenuItem";
            this.customToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.customToolStripMenuItem.Text = "Personalizar";
            // 
            // fontColorToolStripMenuItem
            // 
            this.fontColorToolStripMenuItem.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.fontColorToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.fontColorToolStripMenuItem.Image = global::compiler_app.Properties.Resources.color;
            this.fontColorToolStripMenuItem.Name = "fontColorToolStripMenuItem";
            this.fontColorToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.fontColorToolStripMenuItem.Text = "Color Fuente";
            this.fontColorToolStripMenuItem.Click += new System.EventHandler(this.fontColorToolStripMenuItem_Click);
            // 
            // consoleColorToolStripMenuItem
            // 
            this.consoleColorToolStripMenuItem.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.consoleColorToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.consoleColorToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("consoleColorToolStripMenuItem.Image")));
            this.consoleColorToolStripMenuItem.Name = "consoleColorToolStripMenuItem";
            this.consoleColorToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.consoleColorToolStripMenuItem.Text = "Color consola";
            this.consoleColorToolStripMenuItem.Click += new System.EventHandler(this.consoleColorToolStripMenuItem_Click);
            // 
            // testToolStrip
            // 
            this.testToolStrip.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.testToolStrip.ForeColor = System.Drawing.Color.White;
            this.testToolStrip.Image = global::compiler_app.Properties.Resources._49;
            this.testToolStrip.Name = "testToolStrip";
            this.testToolStrip.Size = new System.Drawing.Size(137, 22);
            this.testToolStrip.Text = "TEST";
            this.testToolStrip.Click += new System.EventHandler(this.tESTToolStripMenuItem_Click);
            // 
            // ayudaToolStripMenuItem
            // 
            this.ayudaToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ayudaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.seeHelpToolStripMenuItem});
            this.ayudaToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.ayudaToolStripMenuItem.Image = global::compiler_app.Properties.Resources.help;
            this.ayudaToolStripMenuItem.Name = "ayudaToolStripMenuItem";
            this.ayudaToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.ayudaToolStripMenuItem.Text = "Ayuda";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.aboutToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.aboutToolStripMenuItem.Image = global::compiler_app.Properties.Resources.user;
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.aboutToolStripMenuItem.Text = "Acerca De";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // seeHelpToolStripMenuItem
            // 
            this.seeHelpToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.seeHelpToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.seeHelpToolStripMenuItem.Image = global::compiler_app.Properties.Resources.help;
            this.seeHelpToolStripMenuItem.Name = "seeHelpToolStripMenuItem";
            this.seeHelpToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.seeHelpToolStripMenuItem.Text = "Ver Ayuda";
            this.seeHelpToolStripMenuItem.Click += new System.EventHandler(this.seeHelpToolStripMenuItem_Click);
            // 
            // registrarExtensionToolStripMenuItem
            // 
            this.registrarExtensionToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.registrarExtensionToolStripMenuItem.Image = global::compiler_app.Properties.Resources.info;
            this.registrarExtensionToolStripMenuItem.Name = "registrarExtensionToolStripMenuItem";
            this.registrarExtensionToolStripMenuItem.Size = new System.Drawing.Size(135, 20);
            this.registrarExtensionToolStripMenuItem.Text = "Registrar Extension";
            this.registrarExtensionToolStripMenuItem.Click += new System.EventHandler(this.registrarExtensionToolStripMenuItem_Click);
            // 
            // ventanaToolStripMenuItem
            // 
            this.ventanaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hideToolStripMenuItem,
            this.showToolStripMenuItem});
            this.ventanaToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.ventanaToolStripMenuItem.Image = global::compiler_app.Properties.Resources.Computer_On;
            this.ventanaToolStripMenuItem.Name = "ventanaToolStripMenuItem";
            this.ventanaToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.ventanaToolStripMenuItem.Text = "Ventana";
            // 
            // hideToolStripMenuItem
            // 
            this.hideToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            this.hideToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.hideToolStripMenuItem.Image = global::compiler_app.Properties.Resources.Graphite_Desktop;
            this.hideToolStripMenuItem.Name = "hideToolStripMenuItem";
            this.hideToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.hideToolStripMenuItem.Text = "Ocultar";
            this.hideToolStripMenuItem.Click += new System.EventHandler(this.hideToolStripMenuItem_Click);
            // 
            // showToolStripMenuItem
            // 
            this.showToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            this.showToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.showToolStripMenuItem.Image = global::compiler_app.Properties.Resources.radar;
            this.showToolStripMenuItem.Name = "showToolStripMenuItem";
            this.showToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.showToolStripMenuItem.Text = "Mostrar";
            this.showToolStripMenuItem.Click += new System.EventHandler(this.showToolStripMenuItem_Click);
            // 
            // toolsToolStrip
            // 
            this.toolsToolStrip.BackColor = System.Drawing.SystemColors.Desktop;
            this.toolsToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripButton,
            this.openToolStripButton,
            this.archiveToolStripButton,
            this.toolStripSeparator1,
            this.compileToolStripButton,
            this.stopToolStripButton,
            this.toolStripSeparator2,
            this.exportToolStripButton1,
            this.clearnErrorButton});
            this.toolsToolStrip.Location = new System.Drawing.Point(0, 24);
            this.toolsToolStrip.Margin = new System.Windows.Forms.Padding(2);
            this.toolsToolStrip.Name = "toolsToolStrip";
            this.toolsToolStrip.Size = new System.Drawing.Size(1069, 25);
            this.toolsToolStrip.TabIndex = 1;
            this.toolsToolStrip.Text = "TOOLS";
            // 
            // saveToolStripButton
            // 
            this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveToolStripButton.Image = global::compiler_app.Properties.Resources.floppy_disk;
            this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripButton.Name = "saveToolStripButton";
            this.saveToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.saveToolStripButton.Text = "toolStripButton1";
            this.saveToolStripButton.Click += new System.EventHandler(this.saveToolStripButton_Click);
            // 
            // openToolStripButton
            // 
            this.openToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openToolStripButton.Image = global::compiler_app.Properties.Resources.new_doc;
            this.openToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripButton.Name = "openToolStripButton";
            this.openToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.openToolStripButton.Text = "toolStripButton4";
            this.openToolStripButton.Click += new System.EventHandler(this.openToolStripButton_Click);
            // 
            // archiveToolStripButton
            // 
            this.archiveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.archiveToolStripButton.Image = global::compiler_app.Properties.Resources.folder;
            this.archiveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.archiveToolStripButton.Name = "archiveToolStripButton";
            this.archiveToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.archiveToolStripButton.Text = "toolStripButton2";
            this.archiveToolStripButton.Click += new System.EventHandler(this.archiveToolStripButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // compileToolStripButton
            // 
            this.compileToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.compileToolStripButton.Image = global::compiler_app.Properties.Resources.play_icon;
            this.compileToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.compileToolStripButton.Name = "compileToolStripButton";
            this.compileToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.compileToolStripButton.Text = "toolStripButton3";
            this.compileToolStripButton.Click += new System.EventHandler(this.compileToolStripButton_Click);
            // 
            // stopToolStripButton
            // 
            this.stopToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.stopToolStripButton.Image = global::compiler_app.Properties.Resources.stop_icon;
            this.stopToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.stopToolStripButton.Name = "stopToolStripButton";
            this.stopToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.stopToolStripButton.Text = "toolStripButton5";
            this.stopToolStripButton.Click += new System.EventHandler(this.stopToolStripButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // exportToolStripButton1
            // 
            this.exportToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.exportToolStripButton1.Image = global::compiler_app.Properties.Resources.import;
            this.exportToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.exportToolStripButton1.Name = "exportToolStripButton1";
            this.exportToolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.exportToolStripButton1.Text = "toolStripButton1";
            this.exportToolStripButton1.Click += new System.EventHandler(this.exportToolStripButton1_Click);
            // 
            // clearnErrorButton
            // 
            this.clearnErrorButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.clearnErrorButton.Image = global::compiler_app.Properties.Resources.quit;
            this.clearnErrorButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.clearnErrorButton.Name = "clearnErrorButton";
            this.clearnErrorButton.Size = new System.Drawing.Size(23, 22);
            this.clearnErrorButton.Text = "toolStripButton1";
            this.clearnErrorButton.Click += new System.EventHandler(this.clearnErrorButton_Click);
            // 
            // codeTabControl
            // 
            this.codeTabControl.Controls.Add(this.tabPage1);
            this.codeTabControl.Controls.Add(this.tabPage2);
            this.codeTabControl.ItemSize = new System.Drawing.Size(70, 18);
            this.codeTabControl.Location = new System.Drawing.Point(4, 54);
            this.codeTabControl.Name = "codeTabControl";
            this.codeTabControl.SelectedIndex = 0;
            this.codeTabControl.Size = new System.Drawing.Size(1069, 454);
            this.codeTabControl.TabIndex = 2;
            this.codeTabControl.Tag = "";
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.DimGray;
            this.tabPage1.BackgroundImage = global::compiler_app.Properties.Resources.texture3;
            this.tabPage1.Controls.Add(this.codeRichTextBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1061, 428);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Archivos .gt";
            // 
            // codeRichTextBox
            // 
            this.codeRichTextBox.AcceptsTab = true;
            this.autocompleteMenu1.SetAutocompleteMenu(this.codeRichTextBox, this.autocompleteMenu1);
            this.codeRichTextBox.BackColor = System.Drawing.Color.Black;
            this.codeRichTextBox.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codeRichTextBox.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.codeRichTextBox.Location = new System.Drawing.Point(0, 0);
            this.codeRichTextBox.Name = "codeRichTextBox";
            this.codeRichTextBox.Size = new System.Drawing.Size(1049, 416);
            this.codeRichTextBox.TabIndex = 0;
            this.codeRichTextBox.Text = "";
            // 
            // tabPage2
            // 
            this.tabPage2.BackgroundImage = global::compiler_app.Properties.Resources.texture3;
            this.tabPage2.Controls.Add(this.exportationOppens);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1061, 428);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Archivos .gtE";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // exportationOppens
            // 
            this.autocompleteMenu1.SetAutocompleteMenu(this.exportationOppens, null);
            this.exportationOppens.BackColor = System.Drawing.SystemColors.WindowText;
            this.exportationOppens.Font = new System.Drawing.Font("Arial Narrow", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exportationOppens.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.exportationOppens.Location = new System.Drawing.Point(3, 6);
            this.exportationOppens.Name = "exportationOppens";
            this.exportationOppens.Size = new System.Drawing.Size(1058, 416);
            this.exportationOppens.TabIndex = 0;
            this.exportationOppens.Text = "";
            // 
            // errorTextBox
            // 
            this.autocompleteMenu1.SetAutocompleteMenu(this.errorTextBox, null);
            this.errorTextBox.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.errorTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.errorTextBox.Enabled = false;
            this.errorTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorTextBox.ForeColor = System.Drawing.Color.White;
            this.errorTextBox.Location = new System.Drawing.Point(4, 509);
            this.errorTextBox.Multiline = true;
            this.errorTextBox.Name = "errorTextBox";
            this.errorTextBox.Size = new System.Drawing.Size(1061, 120);
            this.errorTextBox.TabIndex = 3;
            this.errorTextBox.Text = "ERROR:";
            // 
            // errorGridViewer
            // 
            this.errorGridViewer.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.errorGridViewer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.errorGridViewer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID_error,
            this.line_error,
            this.text_error,
            this.message});
            this.errorGridViewer.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.errorGridViewer.Location = new System.Drawing.Point(12, 530);
            this.errorGridViewer.Name = "errorGridViewer";
            this.errorGridViewer.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.errorGridViewer.Size = new System.Drawing.Size(1045, 84);
            this.errorGridViewer.TabIndex = 4;
            // 
            // ID_error
            // 
            this.ID_error.HeaderText = "ID";
            this.ID_error.Name = "ID_error";
            // 
            // line_error
            // 
            this.line_error.HeaderText = "LINEA";
            this.line_error.Name = "line_error";
            // 
            // text_error
            // 
            this.text_error.HeaderText = "TOKEN";
            this.text_error.Name = "text_error";
            // 
            // message
            // 
            this.message.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.message.HeaderText = "MENSAJE";
            this.message.Name = "message";
            // 
            // saveFileDialogGT
            // 
            this.saveFileDialogGT.DefaultExt = "Archive from Compiler Simulator (*.gt)|*.gt";
            this.saveFileDialogGT.Filter = "Archive from Compiler Simulator (*.gt)|*.gt";
            // 
            // pathTextBox
            // 
            this.autocompleteMenu1.SetAutocompleteMenu(this.pathTextBox, null);
            this.pathTextBox.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.pathTextBox.ForeColor = System.Drawing.Color.Maroon;
            this.pathTextBox.Location = new System.Drawing.Point(12, 627);
            this.pathTextBox.Name = "pathTextBox";
            this.pathTextBox.Size = new System.Drawing.Size(1045, 20);
            this.pathTextBox.TabIndex = 5;
            // 
            // openFileDialogGT
            // 
            this.openFileDialogGT.FileName = "openFileDialog1";
            this.openFileDialogGT.Filter = "Archive from Compiler Simulator (*.gt)|*.gt";
            // 
            // openFileDialogGTE
            // 
            this.openFileDialogGTE.FileName = "openFileDialog1";
            this.openFileDialogGTE.Filter = "Export from Compiler Simulator(*.gtE| *.gtE";
            // 
            // saveFileDialogGTE
            // 
            this.saveFileDialogGTE.Filter = "Export from Compiler Simulator(*.gtE| *.gtE";
            // 
            // gtePathLabel
            // 
            this.gtePathLabel.AutoSize = true;
            this.gtePathLabel.Location = new System.Drawing.Point(1022, 514);
            this.gtePathLabel.Name = "gtePathLabel";
            this.gtePathLabel.Size = new System.Drawing.Size(36, 13);
            this.gtePathLabel.TabIndex = 1;
            this.gtePathLabel.Text = "PATH";
            // 
            // autocompleteMenu1
            // 
            this.autocompleteMenu1.Colors = ((AutocompleteMenuNS.Colors)(resources.GetObject("autocompleteMenu1.Colors")));
            this.autocompleteMenu1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.autocompleteMenu1.ImageList = this.imageList1;
            this.autocompleteMenu1.Items = new string[] {
        "SI () {}",
        "SINO {}",
        "SINO ENTONCES {}",
        "SINO_SI () {}",
        "entero",
        "decimal",
        "caracter",
        "cadena"};
            this.autocompleteMenu1.TargetControlWrapper = null;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // IDE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::compiler_app.Properties.Resources.texture3;
            this.ClientSize = new System.Drawing.Size(1069, 659);
            this.Controls.Add(this.gtePathLabel);
            this.Controls.Add(this.pathTextBox);
            this.Controls.Add(this.errorGridViewer);
            this.Controls.Add(this.errorTextBox);
            this.Controls.Add(this.codeTabControl);
            this.Controls.Add(this.toolsToolStrip);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "IDE";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolsToolStrip.ResumeLayout(false);
            this.toolsToolStrip.PerformLayout();
            this.codeTabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorGridViewer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ayudaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem seeHelpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem herramientasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolsToolStrip;
        private System.Windows.Forms.ToolStripButton saveToolStripButton;
        private System.Windows.Forms.ToolStripButton archiveToolStripButton;
        private System.Windows.Forms.ToolStripButton compileToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton openToolStripButton;
        private System.Windows.Forms.ToolStripButton stopToolStripButton;
        private System.Windows.Forms.TabControl codeTabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.RichTextBox exportationOppens;
        private System.Windows.Forms.RichTextBox codeRichTextBox;
        private System.Windows.Forms.TextBox errorTextBox;
        private System.Windows.Forms.DataGridView errorGridViewer;
        private System.Windows.Forms.ToolStripMenuItem fontColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consoleColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton exportToolStripButton1;
        private System.Windows.Forms.ToolStripMenuItem registrarExtensionToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialogGT;
        private System.Windows.Forms.TextBox pathTextBox;
        private System.Windows.Forms.OpenFileDialog openFileDialogGT;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ToolStripMenuItem testToolStrip;
        private System.Windows.Forms.ToolStripButton clearnErrorButton;
        private System.Windows.Forms.ToolStripMenuItem abrirArchivoGTEToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialogGTE;
        private System.Windows.Forms.SaveFileDialog saveFileDialogGTE;
        private System.Windows.Forms.Label gtePathLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_error;
        private System.Windows.Forms.DataGridViewTextBoxColumn line_error;
        private System.Windows.Forms.DataGridViewTextBoxColumn text_error;
        private System.Windows.Forms.DataGridViewTextBoxColumn message;
        private System.Windows.Forms.ToolStripMenuItem ventanaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hideToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
        private AutocompleteMenuNS.AutocompleteMenu autocompleteMenu1;
        private System.Windows.Forms.ImageList imageList1;
    }
}

