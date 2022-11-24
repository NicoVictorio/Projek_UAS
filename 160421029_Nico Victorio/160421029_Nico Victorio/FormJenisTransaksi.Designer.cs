
namespace _160421029_Nico_Victorio
{
    partial class FormJenisTransaksi
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
            this.btn_Update = new System.Windows.Forms.Button();
            this.btn_Exit = new System.Windows.Forms.Button();
            this.btn_Add = new System.Windows.Forms.Button();
            this.dgvListJenisTransaksi = new System.Windows.Forms.DataGridView();
            this.btn_Search = new System.Windows.Forms.Button();
            this.tb_Kriteria = new System.Windows.Forms.TextBox();
            this.cb_Kriteria = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListJenisTransaksi)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Update
            // 
            this.btn_Update.Location = new System.Drawing.Point(262, 315);
            this.btn_Update.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_Update.Name = "btn_Update";
            this.btn_Update.Size = new System.Drawing.Size(71, 32);
            this.btn_Update.TabIndex = 31;
            this.btn_Update.Text = "Update";
            this.btn_Update.UseVisualStyleBackColor = true;
            this.btn_Update.Click += new System.EventHandler(this.btn_Update_Click);
            // 
            // btn_Exit
            // 
            this.btn_Exit.Location = new System.Drawing.Point(500, 315);
            this.btn_Exit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(70, 32);
            this.btn_Exit.TabIndex = 30;
            this.btn_Exit.Text = "Exit";
            this.btn_Exit.UseVisualStyleBackColor = true;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // btn_Add
            // 
            this.btn_Add.Location = new System.Drawing.Point(34, 315);
            this.btn_Add.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(71, 32);
            this.btn_Add.TabIndex = 29;
            this.btn_Add.Text = "Add";
            this.btn_Add.UseVisualStyleBackColor = true;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // dgvListJenisTransaksi
            // 
            this.dgvListJenisTransaksi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListJenisTransaksi.Location = new System.Drawing.Point(34, 72);
            this.dgvListJenisTransaksi.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvListJenisTransaksi.Name = "dgvListJenisTransaksi";
            this.dgvListJenisTransaksi.RowHeadersWidth = 51;
            this.dgvListJenisTransaksi.RowTemplate.Height = 24;
            this.dgvListJenisTransaksi.Size = new System.Drawing.Size(536, 215);
            this.dgvListJenisTransaksi.TabIndex = 28;
            this.dgvListJenisTransaksi.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListPosition_CellContentClick);
            // 
            // btn_Search
            // 
            this.btn_Search.Location = new System.Drawing.Point(492, 19);
            this.btn_Search.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(77, 34);
            this.btn_Search.TabIndex = 27;
            this.btn_Search.Text = "Search";
            this.btn_Search.UseVisualStyleBackColor = true;
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
            // 
            // tb_Kriteria
            // 
            this.tb_Kriteria.Location = new System.Drawing.Point(295, 33);
            this.tb_Kriteria.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tb_Kriteria.Name = "tb_Kriteria";
            this.tb_Kriteria.Size = new System.Drawing.Size(185, 20);
            this.tb_Kriteria.TabIndex = 26;
            this.tb_Kriteria.TextChanged += new System.EventHandler(this.tb_Kriteria_TextChanged);
            // 
            // cb_Kriteria
            // 
            this.cb_Kriteria.FormattingEnabled = true;
            this.cb_Kriteria.Items.AddRange(new object[] {
            "Id Jenis Transaksi",
            "Kode Transaksi",
            "Nama Transaksi"});
            this.cb_Kriteria.Location = new System.Drawing.Point(136, 33);
            this.cb_Kriteria.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cb_Kriteria.Name = "cb_Kriteria";
            this.cb_Kriteria.Size = new System.Drawing.Size(146, 21);
            this.cb_Kriteria.TabIndex = 25;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 33);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Kriteria Pencarian";
            // 
            // FormJenisTransaksi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.btn_Update);
            this.Controls.Add(this.btn_Exit);
            this.Controls.Add(this.btn_Add);
            this.Controls.Add(this.dgvListJenisTransaksi);
            this.Controls.Add(this.btn_Search);
            this.Controls.Add(this.tb_Kriteria);
            this.Controls.Add(this.cb_Kriteria);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormJenisTransaksi";
            this.Text = "FormJenisTransaksi";
            this.Load += new System.EventHandler(this.FormJenisTransaksi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListJenisTransaksi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Update;
        private System.Windows.Forms.Button btn_Exit;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.DataGridView dgvListJenisTransaksi;
        private System.Windows.Forms.Button btn_Search;
        private System.Windows.Forms.TextBox tb_Kriteria;
        private System.Windows.Forms.ComboBox cb_Kriteria;
        private System.Windows.Forms.Label label1;
    }
}