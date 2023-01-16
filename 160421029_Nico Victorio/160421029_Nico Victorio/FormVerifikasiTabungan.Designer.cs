
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormVerifikasiTabungan));
            this.buttonExit = new System.Windows.Forms.Button();
            this.dataGridViewListVerifikasiTabungan = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewListVerifikasiTabungan)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonExit
            // 
            this.buttonExit.BackColor = System.Drawing.Color.Bisque;
            this.buttonExit.Location = new System.Drawing.Point(323, 389);
            this.buttonExit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(68, 39);
            this.buttonExit.TabIndex = 5;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = false;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // dataGridViewListVerifikasiTabungan
            // 
            this.dataGridViewListVerifikasiTabungan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewListVerifikasiTabungan.Location = new System.Drawing.Point(19, 18);
            this.dataGridViewListVerifikasiTabungan.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridViewListVerifikasiTabungan.Name = "dataGridViewListVerifikasiTabungan";
            this.dataGridViewListVerifikasiTabungan.RowHeadersWidth = 51;
            this.dataGridViewListVerifikasiTabungan.RowTemplate.Height = 24;
            this.dataGridViewListVerifikasiTabungan.Size = new System.Drawing.Size(676, 358);
            this.dataGridViewListVerifikasiTabungan.TabIndex = 4;
            this.dataGridViewListVerifikasiTabungan.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewListVerifikasiTabungan_CellContentClick);
            // 
            // FormVerifikasiTabungan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(715, 434);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.dataGridViewListVerifikasiTabungan);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormVerifikasiTabungan";
            this.Text = "Verifikasi Pembukaan Tabungan";
            this.Load += new System.EventHandler(this.FormVerifikasiTabungan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewListVerifikasiTabungan)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.DataGridView dataGridViewListVerifikasiTabungan;
    }
}