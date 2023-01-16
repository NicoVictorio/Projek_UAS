
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
            this.label1.Location = new System.Drawing.Point(25, 26);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nominal";
            // 
            // textBoxNominal
            // 
            this.textBoxNominal.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxNominal.Location = new System.Drawing.Point(106, 26);
            this.textBoxNominal.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxNominal.Name = "textBoxNominal";
            this.textBoxNominal.Size = new System.Drawing.Size(99, 20);
            this.textBoxNominal.TabIndex = 1;
            // 
            // buttonTopUp
            // 
            this.buttonTopUp.BackColor = System.Drawing.SystemColors.Control;
            this.buttonTopUp.Location = new System.Drawing.Point(27, 67);
            this.buttonTopUp.Margin = new System.Windows.Forms.Padding(2);
            this.buttonTopUp.Name = "buttonTopUp";
            this.buttonTopUp.Size = new System.Drawing.Size(64, 28);
            this.buttonTopUp.TabIndex = 2;
            this.buttonTopUp.Text = "Top Up";
            this.buttonTopUp.UseVisualStyleBackColor = false;
            this.buttonTopUp.Click += new System.EventHandler(this.buttonTopUp_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.BackColor = System.Drawing.SystemColors.Control;
            this.buttonCancel.Location = new System.Drawing.Point(140, 67);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(2);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(64, 28);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = false;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // FormTopUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(236, 119);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonTopUp);
            this.Controls.Add(this.textBoxNominal);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormTopUp";
            this.Text = "Top Up";
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