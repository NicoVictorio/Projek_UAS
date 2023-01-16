namespace _160421029_Nico_Victorio
{
    partial class FormDaftarAddressBook
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
            this.dgvListAddressBook = new System.Windows.Forms.DataGridView();
            this.tb_Kriteria = new System.Windows.Forms.TextBox();
            this.cb_Kriteria = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Add = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListAddressBook)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Exit
            // 
            this.btn_Exit.BackColor = System.Drawing.SystemColors.Control;
            this.btn_Exit.Location = new System.Drawing.Point(401, 308);
            this.btn_Exit.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(70, 32);
            this.btn_Exit.TabIndex = 52;
            this.btn_Exit.Text = "Exit";
            this.btn_Exit.UseVisualStyleBackColor = false;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // dgvListAddressBook
            // 
            this.dgvListAddressBook.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListAddressBook.Location = new System.Drawing.Point(26, 65);
            this.dgvListAddressBook.Margin = new System.Windows.Forms.Padding(2);
            this.dgvListAddressBook.Name = "dgvListAddressBook";
            this.dgvListAddressBook.RowHeadersWidth = 51;
            this.dgvListAddressBook.RowTemplate.Height = 24;
            this.dgvListAddressBook.Size = new System.Drawing.Size(445, 215);
            this.dgvListAddressBook.TabIndex = 50;
            this.dgvListAddressBook.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListAddressBook_CellContentClick);
            // 
            // tb_Kriteria
            // 
            this.tb_Kriteria.BackColor = System.Drawing.SystemColors.Window;
            this.tb_Kriteria.Location = new System.Drawing.Point(287, 26);
            this.tb_Kriteria.Margin = new System.Windows.Forms.Padding(2);
            this.tb_Kriteria.Name = "tb_Kriteria";
            this.tb_Kriteria.Size = new System.Drawing.Size(185, 20);
            this.tb_Kriteria.TabIndex = 48;
            this.tb_Kriteria.TextChanged += new System.EventHandler(this.tb_Kriteria_TextChanged);
            // 
            // cb_Kriteria
            // 
            this.cb_Kriteria.BackColor = System.Drawing.Color.Bisque;
            this.cb_Kriteria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Kriteria.FormattingEnabled = true;
            this.cb_Kriteria.Items.AddRange(new object[] {
            "Keterangan",
            "Nomor Rekening",
            "Pengguna"});
            this.cb_Kriteria.Location = new System.Drawing.Point(128, 26);
            this.cb_Kriteria.Margin = new System.Windows.Forms.Padding(2);
            this.cb_Kriteria.Name = "cb_Kriteria";
            this.cb_Kriteria.Size = new System.Drawing.Size(146, 21);
            this.cb_Kriteria.TabIndex = 47;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 26);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 46;
            this.label1.Text = "Kriteria Pencarian";
            // 
            // btn_Add
            // 
            this.btn_Add.BackColor = System.Drawing.SystemColors.Control;
            this.btn_Add.Location = new System.Drawing.Point(26, 308);
            this.btn_Add.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(71, 32);
            this.btn_Add.TabIndex = 60;
            this.btn_Add.Text = "Add";
            this.btn_Add.UseVisualStyleBackColor = false;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // FormDaftarAddressBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(500, 366);
            this.Controls.Add(this.btn_Add);
            this.Controls.Add(this.btn_Exit);
            this.Controls.Add(this.dgvListAddressBook);
            this.Controls.Add(this.tb_Kriteria);
            this.Controls.Add(this.cb_Kriteria);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormDaftarAddressBook";
            this.Text = "Daftar Address Book";
            this.Load += new System.EventHandler(this.FormDaftarAddressBook_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListAddressBook)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Exit;
        private System.Windows.Forms.DataGridView dgvListAddressBook;
        private System.Windows.Forms.TextBox tb_Kriteria;
        private System.Windows.Forms.ComboBox cb_Kriteria;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Add;
    }
}