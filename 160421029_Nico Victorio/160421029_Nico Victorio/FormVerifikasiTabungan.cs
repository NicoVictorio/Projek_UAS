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
    public partial class FormVerifikasiTabungan : Form
    {
        FormMenu formMenu;
        Employee emp;
        public FormVerifikasiTabungan()
        {
            InitializeComponent();
        }

        public void FormVerifikasiTabungan_Load(object sender, EventArgs e)
        {
            formMenu = (FormMenu)this.MdiParent;
            emp = formMenu.tmpEmp;
            List<Tabungan> listTabungan = Tabungan.BacaData("", "");
            if (listTabungan.Count > 0)
            {
                dataGridViewListVerifikasiDeposito.DataSource = listTabungan;

                if (dataGridViewListVerifikasiDeposito.ColumnCount < 9)
                {
                    DataGridViewButtonColumn confirmButton = new DataGridViewButtonColumn();
                    confirmButton.HeaderText = "Aksi";
                    confirmButton.Text = "Confirm";
                    confirmButton.Name = "btnConfirm";
                    confirmButton.UseColumnTextForButtonValue = true;
                    dataGridViewListVerifikasiDeposito.Columns.Add(confirmButton);
                }
            }
            else
            {
                dataGridViewListVerifikasiDeposito.DataSource = null;
            }
        }

        private void dataGridViewListVerifikasiDeposito_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string noRek = dataGridViewListVerifikasiDeposito.CurrentRow.Cells["noRekening"].Value.ToString();
            Pengguna pengguna = (Pengguna)dataGridViewListVerifikasiDeposito.CurrentRow.Cells["pengguna"].Value;
            double saldo = (double)dataGridViewListVerifikasiDeposito.CurrentRow.Cells["saldo"].Value;
            string status = dataGridViewListVerifikasiDeposito.CurrentRow.Cells["status"].Value.ToString();
            string keterangan = dataGridViewListVerifikasiDeposito.CurrentRow.Cells["keterangan"].Value.ToString();
            DateTime tglBuat = DateTime.Parse(dataGridViewListVerifikasiDeposito.CurrentRow.Cells["tgl_buat"].Value.ToString());
            DateTime tglPerubahan = DateTime.Parse(dataGridViewListVerifikasiDeposito.CurrentRow.Cells["tgl_perubahan"].Value.ToString());
            Employee employee = (Employee)dataGridViewListVerifikasiDeposito.CurrentRow.Cells["employee"].Value;

            if (e.ColumnIndex == dataGridViewListVerifikasiDeposito.Columns["btnConfirm"].Index && e.RowIndex >= 0)
            {
                if (MessageBox.Show("Apakah anda yakin mengverifikasi tabungan?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        Tabungan tab = new Tabungan(noRek, pengguna,  saldo,  status,  keterangan,  tglBuat,  tglPerubahan,  employee);
                        if (tab.UbahStatus(emp.Id))
                        {
                            MessageBox.Show("Tabungan telah terverifikasi.");
                            FormVerifikasiTabungan_Load(sender, e);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error");
                    }
                }
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
