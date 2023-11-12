namespace BrownEditor
{
    partial class MainForm
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.ButtonLoad = new System.Windows.Forms.Button();
            this.ButtonSave = new System.Windows.Forms.Button();
            this.moveEditorBut = new System.Windows.Forms.Button();
            this.BaseStatsEditorBut = new System.Windows.Forms.Button();
            this.evomovesBut = new System.Windows.Forms.Button();
            this.tmhmBut = new System.Windows.Forms.Button();
            this.wildBut = new System.Windows.Forms.Button();
            this.SGBPaletteBut = new System.Windows.Forms.Button();
            this.gymBut = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ButtonLoad
            // 
            this.ButtonLoad.Location = new System.Drawing.Point(12, 12);
            this.ButtonLoad.Name = "ButtonLoad";
            this.ButtonLoad.Size = new System.Drawing.Size(75, 23);
            this.ButtonLoad.TabIndex = 0;
            this.ButtonLoad.Text = "Load ROM";
            this.ButtonLoad.UseVisualStyleBackColor = true;
            this.ButtonLoad.Click += new System.EventHandler(this.ButtonLoad_Click);
            // 
            // ButtonSave
            // 
            this.ButtonSave.Enabled = false;
            this.ButtonSave.Location = new System.Drawing.Point(155, 12);
            this.ButtonSave.Name = "ButtonSave";
            this.ButtonSave.Size = new System.Drawing.Size(75, 23);
            this.ButtonSave.TabIndex = 1;
            this.ButtonSave.Text = "Save ROM";
            this.ButtonSave.UseVisualStyleBackColor = true;
            this.ButtonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // moveEditorBut
            // 
            this.moveEditorBut.Enabled = false;
            this.moveEditorBut.Location = new System.Drawing.Point(12, 104);
            this.moveEditorBut.Name = "moveEditorBut";
            this.moveEditorBut.Size = new System.Drawing.Size(106, 23);
            this.moveEditorBut.TabIndex = 2;
            this.moveEditorBut.Text = "Move Editor";
            this.moveEditorBut.UseVisualStyleBackColor = true;
            this.moveEditorBut.Click += new System.EventHandler(this.moveEditorBut_Click);
            // 
            // BaseStatsEditorBut
            // 
            this.BaseStatsEditorBut.Enabled = false;
            this.BaseStatsEditorBut.Location = new System.Drawing.Point(12, 75);
            this.BaseStatsEditorBut.Name = "BaseStatsEditorBut";
            this.BaseStatsEditorBut.Size = new System.Drawing.Size(106, 23);
            this.BaseStatsEditorBut.TabIndex = 3;
            this.BaseStatsEditorBut.Text = "Base Stats Editor";
            this.BaseStatsEditorBut.UseVisualStyleBackColor = true;
            this.BaseStatsEditorBut.Click += new System.EventHandler(this.BaseStatsEditorBut_Click);
            // 
            // evomovesBut
            // 
            this.evomovesBut.Enabled = false;
            this.evomovesBut.Location = new System.Drawing.Point(124, 75);
            this.evomovesBut.Name = "evomovesBut";
            this.evomovesBut.Size = new System.Drawing.Size(106, 23);
            this.evomovesBut.TabIndex = 4;
            this.evomovesBut.Text = "EvoMoves Editor";
            this.evomovesBut.UseVisualStyleBackColor = true;
            this.evomovesBut.Click += new System.EventHandler(this.evomovesBut_Click);
            // 
            // tmhmBut
            // 
            this.tmhmBut.Enabled = false;
            this.tmhmBut.Location = new System.Drawing.Point(124, 104);
            this.tmhmBut.Name = "tmhmBut";
            this.tmhmBut.Size = new System.Drawing.Size(106, 23);
            this.tmhmBut.TabIndex = 5;
            this.tmhmBut.Text = "TM/HM Editor";
            this.tmhmBut.UseVisualStyleBackColor = true;
            // 
            // wildBut
            // 
            this.wildBut.Enabled = false;
            this.wildBut.Location = new System.Drawing.Point(12, 133);
            this.wildBut.Name = "wildBut";
            this.wildBut.Size = new System.Drawing.Size(106, 23);
            this.wildBut.TabIndex = 6;
            this.wildBut.Text = "Wild Encounters";
            this.wildBut.UseVisualStyleBackColor = true;
            this.wildBut.Click += new System.EventHandler(this.wildBut_Click);
            // 
            // SGBPaletteBut
            // 
            this.SGBPaletteBut.Enabled = false;
            this.SGBPaletteBut.Location = new System.Drawing.Point(124, 133);
            this.SGBPaletteBut.Name = "SGBPaletteBut";
            this.SGBPaletteBut.Size = new System.Drawing.Size(106, 23);
            this.SGBPaletteBut.TabIndex = 7;
            this.SGBPaletteBut.Text = "SGB Palettes";
            this.SGBPaletteBut.UseVisualStyleBackColor = true;
            this.SGBPaletteBut.Click += new System.EventHandler(this.SGBPaletteBut_Click);
            // 
            // gymBut
            // 
            this.gymBut.Enabled = false;
            this.gymBut.Location = new System.Drawing.Point(12, 162);
            this.gymBut.Name = "gymBut";
            this.gymBut.Size = new System.Drawing.Size(106, 23);
            this.gymBut.TabIndex = 8;
            this.gymBut.Text = "Gym/E4 Editor";
            this.gymBut.UseVisualStyleBackColor = true;
            this.gymBut.Click += new System.EventHandler(this.gymBut_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(240, 194);
            this.Controls.Add(this.gymBut);
            this.Controls.Add(this.SGBPaletteBut);
            this.Controls.Add(this.wildBut);
            this.Controls.Add(this.tmhmBut);
            this.Controls.Add(this.evomovesBut);
            this.Controls.Add(this.BaseStatsEditorBut);
            this.Controls.Add(this.moveEditorBut);
            this.Controls.Add(this.ButtonSave);
            this.Controls.Add(this.ButtonLoad);
            this.Name = "MainForm";
            this.Text = "Brown Editor";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ButtonLoad;
        private System.Windows.Forms.Button ButtonSave;
        private System.Windows.Forms.Button moveEditorBut;
        private System.Windows.Forms.Button BaseStatsEditorBut;
        private System.Windows.Forms.Button evomovesBut;
        private System.Windows.Forms.Button tmhmBut;
        private System.Windows.Forms.Button wildBut;
        private System.Windows.Forms.Button SGBPaletteBut;
        private System.Windows.Forms.Button gymBut;
    }
}

