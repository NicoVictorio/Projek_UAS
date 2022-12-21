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
    public partial class FormVerifikasiDeposito : Form
    {
        FormMenu formMenu;
        Employee emp;
        public FormVerifikasiDeposito()
        {
            InitializeComponent();
        }

        private void FormVerifikasiDeposito_Load(object sender, EventArgs e)
        {
            formMenu = (FormMenu)this.MdiParent;
            emp = formMenu.tmpEmp;
            List<Deposito> listDeposito = Deposito.BacaData("", "");
            if (listDeposito.Count > 0)
            {
                dataGridViewListVerifikasiDeposito.DataSource = listDeposito;

                if (dataGridViewListVerifikasiDeposito.ColumnCount < 11)
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
            int idDeposito = (int)dataGridViewListVerifikasiDeposito.CurrentRow.Cells["iddeposito"].Value;
            Tabungan noRek = (Tabungan)dataGridViewListVerifikasiDeposito.CurrentRow.Cells["noRekening"].Value;
            string jatuhTempo = dataGridViewListVerifikasiDeposito.CurrentRow.Cells["jatuhtempo"].Value.ToString();
            double nominal = (double)dataGridViewListVerifikasiDeposito.CurrentRow.Cells["saldo"].Value;
            double bunga = (double)dataGridViewListVerifikasiDeposito.CurrentRow.Cells["bunga"].Value;
            string status = dataGridViewListVerifikasiDeposito.CurrentRow.Cells["status"].Value.ToString();
            DateTime tglBuat = DateTime.Parse(dataGridViewListVerifikasiDeposito.CurrentRow.Cells["tgl_buat"].Value.ToString());
            DateTime tglPerubahan = DateTime.Parse(dataGridViewListVerifikasiDeposito.CurrentRow.Cells["tgl_perubahan"].Value.ToString());
            Employee verivikatorBuka = (Employee)dataGridViewListVerifikasiDeposito.CurrentRow.Cells["verivikatorbuka"].Value;
            Employee verivikatorCair = (Employee)dataGridViewListVerifikasiDeposito.CurrentRow.Cells["verivikatorcair"].Value;

            if (e.ColumnIndex == dataGridViewListVerifikasiDeposito.Columns["btnConfirm"].Index && e.RowIndex >= 0)
            {
                if (MessageBox.Show("Apakah anda yakin mengverifikasi tabungan?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        Deposito dep = new Deposito(idDeposito, noRek, jatuhTempo, nominal, bunga, status, tglBuat, tglPerubahan, verivikatorBuka, verivikatorCair);
                        if (dep.UbahStatus(emp.Id))
                        {
                            MessageBox.Show("Deposito telah terverifikasi.");
                            FormVerifikasiDeposito_Load(sender, e);
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
