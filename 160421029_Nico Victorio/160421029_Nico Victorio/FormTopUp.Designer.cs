
namespace _160421029_Nico_Victorio
{
    partial class FormTopUp
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
            this.textBoxNominal = new System.Windows.Forms.TextBox();
            this.buttonTopUp = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nominal";
            // 
            // textBoxNominal
            // 
            this.textBoxNominal.Location = new System.Drawing.Point(141, 32);
            this.textBoxNominal.Name = "textBoxNominal";
            this.textBoxNominal.Size = new System.Drawing.Size(131, 22);
            this.textBoxNominal.TabIndex = 1;
            this.textBoxNominal.Leave += new System.EventHandler(this.textBoxNominal_Leave);
            // 
            // buttonTopUp
            // 
            this.buttonTopUp.Location = new System.Drawing.Point(36, 83);
            this.buttonTopUp.Name = "buttonTopUp";
            this.buttonTopUp.Size = new System.Drawing.Size(86, 35);
            this.buttonTopUp.TabIndex = 2;
            this.buttonTopUp.Text = "Top Up";
            this.buttonTopUp.UseVisualStyleBackColor = true;
            this.buttonTopUp.Click += new System.EventHandler(this.buttonTopUp_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(186, 83);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(86, 35);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // FormTopUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(315, 146);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonTopUp);
            this.Controls.Add(this.textBoxNominal);
            this.Controls.Add(this.label1);
            this.Name = "FormTopUp";
            this.Text = "FormTopUp";
            this.Load += new System.EventHandler(this.FormTopUp_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxNominal;
        private System.Windows.Forms.Button buttonTopUp;
        private System.Windows.Forms.Button buttonCancel;
    }
}