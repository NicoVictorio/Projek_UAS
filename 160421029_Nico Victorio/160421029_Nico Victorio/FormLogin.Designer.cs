
namespace _160421029_Nico_Victorio
{
    partial class FormLogin
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.loginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loginPenggunaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loginEmployeeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buatAkunToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buatAkunPenggunaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loginToolStripMenuItem,
            this.buatAkunToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(343, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // loginToolStripMenuItem
            // 
            this.loginToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loginPenggunaToolStripMenuItem,
            this.loginEmployeeToolStripMenuItem});
            this.loginToolStripMenuItem.Name = "loginToolStripMenuItem";
            this.loginToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.loginToolStripMenuItem.Text = "Login";
            // 
            // loginPenggunaToolStripMenuItem
            // 
            this.loginPenggunaToolStripMenuItem.Name = "loginPenggunaToolStripMenuItem";
            this.loginPenggunaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.loginPenggunaToolStripMenuItem.Text = "Pengguna";
            this.loginPenggunaToolStripMenuItem.Click += new System.EventHandler(this.loginPenggunaToolStripMenuItem_Click);
            // 
            // loginEmployeeToolStripMenuItem
            // 
            this.loginEmployeeToolStripMenuItem.Name = "loginEmployeeToolStripMenuItem";
            this.loginEmployeeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.loginEmployeeToolStripMenuItem.Text = "Employee";
            this.loginEmployeeToolStripMenuItem.Click += new System.EventHandler(this.loginEmployeeToolStripMenuItem_Click);
            // 
            // buatAkunToolStripMenuItem
            // 
            this.buatAkunToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buatAkunPenggunaToolStripMenuItem});
            this.buatAkunToolStripMenuItem.Name = "buatAkunToolStripMenuItem";
            this.buatAkunToolStripMenuItem.Size = new System.Drawing.Size(74, 20);
            this.buatAkunToolStripMenuItem.Text = "Buat Akun";
            // 
            // buatAkunPenggunaToolStripMenuItem
            // 
            this.buatAkunPenggunaToolStripMenuItem.Name = "buatAkunPenggunaToolStripMenuItem";
            this.buatAkunPenggunaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.buatAkunPenggunaToolStripMenuItem.Text = "Pengguna";
            this.buatAkunPenggunaToolStripMenuItem.Click += new System.EventHandler(this.buatAkunPenggunaToolStripMenuItem_Click);
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 200);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormLogin";
            this.Text = "FormLogin";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem loginToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loginPenggunaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loginEmployeeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buatAkunToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buatAkunPenggunaToolStripMenuItem;
    }
}