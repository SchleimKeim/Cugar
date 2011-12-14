namespace Cugar
{
    partial class frmSuche
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtSuche = new System.Windows.Forms.TextBox();
            this.rbName = new System.Windows.Forms.RadioButton();
            this.rbStrasse = new System.Windows.Forms.RadioButton();
            this.rbTelefon = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.grpSuche = new System.Windows.Forms.GroupBox();
            this.dgvSugarSuche = new System.Windows.Forms.DataGridView();
            this.dgvCaoSuche = new System.Windows.Forms.DataGridView();
            this.cmdSuche = new System.Windows.Forms.Button();
            this.cmdClear = new System.Windows.Forms.Button();
            this.cmdLoad = new System.Windows.Forms.Button();
            this.cmdExit = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.grpSuche.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSugarSuche)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCaoSuche)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSuche
            // 
            this.txtSuche.Location = new System.Drawing.Point(12, 25);
            this.txtSuche.Name = "txtSuche";
            this.txtSuche.Size = new System.Drawing.Size(178, 20);
            this.txtSuche.TabIndex = 0;
            this.txtSuche.TextChanged += new System.EventHandler(this.txtSuche_TextChanged);
            // 
            // rbName
            // 
            this.rbName.AutoSize = true;
            this.rbName.Location = new System.Drawing.Point(196, 26);
            this.rbName.Name = "rbName";
            this.rbName.Size = new System.Drawing.Size(53, 17);
            this.rbName.TabIndex = 1;
            this.rbName.TabStop = true;
            this.rbName.Text = "&Name";
            this.rbName.UseVisualStyleBackColor = true;
            // 
            // rbStrasse
            // 
            this.rbStrasse.AutoSize = true;
            this.rbStrasse.Location = new System.Drawing.Point(255, 26);
            this.rbStrasse.Name = "rbStrasse";
            this.rbStrasse.Size = new System.Drawing.Size(60, 17);
            this.rbStrasse.TabIndex = 2;
            this.rbStrasse.TabStop = true;
            this.rbStrasse.Text = "Strass&e";
            this.rbStrasse.UseVisualStyleBackColor = true;
            // 
            // rbTelefon
            // 
            this.rbTelefon.AutoSize = true;
            this.rbTelefon.Location = new System.Drawing.Point(321, 26);
            this.rbTelefon.Name = "rbTelefon";
            this.rbTelefon.Size = new System.Drawing.Size(61, 17);
            this.rbTelefon.TabIndex = 3;
            this.rbTelefon.TabStop = true;
            this.rbTelefon.Text = "&Telefon";
            this.rbTelefon.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Suchbegriff:";
            // 
            // grpSuche
            // 
            this.grpSuche.Controls.Add(this.label3);
            this.grpSuche.Controls.Add(this.label2);
            this.grpSuche.Controls.Add(this.dgvSugarSuche);
            this.grpSuche.Controls.Add(this.dgvCaoSuche);
            this.grpSuche.Location = new System.Drawing.Point(12, 80);
            this.grpSuche.Name = "grpSuche";
            this.grpSuche.Size = new System.Drawing.Size(879, 335);
            this.grpSuche.TabIndex = 5;
            this.grpSuche.TabStop = false;
            this.grpSuche.Text = "Resultate:";
            // 
            // dgvSugarSuche
            // 
            this.dgvSugarSuche.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSugarSuche.Location = new System.Drawing.Point(7, 188);
            this.dgvSugarSuche.Name = "dgvSugarSuche";
            this.dgvSugarSuche.Size = new System.Drawing.Size(867, 137);
            this.dgvSugarSuche.TabIndex = 0;
            // 
            // dgvCaoSuche
            // 
            this.dgvCaoSuche.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCaoSuche.Location = new System.Drawing.Point(7, 32);
            this.dgvCaoSuche.Name = "dgvCaoSuche";
            this.dgvCaoSuche.Size = new System.Drawing.Size(867, 137);
            this.dgvCaoSuche.TabIndex = 0;
            // 
            // cmdSuche
            // 
            this.cmdSuche.Location = new System.Drawing.Point(12, 51);
            this.cmdSuche.Name = "cmdSuche";
            this.cmdSuche.Size = new System.Drawing.Size(75, 23);
            this.cmdSuche.TabIndex = 6;
            this.cmdSuche.Text = "&Suche";
            this.cmdSuche.UseVisualStyleBackColor = true;
            this.cmdSuche.Click += new System.EventHandler(this.cmdSuche_Click);
            // 
            // cmdClear
            // 
            this.cmdClear.Location = new System.Drawing.Point(93, 51);
            this.cmdClear.Name = "cmdClear";
            this.cmdClear.Size = new System.Drawing.Size(75, 23);
            this.cmdClear.TabIndex = 6;
            this.cmdClear.Text = "&Clear";
            this.cmdClear.UseVisualStyleBackColor = true;
            this.cmdClear.Click += new System.EventHandler(this.cmdClear_Click);
            // 
            // cmdLoad
            // 
            this.cmdLoad.Location = new System.Drawing.Point(174, 51);
            this.cmdLoad.Name = "cmdLoad";
            this.cmdLoad.Size = new System.Drawing.Size(92, 23);
            this.cmdLoad.TabIndex = 6;
            this.cmdLoad.Text = "&Laden / Merge";
            this.cmdLoad.UseVisualStyleBackColor = true;
            this.cmdLoad.Click += new System.EventHandler(this.cmdLoad_Click);
            // 
            // cmdExit
            // 
            this.cmdExit.Location = new System.Drawing.Point(272, 51);
            this.cmdExit.Name = "cmdExit";
            this.cmdExit.Size = new System.Drawing.Size(75, 23);
            this.cmdExit.TabIndex = 6;
            this.cmdExit.Text = "&Abbrechen";
            this.cmdExit.UseVisualStyleBackColor = true;
            this.cmdExit.Click += new System.EventHandler(this.cmdExit_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 172);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "SugarCRM:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "CAO-Faktura:";
            // 
            // frmSuche
            // 
            this.AcceptButton = this.cmdSuche;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 425);
            this.Controls.Add(this.cmdExit);
            this.Controls.Add(this.cmdLoad);
            this.Controls.Add(this.cmdClear);
            this.Controls.Add(this.cmdSuche);
            this.Controls.Add(this.grpSuche);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rbTelefon);
            this.Controls.Add(this.rbStrasse);
            this.Controls.Add(this.rbName);
            this.Controls.Add(this.txtSuche);
            this.Name = "frmSuche";
            this.Text = "Suche...";
            this.Load += new System.EventHandler(this.frmSuche_Load);
            this.grpSuche.ResumeLayout(false);
            this.grpSuche.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSugarSuche)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCaoSuche)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSuche;
        private System.Windows.Forms.RadioButton rbName;
        private System.Windows.Forms.RadioButton rbStrasse;
        private System.Windows.Forms.RadioButton rbTelefon;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpSuche;
        private System.Windows.Forms.DataGridView dgvSugarSuche;
        private System.Windows.Forms.DataGridView dgvCaoSuche;
        private System.Windows.Forms.Button cmdSuche;
        private System.Windows.Forms.Button cmdClear;
        private System.Windows.Forms.Button cmdLoad;
        private System.Windows.Forms.Button cmdExit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}