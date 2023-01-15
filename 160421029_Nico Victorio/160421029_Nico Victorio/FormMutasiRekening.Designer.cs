
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
            this.textBoxNomorRekening = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonSend = new System.Windows.Forms.Button();
            this.comboBoxJenisTransaksi = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePickerTanggalAwal = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerTanggalAkhir = new System.Windows.Forms.DateTimePicker();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Exit
            // 
            this.btn_Exit.Location = new System.Drawing.Point(357, 276);
            this.btn_Exit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(93, 39);
            this.btn_Exit.TabIndex = 65;
            this.btn_Exit.Text = "Exit";
            this.btn_Exit.UseVisualStyleBackColor = true;
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
            this.panel1.Location = new System.Drawing.Point(37, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(413, 214);
            this.panel1.TabIndex = 64;
            // 
            // textBoxNomorRekening
            // 
            this.textBoxNomorRekening.Enabled = false;
            this.textBoxNomorRekening.Location = new System.Drawing.Point(178, 22);
            this.textBoxNomorRekening.Name = "textBoxNomorRekening";
            this.textBoxNomorRekening.Size = new System.Drawing.Size(212, 22);
            this.textBoxNomorRekening.TabIndex = 28;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 17);
            this.label1.TabIndex = 27;
            this.label1.Text = "Nomor Rekening:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Jenis Transaksi:";
            // 
            // buttonSend
            // 
            this.buttonSend.Location = new System.Drawing.Point(37, 276);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(91, 39);
            this.buttonSend.TabIndex = 66;
            this.buttonSend.Text = "Send";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // comboBoxJenisTransaksi
            // 
            this.comboBoxJenisTransaksi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxJenisTransaksi.FormattingEnabled = true;
            this.comboBoxJenisTransaksi.Items.AddRange(new object[] {
            "Semua",
            "Pemasukan",
            "Pengeluaran"});
            this.comboBoxJenisTransaksi.Location = new System.Drawing.Point(178, 65);
            this.comboBoxJenisTransaksi.Name = "comboBoxJenisTransaksi";
            this.comboBoxJenisTransaksi.Size = new System.Drawing.Size(212, 24);
            this.comboBoxJenisTransaksi.TabIndex = 29;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 17);
            this.label2.TabIndex = 30;
            this.label2.Text = "Dari Tanggal: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 161);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 17);
            this.label3.TabIndex = 31;
            this.label3.Text = "Sampai Tanggal: ";
            // 
            // dateTimePickerTanggalAwal
            // 
            this.dateTimePickerTanggalAwal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerTanggalAwal.Location = new System.Drawing.Point(178, 117);
            this.dateTimePickerTanggalAwal.Name = "dateTimePickerTanggalAwal";
            this.dateTimePickerTanggalAwal.Size = new System.Drawing.Size(212, 22);
            this.dateTimePickerTanggalAwal.TabIndex = 32;
            // 
            // dateTimePickerTanggalAkhir
            // 
            this.dateTimePickerTanggalAkhir.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerTanggalAkhir.Location = new System.Drawing.Point(178, 161);
            this.dateTimePickerTanggalAkhir.Name = "dateTimePickerTanggalAkhir";
            this.dateTimePickerTanggalAkhir.Size = new System.Drawing.Size(212, 22);
            this.dateTimePickerTanggalAkhir.TabIndex = 33;
            // 
            // FormMutasiRekening
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 339);
            this.Controls.Add(this.btn_Exit);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonSend);
            this.Name = "FormMutasiRekening";
            this.Text = "FormMutasiRekening";
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