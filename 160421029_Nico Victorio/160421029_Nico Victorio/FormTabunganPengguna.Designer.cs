﻿
namespace _160421029_Nico_Victorio
{
    partial class FormTabunganPengguna
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelNomorRekening = new System.Windows.Forms.Label();
            this.labelSaldo = new System.Windows.Forms.Label();
            this.buttonExit = new System.Windows.Forms.Button();
            this.labelPangkat = new System.Windows.Forms.Label();
            this.labelPoin = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nomor Rekening: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Saldo: ";
            // 
            // labelNomorRekening
            // 
            this.labelNomorRekening.AutoSize = true;
            this.labelNomorRekening.Location = new System.Drawing.Point(201, 35);
            this.labelNomorRekening.Name = "labelNomorRekening";
            this.labelNomorRekening.Size = new System.Drawing.Size(46, 17);
            this.labelNomorRekening.TabIndex = 2;
            this.labelNomorRekening.Text = "label3";
            // 
            // labelSaldo
            // 
            this.labelSaldo.AutoSize = true;
            this.labelSaldo.Location = new System.Drawing.Point(201, 78);
            this.labelSaldo.Name = "labelSaldo";
            this.labelSaldo.Size = new System.Drawing.Size(46, 17);
            this.labelSaldo.TabIndex = 3;
            this.labelSaldo.Text = "label4";
            // 
            // buttonExit
            // 
            this.buttonExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExit.Location = new System.Drawing.Point(145, 209);
            this.buttonExit.Margin = new System.Windows.Forms.Padding(4);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(90, 37);
            this.buttonExit.TabIndex = 84;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // labelPangkat
            // 
            this.labelPangkat.AutoSize = true;
            this.labelPangkat.Location = new System.Drawing.Point(201, 162);
            this.labelPangkat.Name = "labelPangkat";
            this.labelPangkat.Size = new System.Drawing.Size(46, 17);
            this.labelPangkat.TabIndex = 88;
            this.labelPangkat.Text = "label4";
            // 
            // labelPoin
            // 
            this.labelPoin.AutoSize = true;
            this.labelPoin.Location = new System.Drawing.Point(201, 119);
            this.labelPoin.Name = "labelPoin";
            this.labelPoin.Size = new System.Drawing.Size(46, 17);
            this.labelPoin.TabIndex = 87;
            this.labelPoin.Text = "label3";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 163);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 17);
            this.label5.TabIndex = 86;
            this.label5.Text = "Pangkat:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(29, 119);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 17);
            this.label6.TabIndex = 85;
            this.label6.Text = "Poin:";
            // 
            // FormTabunganPengguna
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 259);
            this.Controls.Add(this.labelPangkat);
            this.Controls.Add(this.labelPoin);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.labelSaldo);
            this.Controls.Add(this.labelNomorRekening);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormTabunganPengguna";
            this.Text = "FormTabunganPengguna";
            this.Load += new System.EventHandler(this.FormTabunganPengguna_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelNomorRekening;
        private System.Windows.Forms.Label labelSaldo;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Label labelPangkat;
        private System.Windows.Forms.Label labelPoin;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}