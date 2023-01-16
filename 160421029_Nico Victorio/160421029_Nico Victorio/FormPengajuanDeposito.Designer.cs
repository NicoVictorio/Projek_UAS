namespace _160421029_Nico_Victorio
{
    partial class FormPengajuanDeposito
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPengajuanDeposito));
            this.btn_Exit = new System.Windows.Forms.Button();
            this.labelNomorRekening = new System.Windows.Forms.Label();
            this.labelEmail = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxJatuhTempo = new System.Windows.Forms.ComboBox();
            this.textBoxNominal = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radioButtonDeposito = new System.Windows.Forms.RadioButton();
            this.radioButtonTabungan = new System.Windows.Forms.RadioButton();
            this.checkBoxARO = new System.Windows.Forms.CheckBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonDetail = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Exit
            // 
            this.btn_Exit.BackColor = System.Drawing.Color.Bisque;
            this.btn_Exit.Location = new System.Drawing.Point(249, 281);
            this.btn_Exit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(70, 32);
            this.btn_Exit.TabIndex = 60;
            this.btn_Exit.Text = "Exit";
            this.btn_Exit.UseVisualStyleBackColor = false;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // labelNomorRekening
            // 
            this.labelNomorRekening.AutoSize = true;
            this.labelNomorRekening.Location = new System.Drawing.Point(122, 54);
            this.labelNomorRekening.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelNomorRekening.Name = "labelNomorRekening";
            this.labelNomorRekening.Size = new System.Drawing.Size(10, 13);
            this.labelNomorRekening.TabIndex = 12;
            this.labelNomorRekening.Text = "-";
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.Location = new System.Drawing.Point(122, 24);
            this.labelEmail.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(10, 13);
            this.labelEmail.TabIndex = 13;
            this.labelEmail.Text = "-";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(44, 118);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Nominal (Rp.):";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(50, 83);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Jatuh Tempo:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(84, 24);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Email:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 54);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nomor Rekening:";
            // 
            // comboBoxJatuhTempo
            // 
            this.comboBoxJatuhTempo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxJatuhTempo.FormattingEnabled = true;
            this.comboBoxJatuhTempo.Items.AddRange(new object[] {
            "1 bulan",
            "3 bulan",
            "6 bulan",
            "12 bulan",
            "24 bulan",
            "36 bulan"});
            this.comboBoxJatuhTempo.Location = new System.Drawing.Point(122, 80);
            this.comboBoxJatuhTempo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBoxJatuhTempo.Name = "comboBoxJatuhTempo";
            this.comboBoxJatuhTempo.Size = new System.Drawing.Size(160, 21);
            this.comboBoxJatuhTempo.TabIndex = 19;
            // 
            // textBoxNominal
            // 
            this.textBoxNominal.Location = new System.Drawing.Point(122, 115);
            this.textBoxNominal.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxNominal.Name = "textBoxNominal";
            this.textBoxNominal.Size = new System.Drawing.Size(160, 20);
            this.textBoxNominal.TabIndex = 20;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Bisque;
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.Controls.Add(this.radioButtonDeposito);
            this.panel1.Controls.Add(this.radioButtonTabungan);
            this.panel1.Controls.Add(this.checkBoxARO);
            this.panel1.Controls.Add(this.textBoxNominal);
            this.panel1.Controls.Add(this.comboBoxJatuhTempo);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.labelEmail);
            this.panel1.Controls.Add(this.labelNomorRekening);
            this.panel1.Location = new System.Drawing.Point(9, 10);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(310, 260);
            this.panel1.TabIndex = 20;
            // 
            // radioButtonDeposito
            // 
            this.radioButtonDeposito.AutoSize = true;
            this.radioButtonDeposito.Enabled = false;
            this.radioButtonDeposito.Location = new System.Drawing.Point(122, 225);
            this.radioButtonDeposito.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.radioButtonDeposito.Name = "radioButtonDeposito";
            this.radioButtonDeposito.Size = new System.Drawing.Size(133, 17);
            this.radioButtonDeposito.TabIndex = 23;
            this.radioButtonDeposito.Text = "Bunga masuk deposito";
            this.radioButtonDeposito.UseVisualStyleBackColor = true;
            // 
            // radioButtonTabungan
            // 
            this.radioButtonTabungan.AutoSize = true;
            this.radioButtonTabungan.Checked = true;
            this.radioButtonTabungan.Enabled = false;
            this.radioButtonTabungan.Location = new System.Drawing.Point(122, 193);
            this.radioButtonTabungan.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.radioButtonTabungan.Name = "radioButtonTabungan";
            this.radioButtonTabungan.Size = new System.Drawing.Size(138, 17);
            this.radioButtonTabungan.TabIndex = 22;
            this.radioButtonTabungan.TabStop = true;
            this.radioButtonTabungan.Text = "Bunga masuk tabungan";
            this.radioButtonTabungan.UseVisualStyleBackColor = true;
            // 
            // checkBoxARO
            // 
            this.checkBoxARO.AutoSize = true;
            this.checkBoxARO.Location = new System.Drawing.Point(122, 158);
            this.checkBoxARO.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.checkBoxARO.Name = "checkBoxARO";
            this.checkBoxARO.Size = new System.Drawing.Size(152, 17);
            this.checkBoxARO.TabIndex = 21;
            this.checkBoxARO.Text = "ARO (Automatic Roll Over)";
            this.checkBoxARO.UseVisualStyleBackColor = true;
            this.checkBoxARO.CheckedChanged += new System.EventHandler(this.checkBoxARO_CheckedChanged);
            // 
            // buttonAdd
            // 
            this.buttonAdd.BackColor = System.Drawing.Color.Bisque;
            this.buttonAdd.Location = new System.Drawing.Point(9, 281);
            this.buttonAdd.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(70, 32);
            this.buttonAdd.TabIndex = 61;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = false;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonDetail
            // 
            this.buttonDetail.BackColor = System.Drawing.Color.Bisque;
            this.buttonDetail.Location = new System.Drawing.Point(131, 281);
            this.buttonDetail.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonDetail.Name = "buttonDetail";
            this.buttonDetail.Size = new System.Drawing.Size(70, 32);
            this.buttonDetail.TabIndex = 62;
            this.buttonDetail.Text = "Detail";
            this.buttonDetail.UseVisualStyleBackColor = false;
            this.buttonDetail.Click += new System.EventHandler(this.buttonDetail_Click);
            // 
            // FormPengajuanDeposito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Linen;
            this.ClientSize = new System.Drawing.Size(333, 322);
            this.Controls.Add(this.buttonDetail);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.btn_Exit);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormPengajuanDeposito";
            this.Text = "Pengajuan Deposito";
            this.Load += new System.EventHandler(this.FormPengajuanDeposito_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btn_Exit;
        private System.Windows.Forms.Label labelNomorRekening;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxJatuhTempo;
        private System.Windows.Forms.TextBox textBoxNominal;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonDetail;
        private System.Windows.Forms.RadioButton radioButtonDeposito;
        private System.Windows.Forms.RadioButton radioButtonTabungan;
        private System.Windows.Forms.CheckBox checkBoxARO;
    }
}