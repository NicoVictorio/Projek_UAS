
namespace _160421029_Nico_Victorio
{
    partial class FormUpdatePassword
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
            this.textBoxPasswordLama = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxUlangiPasswordBaru = new System.Windows.Forms.TextBox();
            this.textBoxPasswordBaru = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxPasswordLama
            // 
            this.textBoxPasswordLama.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxPasswordLama.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPasswordLama.Location = new System.Drawing.Point(156, 18);
            this.textBoxPasswordLama.Name = "textBoxPasswordLama";
            this.textBoxPasswordLama.PasswordChar = '*';
            this.textBoxPasswordLama.Size = new System.Drawing.Size(191, 23);
            this.textBoxPasswordLama.TabIndex = 62;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Corbel", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(65, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 15);
            this.label6.TabIndex = 60;
            this.label6.Text = "Password Lama";
            // 
            // textBoxUlangiPasswordBaru
            // 
            this.textBoxUlangiPasswordBaru.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxUlangiPasswordBaru.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxUlangiPasswordBaru.Location = new System.Drawing.Point(156, 76);
            this.textBoxUlangiPasswordBaru.Name = "textBoxUlangiPasswordBaru";
            this.textBoxUlangiPasswordBaru.PasswordChar = '*';
            this.textBoxUlangiPasswordBaru.Size = new System.Drawing.Size(191, 23);
            this.textBoxUlangiPasswordBaru.TabIndex = 67;
            // 
            // textBoxPasswordBaru
            // 
            this.textBoxPasswordBaru.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxPasswordBaru.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPasswordBaru.Location = new System.Drawing.Point(156, 47);
            this.textBoxPasswordBaru.Name = "textBoxPasswordBaru";
            this.textBoxPasswordBaru.PasswordChar = '*';
            this.textBoxPasswordBaru.Size = new System.Drawing.Size(191, 23);
            this.textBoxPasswordBaru.TabIndex = 66;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Corbel", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(27, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 15);
            this.label1.TabIndex = 65;
            this.label1.Text = "Ulangi Password Baru";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Corbel", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(65, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 15);
            this.label2.TabIndex = 64;
            this.label2.Text = "Password Baru";
            // 
            // buttonExit
            // 
            this.buttonExit.BackColor = System.Drawing.SystemColors.Control;
            this.buttonExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExit.Location = new System.Drawing.Point(274, 124);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(72, 26);
            this.buttonExit.TabIndex = 88;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = false;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.BackColor = System.Drawing.SystemColors.Control;
            this.buttonUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonUpdate.Location = new System.Drawing.Point(181, 124);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(72, 26);
            this.buttonUpdate.TabIndex = 87;
            this.buttonUpdate.Text = "Update";
            this.buttonUpdate.UseVisualStyleBackColor = false;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // FormUpdatePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(362, 169);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.textBoxUlangiPasswordBaru);
            this.Controls.Add(this.textBoxPasswordBaru);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxPasswordLama);
            this.Controls.Add(this.label6);
            this.Name = "FormUpdatePassword";
            this.Text = "Ganti Password";
            this.Load += new System.EventHandler(this.FormUpdatePassword_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxPasswordLama;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxUlangiPasswordBaru;
        private System.Windows.Forms.TextBox textBoxPasswordBaru;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button buttonUpdate;
    }
}