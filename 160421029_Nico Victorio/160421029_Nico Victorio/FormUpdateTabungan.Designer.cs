namespace _160421029_Nico_Victorio
{
    partial class FormUpdateTabungan
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBoxSaldo = new System.Windows.Forms.TextBox();
            this.textBoxNoRek = new System.Windows.Forms.TextBox();
            this.textBoxKeterangan = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btn_update = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.comboBoxPengguna = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBoxVerifikator = new System.Windows.Forms.ComboBox();
            this.labelTglBuat = new System.Windows.Forms.Label();
            this.labelTglPerubahan = new System.Windows.Forms.Label();
            this.comboBoxStatus = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel1.Controls.Add(this.comboBoxStatus);
            this.panel1.Controls.Add(this.labelTglPerubahan);
            this.panel1.Controls.Add(this.labelTglBuat);
            this.panel1.Controls.Add(this.comboBoxVerifikator);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.comboBoxPengguna);
            this.panel1.Controls.Add(this.textBoxSaldo);
            this.panel1.Controls.Add(this.textBoxNoRek);
            this.panel1.Controls.Add(this.textBoxKeterangan);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(441, 402);
            this.panel1.TabIndex = 20;
            // 
            // textBoxSaldo
            // 
            this.textBoxSaldo.Location = new System.Drawing.Point(163, 99);
            this.textBoxSaldo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxSaldo.Name = "textBoxSaldo";
            this.textBoxSaldo.Size = new System.Drawing.Size(212, 22);
            this.textBoxSaldo.TabIndex = 60;
            // 
            // textBoxNoRek
            // 
            this.textBoxNoRek.Location = new System.Drawing.Point(163, 26);
            this.textBoxNoRek.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxNoRek.Name = "textBoxNoRek";
            this.textBoxNoRek.Size = new System.Drawing.Size(212, 22);
            this.textBoxNoRek.TabIndex = 58;
            // 
            // textBoxKeterangan
            // 
            this.textBoxKeterangan.Location = new System.Drawing.Point(163, 181);
            this.textBoxKeterangan.Multiline = true;
            this.textBoxKeterangan.Name = "textBoxKeterangan";
            this.textBoxKeterangan.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxKeterangan.Size = new System.Drawing.Size(212, 56);
            this.textBoxKeterangan.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nomor Rekening:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(111, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Saldo:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(110, 142);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Status:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(78, 181);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Keterangan:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(87, 351);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 16);
            this.label8.TabIndex = 11;
            this.label8.Text = "Verifikator:";
            // 
            // btn_update
            // 
            this.btn_update.Location = new System.Drawing.Point(12, 419);
            this.btn_update.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(95, 39);
            this.btn_update.TabIndex = 55;
            this.btn_update.Text = "Update";
            this.btn_update.UseVisualStyleBackColor = true;
            this.btn_update.Click += new System.EventHandler(this.btn_update_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.Location = new System.Drawing.Point(358, 419);
            this.buttonExit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(95, 39);
            this.buttonExit.TabIndex = 56;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // comboBoxPengguna
            // 
            this.comboBoxPengguna.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPengguna.FormattingEnabled = true;
            this.comboBoxPengguna.Location = new System.Drawing.Point(163, 61);
            this.comboBoxPengguna.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxPengguna.Name = "comboBoxPengguna";
            this.comboBoxPengguna.Size = new System.Drawing.Size(212, 24);
            this.comboBoxPengguna.TabIndex = 83;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(84, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 84;
            this.label2.Text = "Pengguna:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(66, 263);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 16);
            this.label6.TabIndex = 9;
            this.label6.Text = "Tanggal Buat:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(27, 307);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(130, 16);
            this.label7.TabIndex = 10;
            this.label7.Text = "Tanggal Perubahan:";
            // 
            // comboBoxVerifikator
            // 
            this.comboBoxVerifikator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxVerifikator.FormattingEnabled = true;
            this.comboBoxVerifikator.Location = new System.Drawing.Point(163, 348);
            this.comboBoxVerifikator.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxVerifikator.Name = "comboBoxVerifikator";
            this.comboBoxVerifikator.Size = new System.Drawing.Size(212, 24);
            this.comboBoxVerifikator.TabIndex = 85;
            // 
            // labelTglBuat
            // 
            this.labelTglBuat.AutoSize = true;
            this.labelTglBuat.Location = new System.Drawing.Point(160, 263);
            this.labelTglBuat.Name = "labelTglBuat";
            this.labelTglBuat.Size = new System.Drawing.Size(11, 16);
            this.labelTglBuat.TabIndex = 86;
            this.labelTglBuat.Text = "-";
            // 
            // labelTglPerubahan
            // 
            this.labelTglPerubahan.AutoSize = true;
            this.labelTglPerubahan.Location = new System.Drawing.Point(160, 307);
            this.labelTglPerubahan.Name = "labelTglPerubahan";
            this.labelTglPerubahan.Size = new System.Drawing.Size(11, 16);
            this.labelTglPerubahan.TabIndex = 87;
            this.labelTglPerubahan.Text = "-";
            // 
            // comboBoxStatus
            // 
            this.comboBoxStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStatus.FormattingEnabled = true;
            this.comboBoxStatus.Location = new System.Drawing.Point(163, 139);
            this.comboBoxStatus.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxStatus.Name = "comboBoxStatus";
            this.comboBoxStatus.Size = new System.Drawing.Size(212, 24);
            this.comboBoxStatus.TabIndex = 88;
            // 
            // FormUpdateTabungan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 469);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.btn_update);
            this.Controls.Add(this.panel1);
            this.Name = "FormUpdateTabungan";
            this.Text = "Update Tabungan";
            this.Load += new System.EventHandler(this.FormUpdateTabungan_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBoxKeterangan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btn_update;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.TextBox textBoxSaldo;
        private System.Windows.Forms.TextBox textBoxNoRek;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxPengguna;
        private System.Windows.Forms.Label labelTglPerubahan;
        private System.Windows.Forms.Label labelTglBuat;
        private System.Windows.Forms.ComboBox comboBoxVerifikator;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBoxStatus;
    }
}