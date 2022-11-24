
namespace _160421029_Nico_Victorio
{
    partial class FormMasterPengguna
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
            this.dgvListPengguna = new System.Windows.Forms.DataGridView();
            this.btn_Search = new System.Windows.Forms.Button();
            this.tb_Kriteria = new System.Windows.Forms.TextBox();
            this.cb_Kriteria = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListPengguna)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Update
            // 
            this.btn_Update.Location = new System.Drawing.Point(275, 326);
            this.btn_Update.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Update.Name = "btn_Update";
            this.btn_Update.Size = new System.Drawing.Size(71, 32);
            this.btn_Update.TabIndex = 39;
            this.btn_Update.Text = "Update";
            this.btn_Update.UseVisualStyleBackColor = true;
            // 
            // btn_Exit
            // 
            this.btn_Exit.Location = new System.Drawing.Point(513, 326);
            this.btn_Exit.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(70, 32);
            this.btn_Exit.TabIndex = 38;
            this.btn_Exit.Text = "Exit";
            this.btn_Exit.UseVisualStyleBackColor = true;
            // 
            // btn_Add
            // 
            this.btn_Add.Location = new System.Drawing.Point(47, 326);
            this.btn_Add.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(71, 32);
            this.btn_Add.TabIndex = 37;
            this.btn_Add.Text = "Add";
            this.btn_Add.UseVisualStyleBackColor = true;
            // 
            // dgvListPengguna
            // 
            this.dgvListPengguna.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListPengguna.Location = new System.Drawing.Point(47, 83);
            this.dgvListPengguna.Margin = new System.Windows.Forms.Padding(2);
            this.dgvListPengguna.Name = "dgvListPengguna";
            this.dgvListPengguna.RowHeadersWidth = 51;
            this.dgvListPengguna.RowTemplate.Height = 24;
            this.dgvListPengguna.Size = new System.Drawing.Size(536, 215);
            this.dgvListPengguna.TabIndex = 36;
            // 
            // btn_Search
            // 
            this.btn_Search.Location = new System.Drawing.Point(505, 30);
            this.btn_Search.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(77, 34);
            this.btn_Search.TabIndex = 35;
            this.btn_Search.Text = "Search";
            this.btn_Search.UseVisualStyleBackColor = true;
            // 
            // tb_Kriteria
            // 
            this.tb_Kriteria.Location = new System.Drawing.Point(308, 44);
            this.tb_Kriteria.Margin = new System.Windows.Forms.Padding(2);
            this.tb_Kriteria.Name = "tb_Kriteria";
            this.tb_Kriteria.Size = new System.Drawing.Size(185, 20);
            this.tb_Kriteria.TabIndex = 34;
            this.tb_Kriteria.TextChanged += new System.EventHandler(this.tb_Kriteria_TextChanged);
            // 
            // cb_Kriteria
            // 
            this.cb_Kriteria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Kriteria.FormattingEnabled = true;
            this.cb_Kriteria.Items.AddRange(new object[] {
            "NIK",
            "Nama Depan",
            "Nama Keluarga",
            "Alamat",
            "Email",
            "No Telepon",
            "Password",
            "Pin",
            "Tanggal Buat",
            "Tanggal Perubahan",
            "Kode Pangkat"});
            this.cb_Kriteria.Location = new System.Drawing.Point(149, 44);
            this.cb_Kriteria.Margin = new System.Windows.Forms.Padding(2);
            this.cb_Kriteria.Name = "cb_Kriteria";
            this.cb_Kriteria.Size = new System.Drawing.Size(146, 21);
            this.cb_Kriteria.TabIndex = 33;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 44);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 32;
            this.label1.Text = "Kriteria Pencarian";
            // 
            // FormMasterPengguna
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 395);
            this.Controls.Add(this.btn_Update);
            this.Controls.Add(this.btn_Exit);
            this.Controls.Add(this.btn_Add);
            this.Controls.Add(this.dgvListPengguna);
            this.Controls.Add(this.btn_Search);
            this.Controls.Add(this.tb_Kriteria);
            this.Controls.Add(this.cb_Kriteria);
            this.Controls.Add(this.label1);
            this.Name = "FormMasterPengguna";
            this.Text = "FormMasterPengguna";
            this.Load += new System.EventHandler(this.FormMasterPengguna_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListPengguna)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Update;
        private System.Windows.Forms.Button btn_Exit;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.DataGridView dgvListPengguna;
        private System.Windows.Forms.Button btn_Search;
        private System.Windows.Forms.TextBox tb_Kriteria;
        private System.Windows.Forms.ComboBox cb_Kriteria;
        private System.Windows.Forms.Label label1;
    }
}