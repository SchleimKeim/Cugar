namespace Cugar
{
    partial class frmSettings
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
            this.txtCaoPW = new System.Windows.Forms.TextBox();
            this.txtCaoUser = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtCaoHost = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmdSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtCaoDBName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSugarPW = new System.Windows.Forms.TextBox();
            this.txtSugarUser = new System.Windows.Forms.TextBox();
            this.txtSugarHost = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.grpSettingsSugar = new System.Windows.Forms.GroupBox();
            this.txtSugarDBName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.grpSettingsSugar.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtCaoPW
            // 
            this.txtCaoPW.Location = new System.Drawing.Point(76, 71);
            this.txtCaoPW.Name = "txtCaoPW";
            this.txtCaoPW.Size = new System.Drawing.Size(121, 20);
            this.txtCaoPW.TabIndex = 1;
            this.txtCaoPW.UseSystemPasswordChar = true;
            // 
            // txtCaoUser
            // 
            this.txtCaoUser.Location = new System.Drawing.Point(76, 45);
            this.txtCaoUser.Name = "txtCaoUser";
            this.txtCaoUser.Size = new System.Drawing.Size(121, 20);
            this.txtCaoUser.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(277, 146);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "&Abbrechen";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtCaoHost
            // 
            this.txtCaoHost.Location = new System.Drawing.Point(76, 19);
            this.txtCaoHost.Name = "txtCaoHost";
            this.txtCaoHost.Size = new System.Drawing.Size(121, 20);
            this.txtCaoHost.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Passwort:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Username:";
            // 
            // cmdSave
            // 
            this.cmdSave.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdSave.Location = new System.Drawing.Point(358, 146);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(75, 23);
            this.cmdSave.TabIndex = 7;
            this.cmdSave.Text = "&Speichern";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Host:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Host:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtCaoDBName);
            this.groupBox1.Controls.Add(this.txtCaoPW);
            this.groupBox1.Controls.Add(this.txtCaoUser);
            this.groupBox1.Controls.Add(this.txtCaoHost);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(226, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(207, 126);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "CAO Settings";
            // 
            // txtCaoDBName
            // 
            this.txtCaoDBName.Location = new System.Drawing.Point(76, 97);
            this.txtCaoDBName.Name = "txtCaoDBName";
            this.txtCaoDBName.Size = new System.Drawing.Size(121, 20);
            this.txtCaoDBName.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 100);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "DB Name:";
            // 
            // txtSugarPW
            // 
            this.txtSugarPW.Location = new System.Drawing.Point(76, 71);
            this.txtSugarPW.Name = "txtSugarPW";
            this.txtSugarPW.Size = new System.Drawing.Size(121, 20);
            this.txtSugarPW.TabIndex = 1;
            this.txtSugarPW.UseSystemPasswordChar = true;
            // 
            // txtSugarUser
            // 
            this.txtSugarUser.Location = new System.Drawing.Point(76, 45);
            this.txtSugarUser.Name = "txtSugarUser";
            this.txtSugarUser.Size = new System.Drawing.Size(121, 20);
            this.txtSugarUser.TabIndex = 1;
            // 
            // txtSugarHost
            // 
            this.txtSugarHost.Location = new System.Drawing.Point(76, 19);
            this.txtSugarHost.Name = "txtSugarHost";
            this.txtSugarHost.Size = new System.Drawing.Size(121, 20);
            this.txtSugarHost.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Passwort:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Username:";
            // 
            // grpSettingsSugar
            // 
            this.grpSettingsSugar.Controls.Add(this.label1);
            this.grpSettingsSugar.Controls.Add(this.txtSugarDBName);
            this.grpSettingsSugar.Controls.Add(this.txtSugarPW);
            this.grpSettingsSugar.Controls.Add(this.txtSugarUser);
            this.grpSettingsSugar.Controls.Add(this.txtSugarHost);
            this.grpSettingsSugar.Controls.Add(this.label5);
            this.grpSettingsSugar.Controls.Add(this.label8);
            this.grpSettingsSugar.Controls.Add(this.label2);
            this.grpSettingsSugar.Location = new System.Drawing.Point(13, 14);
            this.grpSettingsSugar.Name = "grpSettingsSugar";
            this.grpSettingsSugar.Size = new System.Drawing.Size(207, 126);
            this.grpSettingsSugar.TabIndex = 6;
            this.grpSettingsSugar.TabStop = false;
            this.grpSettingsSugar.Text = "Sugar Settings";
            // 
            // txtSugarDBName
            // 
            this.txtSugarDBName.Location = new System.Drawing.Point(76, 97);
            this.txtSugarDBName.Name = "txtSugarDBName";
            this.txtSugarDBName.Size = new System.Drawing.Size(121, 20);
            this.txtSugarDBName.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 100);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "DB Name:";
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 181);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpSettingsSugar);
            this.Name = "frmSettings";
            this.Text = "Einstellungen";
            this.Load += new System.EventHandler(this.frmSettings_new_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpSettingsSugar.ResumeLayout(false);
            this.grpSettingsSugar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtCaoPW;
        private System.Windows.Forms.TextBox txtCaoUser;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtCaoHost;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtSugarPW;
        private System.Windows.Forms.TextBox txtSugarUser;
        private System.Windows.Forms.TextBox txtSugarHost;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox grpSettingsSugar;
        private System.Windows.Forms.TextBox txtCaoDBName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtSugarDBName;
        private System.Windows.Forms.Label label8;
    }
}