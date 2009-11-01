namespace Hattrick.Test
{
    partial class frmMain
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSecurityCode = new System.Windows.Forms.TextBox();
            this.btDoIt = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtChppId = new System.Windows.Forms.TextBox();
            this.txtChppKey = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chkSave = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Username";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(106, 7);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(145, 23);
            this.txtUsername.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Security Code";
            // 
            // txtSecurityCode
            // 
            this.txtSecurityCode.Location = new System.Drawing.Point(106, 37);
            this.txtSecurityCode.Name = "txtSecurityCode";
            this.txtSecurityCode.Size = new System.Drawing.Size(145, 23);
            this.txtSecurityCode.TabIndex = 3;
            // 
            // btDoIt
            // 
            this.btDoIt.Location = new System.Drawing.Point(127, 146);
            this.btDoIt.Name = "btDoIt";
            this.btDoIt.Size = new System.Drawing.Size(121, 28);
            this.btDoIt.TabIndex = 8;
            this.btDoIt.Text = "Do It!";
            this.btDoIt.UseVisualStyleBackColor = true;
            this.btDoIt.Click += new System.EventHandler(this.btDoIt_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "CHPP ID";
            // 
            // txtChppId
            // 
            this.txtChppId.Location = new System.Drawing.Point(106, 66);
            this.txtChppId.Name = "txtChppId";
            this.txtChppId.Size = new System.Drawing.Size(145, 23);
            this.txtChppId.TabIndex = 5;
            // 
            // txtChppKey
            // 
            this.txtChppKey.Location = new System.Drawing.Point(106, 95);
            this.txtChppKey.Name = "txtChppKey";
            this.txtChppKey.Size = new System.Drawing.Size(145, 23);
            this.txtChppKey.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "CHPP Key";
            // 
            // chkSave
            // 
            this.chkSave.AutoSize = true;
            this.chkSave.Location = new System.Drawing.Point(106, 121);
            this.chkSave.Name = "chkSave";
            this.chkSave.Size = new System.Drawing.Size(74, 19);
            this.chkSave.TabIndex = 9;
            this.chkSave.Text = "Save info";
            this.chkSave.UseVisualStyleBackColor = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(260, 186);
            this.Controls.Add(this.chkSave);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtChppKey);
            this.Controls.Add(this.txtChppId);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btDoIt);
            this.Controls.Add(this.txtSecurityCode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hattrick.Service Test";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSecurityCode;
        private System.Windows.Forms.Button btDoIt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtChppId;
        private System.Windows.Forms.TextBox txtChppKey;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkSave;
    }
}

