
namespace _160421029_Nico_Victorio
{
    partial class FormMasterBunga
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
            this.dataGridViewListBunga = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewListBunga)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Exit
            // 
            this.btn_Exit.BackColor = System.Drawing.SystemColors.Control;
            this.btn_Exit.Location = new System.Drawing.Point(290, 318);
            this.btn_Exit.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(70, 32);
            this.btn_Exit.TabIndex = 31;
            this.btn_Exit.Text = "Exit";
            this.btn_Exit.UseVisualStyleBackColor = false;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // dataGridViewListBunga
            // 
            this.dataGridViewListBunga.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewListBunga.Location = new System.Drawing.Point(30, 28);
            this.dataGridViewListBunga.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridViewListBunga.Name = "dataGridViewListBunga";
            this.dataGridViewListBunga.RowHeadersWidth = 51;
            this.dataGridViewListBunga.RowTemplate.Height = 24;
            this.dataGridViewListBunga.Size = new System.Drawing.Size(594, 269);
            this.dataGridViewListBunga.TabIndex = 32;
            // 
            // FormMasterBunga
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(652, 358);
            this.Controls.Add(this.dataGridViewListBunga);
            this.Controls.Add(this.btn_Exit);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormMasterBunga";
            this.Text = "Master List Bunga";
            this.Load += new System.EventHandler(this.FormMasterBunga_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewListBunga)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btn_Exit;
        private System.Windows.Forms.DataGridView dataGridViewListBunga;
    }
}