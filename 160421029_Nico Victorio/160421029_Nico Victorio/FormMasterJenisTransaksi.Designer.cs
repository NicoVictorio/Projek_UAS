
namespace _160421029_Nico_Victorio
{
    partial class FormMasterJenisTransaksi
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
            this.btn_Add = new System.Windows.Forms.Button();
            this.dgvListJenisTransaksi = new System.Windows.Forms.DataGridView();
            this.tb_Kriteria = new System.Windows.Forms.TextBox();
            this.cb_Kriteria = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListJenisTransaksi)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Exit
            // 
            this.btn_Exit.Location = new System.Drawing.Point(545, 388);
            this.btn_Exit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(93, 39);
            this.btn_Exit.TabIndex = 30;
            this.btn_Exit.Text = "Exit";
            this.btn_Exit.UseVisualStyleBackColor = true;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // btn_Add
            // 
            this.btn_Add.Location = new System.Drawing.Point(45, 388);
            this.btn_Add.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(95, 39);
            this.btn_Add.TabIndex = 29;
            this.btn_Add.Text = "Add";
            this.btn_Add.UseVisualStyleBackColor = true;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // dgvListJenisTransaksi
            // 
            this.dgvListJenisTransaksi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListJenisTransaksi.Location = new System.Drawing.Point(45, 89);
            this.dgvListJenisTransaksi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvListJenisTransaksi.Name = "dgvListJenisTransaksi";
            this.dgvListJenisTransaksi.RowHeadersWidth = 51;
            this.dgvListJenisTransaksi.RowTemplate.Height = 24;
            this.dgvListJenisTransaksi.Size = new System.Drawing.Size(593, 265);
            this.dgvListJenisTransaksi.TabIndex = 28;
            this.dgvListJenisTransaksi.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListPosition_CellContentClick);
            // 
            // tb_Kriteria
            // 
            this.tb_Kriteria.Location = new System.Drawing.Point(393, 41);
            this.tb_Kriteria.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb_Kriteria.Name = "tb_Kriteria";
            this.tb_Kriteria.Size = new System.Drawing.Size(245, 22);
            this.tb_Kriteria.TabIndex = 26;
            this.tb_Kriteria.TextChanged += new System.EventHandler(this.tb_Kriteria_TextChanged);
            // 
            // cb_Kriteria
            // 
            this.cb_Kriteria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Kriteria.FormattingEnabled = true;
            this.cb_Kriteria.Items.AddRange(new object[] {
            "Id Jenis Transaksi",
            "Kode Transaksi",
            "Nama Transaksi"});
            this.cb_Kriteria.Location = new System.Drawing.Point(181, 41);
            this.cb_Kriteria.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cb_Kriteria.Name = "cb_Kriteria";
            this.cb_Kriteria.Size = new System.Drawing.Size(193, 24);
            this.cb_Kriteria.TabIndex = 25;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 17);
            this.label1.TabIndex = 24;
            this.label1.Text = "Kriteria Pencarian";
            // 
            // FormMasterJenisTransaksi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 450);
            this.Controls.Add(this.btn_Exit);
            this.Controls.Add(this.btn_Add);
            this.Controls.Add(this.dgvListJenisTransaksi);
            this.Controls.Add(this.tb_Kriteria);
            this.Controls.Add(this.cb_Kriteria);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormMasterJenisTransaksi";
            this.Text = "FormJenisTransaksi";
            this.Load += new System.EventHandler(this.FormJenisTransaksi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListJenisTransaksi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_Exit;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.DataGridView dgvListJenisTransaksi;
        private System.Windows.Forms.TextBox tb_Kriteria;
        private System.Windows.Forms.ComboBox cb_Kriteria;
        private System.Windows.Forms.Label label1;
    }
}