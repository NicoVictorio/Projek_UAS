﻿namespace _160421029_Nico_Victorio
{
    partial class FormDaftarTabungan
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
            this.dgvListTabungan = new System.Windows.Forms.DataGridView();
            this.btn_Search = new System.Windows.Forms.Button();
            this.tb_Kriteria = new System.Windows.Forms.TextBox();
            this.cb_Kriteria = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListTabungan)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Exit
            // 
            this.btn_Exit.BackColor = System.Drawing.SystemColors.Control;
            this.btn_Exit.Location = new System.Drawing.Point(254, 310);
            this.btn_Exit.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(70, 32);
            this.btn_Exit.TabIndex = 58;
            this.btn_Exit.Text = "Exit";
            this.btn_Exit.UseVisualStyleBackColor = false;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // dgvListTabungan
            // 
            this.dgvListTabungan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListTabungan.Location = new System.Drawing.Point(31, 68);
            this.dgvListTabungan.Margin = new System.Windows.Forms.Padding(2);
            this.dgvListTabungan.Name = "dgvListTabungan";
            this.dgvListTabungan.RowHeadersWidth = 51;
            this.dgvListTabungan.RowTemplate.Height = 24;
            this.dgvListTabungan.Size = new System.Drawing.Size(536, 215);
            this.dgvListTabungan.TabIndex = 57;
            this.dgvListTabungan.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListTabungan_CellContentClick);
            // 
            // btn_Search
            // 
            this.btn_Search.BackColor = System.Drawing.SystemColors.Control;
            this.btn_Search.Location = new System.Drawing.Point(488, 16);
            this.btn_Search.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(77, 34);
            this.btn_Search.TabIndex = 56;
            this.btn_Search.Text = "Search";
            this.btn_Search.UseVisualStyleBackColor = false;
            // 
            // tb_Kriteria
            // 
            this.tb_Kriteria.BackColor = System.Drawing.SystemColors.Window;
            this.tb_Kriteria.Location = new System.Drawing.Point(292, 29);
            this.tb_Kriteria.Margin = new System.Windows.Forms.Padding(2);
            this.tb_Kriteria.Name = "tb_Kriteria";
            this.tb_Kriteria.Size = new System.Drawing.Size(185, 20);
            this.tb_Kriteria.TabIndex = 55;
            this.tb_Kriteria.TextChanged += new System.EventHandler(this.tb_Kriteria_TextChanged);
            // 
            // cb_Kriteria
            // 
            this.cb_Kriteria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Kriteria.FormattingEnabled = true;
            this.cb_Kriteria.Items.AddRange(new object[] {
            "No Rekening",
            "Id Pengguna",
            "Saldo",
            "Status",
            "Keterangan",
            "Tanggal Buat",
            "Tanggal Perubahan",
            "Verifikator"});
            this.cb_Kriteria.Location = new System.Drawing.Point(133, 29);
            this.cb_Kriteria.Margin = new System.Windows.Forms.Padding(2);
            this.cb_Kriteria.Name = "cb_Kriteria";
            this.cb_Kriteria.Size = new System.Drawing.Size(146, 21);
            this.cb_Kriteria.TabIndex = 54;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 29);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 53;
            this.label1.Text = "Kriteria Pencarian";
            // 
            // FormDaftarTabungan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.btn_Exit);
            this.Controls.Add(this.dgvListTabungan);
            this.Controls.Add(this.btn_Search);
            this.Controls.Add(this.tb_Kriteria);
            this.Controls.Add(this.cb_Kriteria);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormDaftarTabungan";
            this.Text = "Daftar Tabungan";
            this.Load += new System.EventHandler(this.FormDaftarTabungan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListTabungan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Exit;
        private System.Windows.Forms.DataGridView dgvListTabungan;
        private System.Windows.Forms.Button btn_Search;
        private System.Windows.Forms.TextBox tb_Kriteria;
        private System.Windows.Forms.ComboBox cb_Kriteria;
        private System.Windows.Forms.Label label1;
    }
}