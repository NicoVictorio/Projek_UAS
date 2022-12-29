namespace _160421029_Nico_Victorio
{
    partial class FormTambahTransaksi
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
            this.btn_Exit = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBoxRekeningAsal = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonCariRekening = new System.Windows.Forms.Button();
            this.textBoxRekeningTujuan = new System.Windows.Forms.TextBox();
            this.textBoxKeterangan = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxNominal = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonSubmit = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Exit
            // 
            this.btn_Exit.Location = new System.Drawing.Point(331, 305);
            this.btn_Exit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(93, 39);
            this.btn_Exit.TabIndex = 62;
            this.btn_Exit.Text = "Exit";
            this.btn_Exit.UseVisualStyleBackColor = true;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel1.Controls.Add(this.textBoxRekeningAsal);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.buttonCariRekening);
            this.panel1.Controls.Add(this.textBoxRekeningTujuan);
            this.panel1.Controls.Add(this.textBoxKeterangan);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.textBoxNominal);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(413, 278);
            this.panel1.TabIndex = 61;
            // 
            // textBoxRekeningAsal
            // 
            this.textBoxRekeningAsal.Location = new System.Drawing.Point(178, 22);
            this.textBoxRekeningAsal.Name = "textBoxRekeningAsal";
            this.textBoxRekeningAsal.Size = new System.Drawing.Size(212, 22);
            this.textBoxRekeningAsal.TabIndex = 28;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 17);
            this.label1.TabIndex = 27;
            this.label1.Text = "Rekening Asal:";
            // 
            // buttonCariRekening
            // 
            this.buttonCariRekening.Location = new System.Drawing.Point(178, 108);
            this.buttonCariRekening.Name = "buttonCariRekening";
            this.buttonCariRekening.Size = new System.Drawing.Size(212, 34);
            this.buttonCariRekening.TabIndex = 26;
            this.buttonCariRekening.Text = "Cari Rekening Tujuan";
            this.buttonCariRekening.UseVisualStyleBackColor = true;
            this.buttonCariRekening.Click += new System.EventHandler(this.buttonCariRekening_Click);
            // 
            // textBoxRekeningTujuan
            // 
            this.textBoxRekeningTujuan.Location = new System.Drawing.Point(178, 68);
            this.textBoxRekeningTujuan.Name = "textBoxRekeningTujuan";
            this.textBoxRekeningTujuan.Size = new System.Drawing.Size(212, 22);
            this.textBoxRekeningTujuan.TabIndex = 25;
            // 
            // textBoxKeterangan
            // 
            this.textBoxKeterangan.Location = new System.Drawing.Point(178, 198);
            this.textBoxKeterangan.Multiline = true;
            this.textBoxKeterangan.Name = "textBoxKeterangan";
            this.textBoxKeterangan.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxKeterangan.Size = new System.Drawing.Size(212, 56);
            this.textBoxKeterangan.TabIndex = 24;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(76, 198);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(86, 17);
            this.label10.TabIndex = 23;
            this.label10.Text = "Keterangan:";
            // 
            // textBoxNominal
            // 
            this.textBoxNominal.Location = new System.Drawing.Point(178, 159);
            this.textBoxNominal.Name = "textBoxNominal";
            this.textBoxNominal.Size = new System.Drawing.Size(212, 22);
            this.textBoxNominal.TabIndex = 22;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(95, 162);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 17);
            this.label9.TabIndex = 21;
            this.label9.Text = "Nominal:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(43, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Rekening Tujuan:";
            // 
            // buttonSubmit
            // 
            this.buttonSubmit.Location = new System.Drawing.Point(12, 305);
            this.buttonSubmit.Name = "buttonSubmit";
            this.buttonSubmit.Size = new System.Drawing.Size(91, 39);
            this.buttonSubmit.TabIndex = 63;
            this.buttonSubmit.Text = "Submit";
            this.buttonSubmit.UseVisualStyleBackColor = true;
            this.buttonSubmit.Click += new System.EventHandler(this.buttonSubmit_Click);
            // 
            // FormTambahTransaksi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 359);
            this.Controls.Add(this.buttonSubmit);
            this.Controls.Add(this.btn_Exit);
            this.Controls.Add(this.panel1);
            this.Name = "FormTambahTransaksi";
            this.Text = "Transaksi";
            this.Load += new System.EventHandler(this.FormTransaksi_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Exit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBoxNominal;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxKeterangan;
        private System.Windows.Forms.Button buttonSubmit;
        private System.Windows.Forms.TextBox textBoxRekeningAsal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonCariRekening;
        private System.Windows.Forms.TextBox textBoxRekeningTujuan;
    }
}