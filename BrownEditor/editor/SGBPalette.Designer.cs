namespace BrownEditor.editor
{
    partial class SGBPalette
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
            this.paletteIndex = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.palettePanel0 = new System.Windows.Forms.Panel();
            this.palettePanel1 = new System.Windows.Forms.Panel();
            this.palettePanel2 = new System.Windows.Forms.Panel();
            this.palettePanel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBoxEditColor = new System.Windows.Forms.GroupBox();
            this.panelActiveColor = new System.Windows.Forms.Panel();
            this.tabControlColorformat = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.RGBupdownB = new System.Windows.Forms.NumericUpDown();
            this.RGBupdownG = new System.Windows.Forms.NumericUpDown();
            this.RGBupdownR = new System.Windows.Forms.NumericUpDown();
            this.RGBHupdownB = new System.Windows.Forms.NumericUpDown();
            this.RGBHupdownG = new System.Windows.Forms.NumericUpDown();
            this.RGBHupdownR = new System.Windows.Forms.NumericUpDown();
            this.RGB15updownB = new System.Windows.Forms.NumericUpDown();
            this.RGB15updownG = new System.Windows.Forms.NumericUpDown();
            this.RGB15updownR = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.trackBarB = new System.Windows.Forms.TrackBar();
            this.trackBarG = new System.Windows.Forms.TrackBar();
            this.trackBarR = new System.Windows.Forms.TrackBar();
            this.labelBlue = new System.Windows.Forms.Label();
            this.labelGreen = new System.Windows.Forms.Label();
            this.labelHex = new System.Windows.Forms.Label();
            this.labelDec = new System.Windows.Forms.Label();
            this.labelRed = new System.Windows.Forms.Label();
            this.labelSet = new System.Windows.Forms.Label();
            this.textboxRGBHex = new System.Windows.Forms.TextBox();
            this.labelSnescolor = new System.Windows.Forms.Label();
            this.labelHexcolor = new System.Windows.Forms.Label();
            this.textboxBGR15 = new System.Windows.Forms.TextBox();
            this.buttonColor1 = new System.Windows.Forms.Button();
            this.buttonColor2 = new System.Windows.Forms.Button();
            this.buttonColor3 = new System.Windows.Forms.Button();
            this.buttonColor4 = new System.Windows.Forms.Button();
            this.panelColorbg = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.paletteIndex)).BeginInit();
            this.groupBoxEditColor.SuspendLayout();
            this.tabControlColorformat.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RGBupdownB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RGBupdownG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RGBupdownR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RGBHupdownB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RGBHupdownG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RGBHupdownR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RGB15updownB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RGB15updownG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RGB15updownR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarR)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // paletteIndex
            // 
            this.paletteIndex.Location = new System.Drawing.Point(82, 36);
            this.paletteIndex.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.paletteIndex.Name = "paletteIndex";
            this.paletteIndex.Size = new System.Drawing.Size(71, 20);
            this.paletteIndex.TabIndex = 0;
            this.paletteIndex.ValueChanged += new System.EventHandler(this.paletteIndex_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Palette:";
            // 
            // palettePanel0
            // 
            this.palettePanel0.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.palettePanel0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.palettePanel0.Location = new System.Drawing.Point(6, 38);
            this.palettePanel0.Name = "palettePanel0";
            this.palettePanel0.Size = new System.Drawing.Size(40, 40);
            this.palettePanel0.TabIndex = 2;
            this.palettePanel0.MouseClick += new System.Windows.Forms.MouseEventHandler(this.palettePanel0_MouseClick);
            // 
            // palettePanel1
            // 
            this.palettePanel1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.palettePanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.palettePanel1.Location = new System.Drawing.Point(6, 97);
            this.palettePanel1.Name = "palettePanel1";
            this.palettePanel1.Size = new System.Drawing.Size(40, 40);
            this.palettePanel1.TabIndex = 3;
            this.palettePanel1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.palettePanel1_MouseClick);
            // 
            // palettePanel2
            // 
            this.palettePanel2.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.palettePanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.palettePanel2.Location = new System.Drawing.Point(6, 156);
            this.palettePanel2.Name = "palettePanel2";
            this.palettePanel2.Size = new System.Drawing.Size(40, 40);
            this.palettePanel2.TabIndex = 4;
            this.palettePanel2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.palettePanel2_MouseClick);
            // 
            // palettePanel3
            // 
            this.palettePanel3.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.palettePanel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.palettePanel3.Location = new System.Drawing.Point(6, 215);
            this.palettePanel3.Name = "palettePanel3";
            this.palettePanel3.Size = new System.Drawing.Size(40, 40);
            this.palettePanel3.TabIndex = 4;
            this.palettePanel3.MouseClick += new System.Windows.Forms.MouseEventHandler(this.palettePanel3_MouseClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "0";
            // 
            // groupBoxEditColor
            // 
            this.groupBoxEditColor.Controls.Add(this.panelActiveColor);
            this.groupBoxEditColor.Controls.Add(this.tabControlColorformat);
            this.groupBoxEditColor.Controls.Add(this.labelSet);
            this.groupBoxEditColor.Controls.Add(this.textboxRGBHex);
            this.groupBoxEditColor.Controls.Add(this.labelSnescolor);
            this.groupBoxEditColor.Controls.Add(this.labelHexcolor);
            this.groupBoxEditColor.Controls.Add(this.textboxBGR15);
            this.groupBoxEditColor.Controls.Add(this.buttonColor1);
            this.groupBoxEditColor.Controls.Add(this.buttonColor2);
            this.groupBoxEditColor.Controls.Add(this.buttonColor3);
            this.groupBoxEditColor.Controls.Add(this.buttonColor4);
            this.groupBoxEditColor.Controls.Add(this.panelColorbg);
            this.groupBoxEditColor.Location = new System.Drawing.Point(36, 74);
            this.groupBoxEditColor.Name = "groupBoxEditColor";
            this.groupBoxEditColor.Size = new System.Drawing.Size(392, 303);
            this.groupBoxEditColor.TabIndex = 6;
            this.groupBoxEditColor.TabStop = false;
            this.groupBoxEditColor.Text = "Edit color";
            // 
            // panelActiveColor
            // 
            this.panelActiveColor.BackColor = System.Drawing.SystemColors.Control;
            this.panelActiveColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelActiveColor.Location = new System.Drawing.Point(269, 205);
            this.panelActiveColor.Name = "panelActiveColor";
            this.panelActiveColor.Size = new System.Drawing.Size(44, 44);
            this.panelActiveColor.TabIndex = 99;
            // 
            // tabControlColorformat
            // 
            this.tabControlColorformat.Controls.Add(this.tabPage1);
            this.tabControlColorformat.Location = new System.Drawing.Point(7, 20);
            this.tabControlColorformat.Name = "tabControlColorformat";
            this.tabControlColorformat.SelectedIndex = 0;
            this.tabControlColorformat.Size = new System.Drawing.Size(379, 178);
            this.tabControlColorformat.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Menu;
            this.tabPage1.Controls.Add(this.RGBupdownB);
            this.tabPage1.Controls.Add(this.RGBupdownG);
            this.tabPage1.Controls.Add(this.RGBupdownR);
            this.tabPage1.Controls.Add(this.RGBHupdownB);
            this.tabPage1.Controls.Add(this.RGBHupdownG);
            this.tabPage1.Controls.Add(this.RGBHupdownR);
            this.tabPage1.Controls.Add(this.RGB15updownB);
            this.tabPage1.Controls.Add(this.RGB15updownG);
            this.tabPage1.Controls.Add(this.RGB15updownR);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.trackBarB);
            this.tabPage1.Controls.Add(this.trackBarG);
            this.tabPage1.Controls.Add(this.trackBarR);
            this.tabPage1.Controls.Add(this.labelBlue);
            this.tabPage1.Controls.Add(this.labelGreen);
            this.tabPage1.Controls.Add(this.labelHex);
            this.tabPage1.Controls.Add(this.labelDec);
            this.tabPage1.Controls.Add(this.labelRed);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(371, 152);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "RGB";
            // 
            // RGBupdownB
            // 
            this.RGBupdownB.Location = new System.Drawing.Point(212, 107);
            this.RGBupdownB.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.RGBupdownB.Name = "RGBupdownB";
            this.RGBupdownB.Size = new System.Drawing.Size(48, 20);
            this.RGBupdownB.TabIndex = 112;
            this.RGBupdownB.ValueChanged += new System.EventHandler(this.RGBupdown_ValueChanged);
            // 
            // RGBupdownG
            // 
            this.RGBupdownG.Location = new System.Drawing.Point(212, 67);
            this.RGBupdownG.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.RGBupdownG.Name = "RGBupdownG";
            this.RGBupdownG.Size = new System.Drawing.Size(48, 20);
            this.RGBupdownG.TabIndex = 111;
            this.RGBupdownG.ValueChanged += new System.EventHandler(this.RGBupdown_ValueChanged);
            // 
            // RGBupdownR
            // 
            this.RGBupdownR.Location = new System.Drawing.Point(212, 26);
            this.RGBupdownR.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.RGBupdownR.Name = "RGBupdownR";
            this.RGBupdownR.Size = new System.Drawing.Size(48, 20);
            this.RGBupdownR.TabIndex = 110;
            this.RGBupdownR.ValueChanged += new System.EventHandler(this.RGBupdown_ValueChanged);
            // 
            // RGBHupdownB
            // 
            this.RGBHupdownB.Hexadecimal = true;
            this.RGBHupdownB.Location = new System.Drawing.Point(266, 107);
            this.RGBHupdownB.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.RGBHupdownB.Name = "RGBHupdownB";
            this.RGBHupdownB.Size = new System.Drawing.Size(48, 20);
            this.RGBHupdownB.TabIndex = 109;
            this.RGBHupdownB.ValueChanged += new System.EventHandler(this.RGBHupdown_ValueChanged);
            // 
            // RGBHupdownG
            // 
            this.RGBHupdownG.Hexadecimal = true;
            this.RGBHupdownG.Location = new System.Drawing.Point(266, 67);
            this.RGBHupdownG.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.RGBHupdownG.Name = "RGBHupdownG";
            this.RGBHupdownG.Size = new System.Drawing.Size(48, 20);
            this.RGBHupdownG.TabIndex = 108;
            this.RGBHupdownG.ValueChanged += new System.EventHandler(this.RGBHupdown_ValueChanged);
            // 
            // RGBHupdownR
            // 
            this.RGBHupdownR.Hexadecimal = true;
            this.RGBHupdownR.Location = new System.Drawing.Point(266, 26);
            this.RGBHupdownR.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.RGBHupdownR.Name = "RGBHupdownR";
            this.RGBHupdownR.Size = new System.Drawing.Size(48, 20);
            this.RGBHupdownR.TabIndex = 107;
            this.RGBHupdownR.ValueChanged += new System.EventHandler(this.RGBHupdown_ValueChanged);
            // 
            // RGB15updownB
            // 
            this.RGB15updownB.Location = new System.Drawing.Point(320, 107);
            this.RGB15updownB.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.RGB15updownB.Name = "RGB15updownB";
            this.RGB15updownB.Size = new System.Drawing.Size(48, 20);
            this.RGB15updownB.TabIndex = 106;
            this.RGB15updownB.ValueChanged += new System.EventHandler(this.RGB15updown_ValueChanged);
            // 
            // RGB15updownG
            // 
            this.RGB15updownG.Location = new System.Drawing.Point(320, 67);
            this.RGB15updownG.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.RGB15updownG.Name = "RGB15updownG";
            this.RGB15updownG.Size = new System.Drawing.Size(48, 20);
            this.RGB15updownG.TabIndex = 105;
            this.RGB15updownG.ValueChanged += new System.EventHandler(this.RGB15updown_ValueChanged);
            // 
            // RGB15updownR
            // 
            this.RGB15updownR.Location = new System.Drawing.Point(320, 26);
            this.RGB15updownR.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.RGB15updownR.Name = "RGB15updownR";
            this.RGB15updownR.Size = new System.Drawing.Size(48, 20);
            this.RGB15updownR.TabIndex = 7;
            this.RGB15updownR.ValueChanged += new System.EventHandler(this.RGB15updown_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(326, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 104;
            this.label3.Text = "RGB15";
            // 
            // trackBarB
            // 
            this.trackBarB.Location = new System.Drawing.Point(46, 106);
            this.trackBarB.Maximum = 255;
            this.trackBarB.Name = "trackBarB";
            this.trackBarB.Size = new System.Drawing.Size(164, 45);
            this.trackBarB.TabIndex = 102;
            this.trackBarB.ValueChanged += new System.EventHandler(this.trackBarChanged);
            // 
            // trackBarG
            // 
            this.trackBarG.Location = new System.Drawing.Point(47, 66);
            this.trackBarG.Maximum = 255;
            this.trackBarG.Name = "trackBarG";
            this.trackBarG.Size = new System.Drawing.Size(164, 45);
            this.trackBarG.TabIndex = 101;
            this.trackBarG.ValueChanged += new System.EventHandler(this.trackBarChanged);
            // 
            // trackBarR
            // 
            this.trackBarR.Location = new System.Drawing.Point(47, 25);
            this.trackBarR.Maximum = 255;
            this.trackBarR.Name = "trackBarR";
            this.trackBarR.Size = new System.Drawing.Size(164, 45);
            this.trackBarR.TabIndex = 100;
            this.trackBarR.ValueChanged += new System.EventHandler(this.trackBarChanged);
            // 
            // labelBlue
            // 
            this.labelBlue.AutoSize = true;
            this.labelBlue.Location = new System.Drawing.Point(13, 107);
            this.labelBlue.Name = "labelBlue";
            this.labelBlue.Size = new System.Drawing.Size(28, 13);
            this.labelBlue.TabIndex = 99;
            this.labelBlue.Text = "Blue";
            // 
            // labelGreen
            // 
            this.labelGreen.AutoSize = true;
            this.labelGreen.Location = new System.Drawing.Point(13, 67);
            this.labelGreen.Name = "labelGreen";
            this.labelGreen.Size = new System.Drawing.Size(36, 13);
            this.labelGreen.TabIndex = 99;
            this.labelGreen.Text = "Green";
            // 
            // labelHex
            // 
            this.labelHex.AutoSize = true;
            this.labelHex.Location = new System.Drawing.Point(277, 7);
            this.labelHex.Name = "labelHex";
            this.labelHex.Size = new System.Drawing.Size(26, 13);
            this.labelHex.TabIndex = 99;
            this.labelHex.Text = "Hex";
            // 
            // labelDec
            // 
            this.labelDec.AutoSize = true;
            this.labelDec.Location = new System.Drawing.Point(222, 7);
            this.labelDec.Name = "labelDec";
            this.labelDec.Size = new System.Drawing.Size(27, 13);
            this.labelDec.TabIndex = 99;
            this.labelDec.Text = "Dec";
            // 
            // labelRed
            // 
            this.labelRed.AutoSize = true;
            this.labelRed.Location = new System.Drawing.Point(13, 27);
            this.labelRed.Name = "labelRed";
            this.labelRed.Size = new System.Drawing.Size(27, 13);
            this.labelRed.TabIndex = 99;
            this.labelRed.Text = "Red";
            // 
            // labelSet
            // 
            this.labelSet.AutoSize = true;
            this.labelSet.Location = new System.Drawing.Point(17, 270);
            this.labelSet.Name = "labelSet";
            this.labelSet.Size = new System.Drawing.Size(40, 13);
            this.labelSet.TabIndex = 99;
            this.labelSet.Text = "Set as:";
            // 
            // textboxRGBHex
            // 
            this.textboxRGBHex.Location = new System.Drawing.Point(162, 204);
            this.textboxRGBHex.MaxLength = 7;
            this.textboxRGBHex.Name = "textboxRGBHex";
            this.textboxRGBHex.Size = new System.Drawing.Size(100, 20);
            this.textboxRGBHex.TabIndex = 1;
            // 
            // labelSnescolor
            // 
            this.labelSnescolor.AutoSize = true;
            this.labelSnescolor.Location = new System.Drawing.Point(17, 233);
            this.labelSnescolor.Name = "labelSnescolor";
            this.labelSnescolor.Size = new System.Drawing.Size(133, 13);
            this.labelSnescolor.TabIndex = 99;
            this.labelSnescolor.Text = "SNES color code (BGR15)";
            // 
            // labelHexcolor
            // 
            this.labelHexcolor.AutoSize = true;
            this.labelHexcolor.Location = new System.Drawing.Point(17, 208);
            this.labelHexcolor.Name = "labelHexcolor";
            this.labelHexcolor.Size = new System.Drawing.Size(123, 13);
            this.labelHexcolor.TabIndex = 99;
            this.labelHexcolor.Text = "Hex color code (RGB24)";
            // 
            // textboxBGR15
            // 
            this.textboxBGR15.Location = new System.Drawing.Point(162, 230);
            this.textboxBGR15.MaxLength = 4;
            this.textboxBGR15.Name = "textboxBGR15";
            this.textboxBGR15.Size = new System.Drawing.Size(100, 20);
            this.textboxBGR15.TabIndex = 2;
            this.textboxBGR15.Text = "0f35";
            // 
            // buttonColor1
            // 
            this.buttonColor1.Location = new System.Drawing.Point(62, 265);
            this.buttonColor1.Name = "buttonColor1";
            this.buttonColor1.Size = new System.Drawing.Size(59, 23);
            this.buttonColor1.TabIndex = 7;
            this.buttonColor1.Text = "Color 0";
            this.buttonColor1.UseVisualStyleBackColor = true;
            // 
            // buttonColor2
            // 
            this.buttonColor2.Location = new System.Drawing.Point(127, 265);
            this.buttonColor2.Name = "buttonColor2";
            this.buttonColor2.Size = new System.Drawing.Size(59, 23);
            this.buttonColor2.TabIndex = 8;
            this.buttonColor2.Text = "Color 1";
            this.buttonColor2.UseVisualStyleBackColor = true;
            // 
            // buttonColor3
            // 
            this.buttonColor3.Location = new System.Drawing.Point(192, 265);
            this.buttonColor3.Name = "buttonColor3";
            this.buttonColor3.Size = new System.Drawing.Size(59, 23);
            this.buttonColor3.TabIndex = 9;
            this.buttonColor3.Text = "Color 2";
            this.buttonColor3.UseVisualStyleBackColor = true;
            // 
            // buttonColor4
            // 
            this.buttonColor4.Location = new System.Drawing.Point(257, 265);
            this.buttonColor4.Name = "buttonColor4";
            this.buttonColor4.Size = new System.Drawing.Size(59, 23);
            this.buttonColor4.TabIndex = 10;
            this.buttonColor4.Text = "Color 3";
            this.buttonColor4.UseVisualStyleBackColor = true;
            // 
            // panelColorbg
            // 
            this.panelColorbg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(122)))), ((int)(((byte)(122)))));
            this.panelColorbg.Location = new System.Drawing.Point(268, 204);
            this.panelColorbg.Name = "panelColorbg";
            this.panelColorbg.Size = new System.Drawing.Size(46, 46);
            this.panelColorbg.TabIndex = 99;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 140);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(13, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "2";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 199);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(13, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "3";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.palettePanel0);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.palettePanel1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.palettePanel2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.palettePanel3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(434, 74);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(53, 262);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Colors";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(513, 74);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(180, 169);
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // SGBPalette
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBoxEditColor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.paletteIndex);
            this.Name = "SGBPalette";
            this.Text = "SGBPalette";
            ((System.ComponentModel.ISupportInitialize)(this.paletteIndex)).EndInit();
            this.groupBoxEditColor.ResumeLayout(false);
            this.groupBoxEditColor.PerformLayout();
            this.tabControlColorformat.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RGBupdownB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RGBupdownG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RGBupdownR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RGBHupdownB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RGBHupdownG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RGBHupdownR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RGB15updownB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RGB15updownG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RGB15updownR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarR)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown paletteIndex;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel palettePanel0;
        private System.Windows.Forms.Panel palettePanel1;
        private System.Windows.Forms.Panel palettePanel2;
        private System.Windows.Forms.Panel palettePanel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBoxEditColor;
        private System.Windows.Forms.Panel panelActiveColor;
        private System.Windows.Forms.TabControl tabControlColorformat;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar trackBarB;
        private System.Windows.Forms.TrackBar trackBarG;
        private System.Windows.Forms.TrackBar trackBarR;
        private System.Windows.Forms.Label labelBlue;
        private System.Windows.Forms.Label labelGreen;
        private System.Windows.Forms.Label labelHex;
        private System.Windows.Forms.Label labelDec;
        private System.Windows.Forms.Label labelRed;
        private System.Windows.Forms.Label labelSet;
        private System.Windows.Forms.TextBox textboxRGBHex;
        private System.Windows.Forms.Label labelSnescolor;
        private System.Windows.Forms.Label labelHexcolor;
        private System.Windows.Forms.TextBox textboxBGR15;
        private System.Windows.Forms.Button buttonColor1;
        private System.Windows.Forms.Button buttonColor2;
        private System.Windows.Forms.Button buttonColor3;
        private System.Windows.Forms.Button buttonColor4;
        private System.Windows.Forms.Panel panelColorbg;
        private System.Windows.Forms.NumericUpDown RGB15updownB;
        private System.Windows.Forms.NumericUpDown RGB15updownG;
        private System.Windows.Forms.NumericUpDown RGB15updownR;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown RGBupdownB;
        private System.Windows.Forms.NumericUpDown RGBupdownG;
        private System.Windows.Forms.NumericUpDown RGBupdownR;
        private System.Windows.Forms.NumericUpDown RGBHupdownB;
        private System.Windows.Forms.NumericUpDown RGBHupdownG;
        private System.Windows.Forms.NumericUpDown RGBHupdownR;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}