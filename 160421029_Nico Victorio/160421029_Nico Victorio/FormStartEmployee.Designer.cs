
namespace _160421029_Nico_Victorio
{
    partial class FormStartEmployee
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
            this.buttonKembali = new System.Windows.Forms.Button();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.textBoxEmailEmployee = new System.Windows.Forms.TextBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.labelUsername = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonKembali
            // 
            this.buttonKembali.Location = new System.Drawing.Point(134, 119);
            this.buttonKembali.Name = "buttonKembali";
            this.buttonKembali.Size = new System.Drawing.Size(75, 23);
            this.buttonKembali.TabIndex = 17;
            this.buttonKembali.Text = "Kembali";
            this.buttonKembali.UseVisualStyleBackColor = true;
            this.buttonKembali.Click += new System.EventHandler(this.buttonKembali_Click);
            // 
            // buttonLogin
            // 
            this.buttonLogin.Location = new System.Drawing.Point(219, 119);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(75, 23);
            this.buttonLogin.TabIndex = 16;
            this.buttonLogin.Text = "Login";
            this.buttonLogin.UseVisualStyleBackColor = true;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(134, 77);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(160, 20);
            this.textBoxPassword.TabIndex = 15;
            // 
            // textBoxEmailEmployee
            // 
            this.textBoxEmailEmployee.Location = new System.Drawing.Point(134, 38);
            this.textBoxEmailEmployee.Name = "textBoxEmailEmployee";
            this.textBoxEmailEmployee.Size = new System.Drawing.Size(160, 20);
            this.textBoxEmailEmployee.TabIndex = 14;
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(49, 80);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(56, 13);
            this.labelPassword.TabIndex = 13;
            this.labelPassword.Text = "Password:";
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.Location = new System.Drawing.Point(49, 41);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(35, 13);
            this.labelUsername.TabIndex = 12;
            this.labelUsername.Text = "Email:";
            // 
            // FormStartEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 188);
            this.Controls.Add(this.buttonKembali);
            this.Controls.Add(this.buttonLogin);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.textBoxEmailEmployee);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.labelUsername);
            this.Name = "FormStartEmployee";
            this.Text = "FormStartEmployee";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormStartEmployee_FormClosing);
            this.Load += new System.EventHandler(this.FormStartEmployee_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonKembali;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.TextBox textBoxEmailEmployee;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.Label labelUsername;
    }
}