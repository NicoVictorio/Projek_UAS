using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DiBa_Lib;

namespace _160421029_Nico_Victorio
{
    
    public partial class FormDaftarTransaksi : Form
    {
        List<Transaksi> listTransaksi = new List<Transaksi>();
        public FormDaftarTransaksi()
        {
            InitializeComponent();
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {

        }

        private void FormDaftarTransaksi_Load(object sender, EventArgs e)
        {
            listTransaksi = Transaksi.BacaData("", "");
            if (listTransaksi.Count > 0)
            {
                dgvListTransaksi.DataSource = listTransaksi;
                if (dgvListTransaksi.Columns.Count < 8)
                {
                    DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
                    buttonColumn.HeaderText = "Aksi";
                    buttonColumn.Text = "Update";
                    buttonColumn.Name = "btnUbahGrid";
                    buttonColumn.UseColumnTextForButtonValue = true;
                    dgvListTransaksi.Columns.Add(buttonColumn);

                    DataGridViewButtonColumn btnDeleteColumns = new DataGridViewButtonColumn();
                    btnDeleteColumns.HeaderText = "Aksi";
                    btnDeleteColumns.Text = "Delete";
                    btnDeleteColumns.Name = "btnHapusGrid";
                    btnDeleteColumns.UseColumnTextForButtonValue = true;
                    dgvListTransaksi.Columns.Add(btnDeleteColumns);
                }
            }
            else
            {
                dgvListTransaksi.DataSource = null;
            }
        }
    }
}
