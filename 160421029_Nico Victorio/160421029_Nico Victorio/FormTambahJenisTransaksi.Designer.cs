
namespace _160421029_Nico_Victorio
{
    partial class FormTambahJenisTransaksi
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
            this.tb_KodeJenisTransaksi = new System.Windows.Forms.TextBox();
            this.tb_NamaJenisTransaksi = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_Exit = new System.Windows.Forms.Button();
            this.btn_Add = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tb_KodeJenisTransaksi
            // 
            this.tb_KodeJenisTransaksi.BackColor = System.Drawing.SystemColors.Window;
            this.tb_KodeJenisTransaksi.Location = new System.Drawing.Point(131, 28);
            this.tb_KodeJenisTransaksi.Margin = new System.Windows.Forms.Padding(2);
            this.tb_KodeJenisTransaksi.Name = "tb_KodeJenisTransaksi";
            this.tb_KodeJenisTransaksi.Size = new System.Drawing.Size(146, 20);
            this.tb_KodeJenisTransaksi.TabIndex = 51;
            // 
            // tb_NamaJenisTransaksi
            // 
            this.tb_NamaJenisTransaksi.BackColor = System.Drawing.SystemColors.Window;
            this.tb_NamaJenisTransaksi.Location = new System.Drawing.Point(131, 67);
            this.tb_NamaJenisTransaksi.Margin = new System.Windows.Forms.Padding(2);
            this.tb_NamaJenisTransaksi.Name = "tb_NamaJenisTransaksi";
            this.tb_NamaJenisTransaksi.Size = new System.Drawing.Size(146, 20);
            this.tb_NamaJenisTransaksi.TabIndex = 52;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 70);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 13);
            this.label1.TabIndex = 50;
            this.label1.Text = "Nama Jenis Transaksi";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 28);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 13);
            this.label4.TabIndex = 49;
            this.label4.Text = "Kode Jenis Transaksi";
            // 
            // btn_Exit
            // 
            this.btn_Exit.BackColor = System.Drawing.SystemColors.Control;
            this.btn_Exit.Location = new System.Drawing.Point(203, 114);
            this.btn_Exit.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(66, 28);
            this.btn_Exit.TabIndex = 54;
            this.btn_Exit.Text = "Exit";
            this.btn_Exit.UseVisualStyleBackColor = false;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // btn_Add
            // 
            this.btn_Add.BackColor = System.Drawing.SystemColors.Control;
            this.btn_Add.Location = new System.Drawing.Point(22, 114);
            this.btn_Add.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(71, 32);
            this.btn_Add.TabIndex = 53;
            this.btn_Add.Text = "Add";
            this.btn_Add.UseVisualStyleBackColor = false;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // FormTambahJenisTransaksi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(295, 161);
            this.Controls.Add(this.btn_Exit);
            this.Controls.Add(this.btn_Add);
            this.Controls.Add(this.tb_KodeJenisTransaksi);
            this.Controls.Add(this.tb_NamaJenisTransaksi);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Name = "FormTambahJenisTransaksi";
            this.Text = "Tambah Jenis Transaksi";
            this.Load += new System.EventHandler(this.FormTambahJenisTransaksi_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_KodeJenisTransaksi;
        private System.Windows.Forms.TextBox tb_NamaJenisTransaksi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_Exit;
        private System.Windows.Forms.Button btn_Add;
    }
}