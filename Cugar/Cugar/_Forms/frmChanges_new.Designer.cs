namespace Cugar
{
    partial class frmChanges_new
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
            this.txtResult = new System.Windows.Forms.TextBox();
            this.lblInfo = new System.Windows.Forms.Label();
            this.lblChangesSugarContact = new System.Windows.Forms.Label();
            this.dgvSugarActive = new System.Windows.Forms.DataGridView();
            this.cmdAcceptChanges = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSugarActive)).BeginInit();
            this.SuspendLayout();
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(15, 143);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(260, 106);
            this.txtResult.TabIndex = 7;
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(12, 127);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(90, 13);
            this.lblInfo.TabIndex = 6;
            this.lblInfo.Text = "Info über das DS:";
            // 
            // lblChangesSugarContact
            // 
            this.lblChangesSugarContact.AutoSize = true;
            this.lblChangesSugarContact.Location = new System.Drawing.Point(13, 5);
            this.lblChangesSugarContact.Name = "lblChangesSugarContact";
            this.lblChangesSugarContact.Size = new System.Drawing.Size(140, 13);
            this.lblChangesSugarContact.TabIndex = 5;
            this.lblChangesSugarContact.Text = "Active Row Sugar contacts:";
            // 
            // dgvSugarActive
            // 
            this.dgvSugarActive.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSugarActive.Location = new System.Drawing.Point(12, 24);
            this.dgvSugarActive.Name = "dgvSugarActive";
            this.dgvSugarActive.Size = new System.Drawing.Size(720, 100);
            this.dgvSugarActive.TabIndex = 4;
            // 
            // cmdAcceptChanges
            // 
            this.cmdAcceptChanges.Location = new System.Drawing.Point(294, 154);
            this.cmdAcceptChanges.Name = "cmdAcceptChanges";
            this.cmdAcceptChanges.Size = new System.Drawing.Size(141, 23);
            this.cmdAcceptChanges.TabIndex = 8;
            this.cmdAcceptChanges.Text = "AcceptChanges";
            this.cmdAcceptChanges.UseVisualStyleBackColor = true;
            this.cmdAcceptChanges.Click += new System.EventHandler(this.cmdAcceptChanges_Click);
            // 
            // frmChanges_new
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 374);
            this.Controls.Add(this.cmdAcceptChanges);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.lblChangesSugarContact);
            this.Controls.Add(this.dgvSugarActive);
            this.Name = "frmChanges_new";
            this.Text = "frmChanges_new";
            this.Load += new System.EventHandler(this.frmChanges_new_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSugarActive)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Label lblChangesSugarContact;
        private System.Windows.Forms.DataGridView dgvSugarActive;
        private System.Windows.Forms.Button cmdAcceptChanges;
    }
}