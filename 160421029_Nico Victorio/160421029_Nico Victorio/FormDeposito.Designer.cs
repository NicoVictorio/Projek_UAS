namespace _160421029_Nico_Victorio
{
    partial class FormDeposito
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
            this.LabelNomorRekening = new System.Windows.Forms.Label();
            this.labelId = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxJatuhTempo = new System.Windows.Forms.ComboBox();
            this.textBoxNominal = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Status = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxBunga = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Exit
            // 
            this.btn_Exit.Location = new System.Drawing.Point(162, 312);
            this.btn_Exit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(93, 39);
            this.btn_Exit.TabIndex = 60;
            this.btn_Exit.Text = "Exit";
            this.btn_Exit.UseVisualStyleBackColor = true;
            // 
            // LabelNomorRekening
            // 
            this.LabelNomorRekening.AutoSize = true;
            this.LabelNomorRekening.Location = new System.Drawing.Point(163, 66);
            this.LabelNomorRekening.Name = "LabelNomorRekening";
            this.LabelNomorRekening.Size = new System.Drawing.Size(13, 17);
            this.LabelNomorRekening.TabIndex = 12;
            this.LabelNomorRekening.Text = "-";
            // 
            // labelId
            // 
            this.labelId.AutoSize = true;
            this.labelId.Location = new System.Drawing.Point(163, 30);
            this.labelId.Name = "labelId";
            this.labelId.Size = new System.Drawing.Size(13, 17);
            this.labelId.TabIndex = 13;
            this.labelId.Text = "-";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(95, 142);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Nominal:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(67, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Jatuh Tempo:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(133, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "ID:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nomor Rekening:";
            // 
            // comboBoxJatuhTempo
            // 
            this.comboBoxJatuhTempo.FormattingEnabled = true;
            this.comboBoxJatuhTempo.Location = new System.Drawing.Point(163, 98);
            this.comboBoxJatuhTempo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxJatuhTempo.Name = "comboBoxJatuhTempo";
            this.comboBoxJatuhTempo.Size = new System.Drawing.Size(212, 24);
            this.comboBoxJatuhTempo.TabIndex = 19;
            this.comboBoxJatuhTempo.SelectedIndexChanged += new System.EventHandler(this.comboBoxJatuhTempo_SelectedIndexChanged);
            // 
            // textBoxNominal
            // 
            this.textBoxNominal.Location = new System.Drawing.Point(163, 142);
            this.textBoxNominal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxNominal.Name = "textBoxNominal";
            this.textBoxNominal.Size = new System.Drawing.Size(212, 22);
            this.textBoxNominal.TabIndex = 20;
            this.textBoxNominal.TextChanged += new System.EventHandler(this.textBoxNominal_TextChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel1.Controls.Add(this.Status);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.textBoxBunga);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.textBoxNominal);
            this.panel1.Controls.Add(this.comboBoxJatuhTempo);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.labelId);
            this.panel1.Controls.Add(this.LabelNomorRekening);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(413, 277);
            this.panel1.TabIndex = 20;
            // 
            // Status
            // 
            this.Status.AutoSize = true;
            this.Status.Location = new System.Drawing.Point(163, 224);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(13, 17);
            this.Status.TabIndex = 24;
            this.Status.Text = "-";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(108, 224);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 17);
            this.label10.TabIndex = 23;
            this.label10.Text = "Status:";
            // 
            // textBoxBunga
            // 
            this.textBoxBunga.Location = new System.Drawing.Point(163, 178);
            this.textBoxBunga.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxBunga.Name = "textBoxBunga";
            this.textBoxBunga.Size = new System.Drawing.Size(212, 22);
            this.textBoxBunga.TabIndex = 22;
            this.textBoxBunga.TextChanged += new System.EventHandler(this.textBoxBunga_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(107, 182);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 17);
            this.label9.TabIndex = 21;
            this.label9.Text = "Bunga:";
            // 
            // FormDeposito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 373);
            this.Controls.Add(this.btn_Exit);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormDeposito";
            this.Text = "Deposito";
            this.Load += new System.EventHandler(this.FormDeposito_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btn_Exit;
        private System.Windows.Forms.Label LabelNomorRekening;
        private System.Windows.Forms.Label labelId;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxJatuhTempo;
        private System.Windows.Forms.TextBox textBoxNominal;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label Status;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBoxBunga;
        private System.Windows.Forms.Label label9;
    }
}