
namespace _160421029_Nico_Victorio
{
    partial class FormDaftarMutasi
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
            this.dgvListMutasi = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListMutasi)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Exit
            // 
            this.btn_Exit.Location = new System.Drawing.Point(354, 400);
            this.btn_Exit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(93, 39);
            this.btn_Exit.TabIndex = 66;
            this.btn_Exit.Text = "Exit";
            this.btn_Exit.UseVisualStyleBackColor = true;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // dgvListMutasi
            // 
            this.dgvListMutasi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListMutasi.Location = new System.Drawing.Point(32, 29);
            this.dgvListMutasi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvListMutasi.Name = "dgvListMutasi";
            this.dgvListMutasi.RowHeadersWidth = 51;
            this.dgvListMutasi.RowTemplate.Height = 24;
            this.dgvListMutasi.Size = new System.Drawing.Size(732, 355);
            this.dgvListMutasi.TabIndex = 65;
            // 
            // FormDaftarMutasi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_Exit);
            this.Controls.Add(this.dgvListMutasi);
            this.Name = "FormDaftarMutasi";
            this.Text = "FormDaftarMutasi";
            this.Load += new System.EventHandler(this.FormDaftarMutasi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListMutasi)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Exit;
        private System.Windows.Forms.DataGridView dgvListMutasi;
    }
}