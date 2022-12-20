
namespace _160421029_Nico_Victorio
{
    partial class FormVerifikasiDeposito
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
            this.dataGridViewListVerifikasiDeposito = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewListVerifikasiDeposito)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonExit
            // 
            this.buttonExit.Location = new System.Drawing.Point(374, 430);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(91, 48);
            this.buttonExit.TabIndex = 3;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // dataGridViewListVerifikasiDeposito
            // 
            this.dataGridViewListVerifikasiDeposito.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewListVerifikasiDeposito.Location = new System.Drawing.Point(31, 26);
            this.dataGridViewListVerifikasiDeposito.Name = "dataGridViewListVerifikasiDeposito";
            this.dataGridViewListVerifikasiDeposito.RowHeadersWidth = 51;
            this.dataGridViewListVerifikasiDeposito.RowTemplate.Height = 24;
            this.dataGridViewListVerifikasiDeposito.Size = new System.Drawing.Size(782, 368);
            this.dataGridViewListVerifikasiDeposito.TabIndex = 2;
            this.dataGridViewListVerifikasiDeposito.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewListVerifikasiDeposito_CellContentClick);
            // 
            // FormVerifikasiDeposito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 504);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.dataGridViewListVerifikasiDeposito);
            this.Name = "FormVerifikasiDeposito";
            this.Text = "FormVerifikasiDeposito";
            this.Load += new System.EventHandler(this.FormVerifikasiDeposito_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewListVerifikasiDeposito)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.DataGridView dataGridViewListVerifikasiDeposito;
    }
}