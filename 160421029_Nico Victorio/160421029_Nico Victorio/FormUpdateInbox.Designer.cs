
namespace _160421029_Nico_Victorio
{
    partial class FormUpdateInbox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormUpdateInbox));
            this.btn_Exit = new System.Windows.Forms.Button();
            this.textBoxPesan = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.comboBoxIdPengguna = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btn_Exit
            // 
            this.btn_Exit.BackColor = System.Drawing.Color.Bisque;
            this.btn_Exit.Location = new System.Drawing.Point(361, 178);
            this.btn_Exit.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(66, 28);
            this.btn_Exit.TabIndex = 55;
            this.btn_Exit.Text = "Exit";
            this.btn_Exit.UseVisualStyleBackColor = false;
            // 
            // textBoxPesan
            // 
            this.textBoxPesan.BackColor = System.Drawing.Color.Bisque;
            this.textBoxPesan.Location = new System.Drawing.Point(137, 66);
            this.textBoxPesan.Multiline = true;
            this.textBoxPesan.Name = "textBoxPesan";
            this.textBoxPesan.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxPesan.Size = new System.Drawing.Size(290, 87);
            this.textBoxPesan.TabIndex = 53;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(77, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 52;
            this.label2.Text = "Pesan";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 50;
            this.label1.Text = "Id Pengguna";
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.BackColor = System.Drawing.Color.Bisque;
            this.buttonUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonUpdate.Location = new System.Drawing.Point(137, 180);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(74, 26);
            this.buttonUpdate.TabIndex = 82;
            this.buttonUpdate.Text = "Update";
            this.buttonUpdate.UseVisualStyleBackColor = false;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // comboBoxIdPengguna
            // 
            this.comboBoxIdPengguna.BackColor = System.Drawing.Color.Bisque;
            this.comboBoxIdPengguna.FormattingEnabled = true;
            this.comboBoxIdPengguna.Location = new System.Drawing.Point(137, 32);
            this.comboBoxIdPengguna.Name = "comboBoxIdPengguna";
            this.comboBoxIdPengguna.Size = new System.Drawing.Size(143, 21);
            this.comboBoxIdPengguna.TabIndex = 83;
            // 
            // FormUpdateInbox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Bisque;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(489, 244);
            this.Controls.Add(this.comboBoxIdPengguna);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.btn_Exit);
            this.Controls.Add(this.textBoxPesan);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormUpdateInbox";
            this.Text = "Update Inbox";
            this.Load += new System.EventHandler(this.FormUpdateInbox_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Exit;
        private System.Windows.Forms.TextBox textBoxPesan;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.ComboBox comboBoxIdPengguna;
    }
}