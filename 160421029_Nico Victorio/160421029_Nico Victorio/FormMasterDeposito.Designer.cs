
namespace _160421029_Nico_Victorio
{
    partial class FormMasterDeposito
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
            this.dgvListDeposito = new System.Windows.Forms.DataGridView();
            this.tb_Kriteria = new System.Windows.Forms.TextBox();
            this.cb_Kriteria = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListDeposito)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Exit
            // 
            this.btn_Exit.Location = new System.Drawing.Point(292, 387);
            this.btn_Exit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(93, 39);
            this.btn_Exit.TabIndex = 52;
            this.btn_Exit.Text = "Exit";
            this.btn_Exit.UseVisualStyleBackColor = true;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // dgvListDeposito
            // 
            this.dgvListDeposito.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListDeposito.Location = new System.Drawing.Point(44, 88);
            this.dgvListDeposito.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvListDeposito.Name = "dgvListDeposito";
            this.dgvListDeposito.RowHeadersWidth = 51;
            this.dgvListDeposito.RowTemplate.Height = 24;
            this.dgvListDeposito.Size = new System.Drawing.Size(593, 265);
            this.dgvListDeposito.TabIndex = 50;
            // 
            // tb_Kriteria
            // 
            this.tb_Kriteria.Location = new System.Drawing.Point(392, 40);
            this.tb_Kriteria.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb_Kriteria.Name = "tb_Kriteria";
            this.tb_Kriteria.Size = new System.Drawing.Size(245, 22);
            this.tb_Kriteria.TabIndex = 48;
            this.tb_Kriteria.TextChanged += new System.EventHandler(this.tb_Kriteria_TextChanged);
            // 
            // cb_Kriteria
            // 
            this.cb_Kriteria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Kriteria.FormattingEnabled = true;
            this.cb_Kriteria.Items.AddRange(new object[] {
            "Id Deposito",
            "Nomor Rekening",
            "Nominal",
            "Status",
            "Tanggal Awal",
            "Tanggal Cair",
            "Verifikator Buka",
            "Verifikator Cair",
            "Id Bunga",
            "Aro",
            "Keterangan"});
            this.cb_Kriteria.Location = new System.Drawing.Point(180, 40);
            this.cb_Kriteria.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cb_Kriteria.Name = "cb_Kriteria";
            this.cb_Kriteria.Size = new System.Drawing.Size(193, 24);
            this.cb_Kriteria.TabIndex = 47;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 17);
            this.label1.TabIndex = 46;
            this.label1.Text = "Kriteria Pencarian";
            // 
            // FormMasterDeposito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 450);
            this.Controls.Add(this.btn_Exit);
            this.Controls.Add(this.dgvListDeposito);
            this.Controls.Add(this.tb_Kriteria);
            this.Controls.Add(this.cb_Kriteria);
            this.Controls.Add(this.label1);
            this.Name = "FormMasterDeposito";
            this.Text = "FormMasterDeposito";
            this.Load += new System.EventHandler(this.FormMasterDeposito_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListDeposito)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Exit;
        private System.Windows.Forms.DataGridView dgvListDeposito;
        private System.Windows.Forms.TextBox tb_Kriteria;
        private System.Windows.Forms.ComboBox cb_Kriteria;
        private System.Windows.Forms.Label label1;
    }
}