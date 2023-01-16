
namespace _160421029_Nico_Victorio
{
    partial class FormMutasiRekening
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
            this.dateTimePickerTanggalAkhir = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerTanggalAwal = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxJenisTransaksi = new System.Windows.Forms.ComboBox();
            this.textBoxNomorRekening = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonSend = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Exit
            // 
            this.btn_Exit.BackColor = System.Drawing.SystemColors.Control;
            this.btn_Exit.Location = new System.Drawing.Point(268, 224);
            this.btn_Exit.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(70, 32);
            this.btn_Exit.TabIndex = 65;
            this.btn_Exit.Text = "Exit";
            this.btn_Exit.UseVisualStyleBackColor = false;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel1.Controls.Add(this.dateTimePickerTanggalAkhir);
            this.panel1.Controls.Add(this.dateTimePickerTanggalAwal);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.comboBoxJenisTransaksi);
            this.panel1.Controls.Add(this.textBoxNomorRekening);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(28, 24);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(310, 174);
            this.panel1.TabIndex = 64;
            // 
            // dateTimePickerTanggalAkhir
            // 
            this.dateTimePickerTanggalAkhir.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerTanggalAkhir.Location = new System.Drawing.Point(134, 131);
            this.dateTimePickerTanggalAkhir.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePickerTanggalAkhir.Name = "dateTimePickerTanggalAkhir";
            this.dateTimePickerTanggalAkhir.Size = new System.Drawing.Size(160, 20);
            this.dateTimePickerTanggalAkhir.TabIndex = 33;
            // 
            // dateTimePickerTanggalAwal
            // 
            this.dateTimePickerTanggalAwal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerTanggalAwal.Location = new System.Drawing.Point(134, 95);
            this.dateTimePickerTanggalAwal.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePickerTanggalAwal.Name = "dateTimePickerTanggalAwal";
            this.dateTimePickerTanggalAwal.Size = new System.Drawing.Size(160, 20);
            this.dateTimePickerTanggalAwal.TabIndex = 32;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 131);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 31;
            this.label3.Text = "Sampai Tanggal: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 95);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 30;
            this.label2.Text = "Dari Tanggal: ";
            // 
            // comboBoxJenisTransaksi
            // 
            this.comboBoxJenisTransaksi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxJenisTransaksi.FormattingEnabled = true;
            this.comboBoxJenisTransaksi.Items.AddRange(new object[] {
            "Semua",
            "Pemasukan",
            "Pengeluaran"});
            this.comboBoxJenisTransaksi.Location = new System.Drawing.Point(134, 53);
            this.comboBoxJenisTransaksi.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxJenisTransaksi.Name = "comboBoxJenisTransaksi";
            this.comboBoxJenisTransaksi.Size = new System.Drawing.Size(160, 21);
            this.comboBoxJenisTransaksi.TabIndex = 29;
            // 
            // textBoxNomorRekening
            // 
            this.textBoxNomorRekening.Enabled = false;
            this.textBoxNomorRekening.Location = new System.Drawing.Point(134, 18);
            this.textBoxNomorRekening.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxNomorRekening.Name = "textBoxNomorRekening";
            this.textBoxNomorRekening.Size = new System.Drawing.Size(160, 20);
            this.textBoxNomorRekening.TabIndex = 28;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "Nomor Rekening:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 55);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Jenis Transaksi:";
            // 
            // buttonSend
            // 
            this.buttonSend.BackColor = System.Drawing.SystemColors.Control;
            this.buttonSend.Location = new System.Drawing.Point(28, 224);
            this.buttonSend.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(68, 32);
            this.buttonSend.TabIndex = 66;
            this.buttonSend.Text = "Send";
            this.buttonSend.UseVisualStyleBackColor = false;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // FormMutasiRekening
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(364, 275);
            this.Controls.Add(this.btn_Exit);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonSend);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormMutasiRekening";
            this.Text = "Cek Mutasi Rekening";
            this.Load += new System.EventHandler(this.FormMutasiRekening_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Exit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBoxNomorRekening;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.ComboBox comboBoxJenisTransaksi;
        private System.Windows.Forms.DateTimePicker dateTimePickerTanggalAkhir;
        private System.Windows.Forms.DateTimePicker dateTimePickerTanggalAwal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}