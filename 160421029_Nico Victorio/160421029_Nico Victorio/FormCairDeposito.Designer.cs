
namespace _160421029_Nico_Victorio
{
    partial class FormCairDeposito
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
            this.labelNomorDeposito = new System.Windows.Forms.Label();
            this.labelTglPengajuanCair = new System.Windows.Forms.Label();
            this.buttonCair = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(110, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nomor Deposito:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(72, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tanggal Pengajuan Cair:";
            // 
            // labelNomorDeposito
            // 
            this.labelNomorDeposito.AutoSize = true;
            this.labelNomorDeposito.Location = new System.Drawing.Point(202, 32);
            this.labelNomorDeposito.Name = "labelNomorDeposito";
            this.labelNomorDeposito.Size = new System.Drawing.Size(10, 13);
            this.labelNomorDeposito.TabIndex = 2;
            this.labelNomorDeposito.Text = "-";
            // 
            // labelTglPengajuanCair
            // 
            this.labelTglPengajuanCair.AutoSize = true;
            this.labelTglPengajuanCair.Location = new System.Drawing.Point(202, 71);
            this.labelTglPengajuanCair.Name = "labelTglPengajuanCair";
            this.labelTglPengajuanCair.Size = new System.Drawing.Size(10, 13);
            this.labelTglPengajuanCair.TabIndex = 3;
            this.labelTglPengajuanCair.Text = "-";
            // 
            // buttonCair
            // 
            this.buttonCair.Location = new System.Drawing.Point(137, 125);
            this.buttonCair.Name = "buttonCair";
            this.buttonCair.Size = new System.Drawing.Size(75, 23);
            this.buttonCair.TabIndex = 4;
            this.buttonCair.Text = "Cair";
            this.buttonCair.UseVisualStyleBackColor = true;
            // 
            // FormCairDeposito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(339, 182);
            this.Controls.Add(this.buttonCair);
            this.Controls.Add(this.labelTglPengajuanCair);
            this.Controls.Add(this.labelNomorDeposito);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormCairDeposito";
            this.Text = "FormCairDeposito";
            this.Load += new System.EventHandler(this.FormCairDeposito_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelNomorDeposito;
        private System.Windows.Forms.Label labelTglPengajuanCair;
        private System.Windows.Forms.Button buttonCair;
    }
}