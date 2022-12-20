
namespace _160421029_Nico_Victorio
{
    partial class FormTambahDeposito
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
            this.textBoxBunga = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxNominal = new System.Windows.Forms.TextBox();
            this.comboBoxJatuhTempo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.comboBoxNomorRekening = new System.Windows.Forms.ComboBox();
            this.comboBoxVerifikatorBuka = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBoxVerifikatorCair = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxBunga
            // 
            this.textBoxBunga.Location = new System.Drawing.Point(164, 145);
            this.textBoxBunga.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxBunga.Name = "textBoxBunga";
            this.textBoxBunga.Size = new System.Drawing.Size(212, 22);
            this.textBoxBunga.TabIndex = 29;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(108, 149);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 17);
            this.label9.TabIndex = 28;
            this.label9.Text = "Bunga:";
            // 
            // textBoxNominal
            // 
            this.textBoxNominal.Location = new System.Drawing.Point(164, 108);
            this.textBoxNominal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxNominal.Name = "textBoxNominal";
            this.textBoxNominal.Size = new System.Drawing.Size(212, 22);
            this.textBoxNominal.TabIndex = 27;
            // 
            // comboBoxJatuhTempo
            // 
            this.comboBoxJatuhTempo.AutoCompleteCustomSource.AddRange(new string[] {
            "1 bulan",
            "3 bulan",
            "6 bulan",
            "1 tahun",
            "2 tahun",
            "3 tahun"});
            this.comboBoxJatuhTempo.FormattingEnabled = true;
            this.comboBoxJatuhTempo.Items.AddRange(new object[] {
            "1 bulan",
            "3 bulan",
            "6 bulan",
            "1 tahun",
            "2 tahun",
            "3 tahun"});
            this.comboBoxJatuhTempo.Location = new System.Drawing.Point(164, 65);
            this.comboBoxJatuhTempo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxJatuhTempo.Name = "comboBoxJatuhTempo";
            this.comboBoxJatuhTempo.Size = new System.Drawing.Size(212, 24);
            this.comboBoxJatuhTempo.TabIndex = 26;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 17);
            this.label1.TabIndex = 23;
            this.label1.Text = "Nomor Rekening:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(68, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 17);
            this.label3.TabIndex = 24;
            this.label3.Text = "Jatuh Tempo:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(96, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 17);
            this.label4.TabIndex = 25;
            this.label4.Text = "Nominal:";
            // 
            // buttonExit
            // 
            this.buttonExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExit.Location = new System.Drawing.Point(224, 311);
            this.buttonExit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(152, 32);
            this.buttonExit.TabIndex = 71;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = true;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAdd.Location = new System.Drawing.Point(43, 311);
            this.buttonAdd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(152, 32);
            this.buttonAdd.TabIndex = 70;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // comboBoxNomorRekening
            // 
            this.comboBoxNomorRekening.FormattingEnabled = true;
            this.comboBoxNomorRekening.Location = new System.Drawing.Point(164, 30);
            this.comboBoxNomorRekening.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxNomorRekening.Name = "comboBoxNomorRekening";
            this.comboBoxNomorRekening.Size = new System.Drawing.Size(212, 24);
            this.comboBoxNomorRekening.TabIndex = 72;
            // 
            // comboBoxVerifikatorBuka
            // 
            this.comboBoxVerifikatorBuka.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxVerifikatorBuka.FormattingEnabled = true;
            this.comboBoxVerifikatorBuka.Location = new System.Drawing.Point(164, 194);
            this.comboBoxVerifikatorBuka.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBoxVerifikatorBuka.Name = "comboBoxVerifikatorBuka";
            this.comboBoxVerifikatorBuka.Size = new System.Drawing.Size(212, 24);
            this.comboBoxVerifikatorBuka.TabIndex = 96;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(40, 198);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(112, 17);
            this.label8.TabIndex = 95;
            this.label8.Text = "Verifikator Buka:";
            // 
            // comboBoxVerifikatorCair
            // 
            this.comboBoxVerifikatorCair.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxVerifikatorCair.FormattingEnabled = true;
            this.comboBoxVerifikatorCair.Location = new System.Drawing.Point(164, 240);
            this.comboBoxVerifikatorCair.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBoxVerifikatorCair.Name = "comboBoxVerifikatorCair";
            this.comboBoxVerifikatorCair.Size = new System.Drawing.Size(212, 24);
            this.comboBoxVerifikatorCair.TabIndex = 98;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 244);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 17);
            this.label2.TabIndex = 97;
            this.label2.Text = "Verifikator Cair:";
            // 
            // FormTambahDeposito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 375);
            this.Controls.Add(this.comboBoxVerifikatorCair);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxVerifikatorBuka);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.comboBoxNomorRekening);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.textBoxBunga);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBoxNominal);
            this.Controls.Add(this.comboBoxJatuhTempo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormTambahDeposito";
            this.Text = "FormTambahDeposito";
            this.Load += new System.EventHandler(this.FormTambahDeposito_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxBunga;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxNominal;
        private System.Windows.Forms.ComboBox comboBoxJatuhTempo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.ComboBox comboBoxNomorRekening;
        private System.Windows.Forms.ComboBox comboBoxVerifikatorBuka;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBoxVerifikatorCair;
        private System.Windows.Forms.Label label2;
    }
}