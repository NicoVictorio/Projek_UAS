
namespace _160421029_Nico_Victorio
{
    partial class FormVerifikasiTabungan
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
            this.buttonExit = new System.Windows.Forms.Button();
            this.dataGridViewListVerifikasiTabungan = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewListVerifikasiTabungan)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonExit
            // 
            this.buttonExit.Location = new System.Drawing.Point(368, 426);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(91, 48);
            this.buttonExit.TabIndex = 5;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // dataGridViewListVerifikasiTabungan
            // 
            this.dataGridViewListVerifikasiTabungan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewListVerifikasiTabungan.Location = new System.Drawing.Point(25, 22);
            this.dataGridViewListVerifikasiTabungan.Name = "dataGridViewListVerifikasiTabungan";
            this.dataGridViewListVerifikasiTabungan.RowHeadersWidth = 51;
            this.dataGridViewListVerifikasiTabungan.RowTemplate.Height = 24;
            this.dataGridViewListVerifikasiTabungan.Size = new System.Drawing.Size(782, 368);
            this.dataGridViewListVerifikasiTabungan.TabIndex = 4;
            this.dataGridViewListVerifikasiTabungan.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewListVerifikasiTabungan_CellContentClick);
            // 
            // FormVerifikasiTabungan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 500);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.dataGridViewListVerifikasiTabungan);
            this.Name = "FormVerifikasiTabungan";
            this.Text = "FormVerifikasiTabungan";
            this.Load += new System.EventHandler(this.FormVerifikasiTabungan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewListVerifikasiTabungan)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.DataGridView dataGridViewListVerifikasiTabungan;
    }
}