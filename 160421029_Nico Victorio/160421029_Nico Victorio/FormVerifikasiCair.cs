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
    public partial class FormVerifikasiCair : Form
    {
        FormMenu formMenu;
        Employee emp;

        public FormVerifikasiCair()
        {
            InitializeComponent();
        }

        private void FormVerifikasiCair_Load(object sender, EventArgs e)
        {
            formMenu = (FormMenu)this.MdiParent;
            emp = formMenu.tmpEmp;
            List<Deposito> listDeposito = Deposito.BacaData("status", "Waiting");
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
            string idDeposito = dataGridViewListVerifikasiDeposito.CurrentRow.Cells["iddeposito"].Value.ToString();
            Tabungan noRek = (Tabungan)dataGridViewListVerifikasiDeposito.CurrentRow.Cells["tabungan"].Value;
            double nominal = (double)dataGridViewListVerifikasiDeposito.CurrentRow.Cells["nominal"].Value;
            string status = dataGridViewListVerifikasiDeposito.CurrentRow.Cells["status"].Value.ToString();
            DateTime tglAwal = DateTime.Parse(dataGridViewListVerifikasiDeposito.CurrentRow.Cells["tglawal"].Value.ToString());
            DateTime tglCair = DateTime.Parse(dataGridViewListVerifikasiDeposito.CurrentRow.Cells["tglcair"].Value.ToString());
            Employee verifikatorBuka = (Employee)dataGridViewListVerifikasiDeposito.CurrentRow.Cells["verifikatorbuka"].Value;
            Employee verifikatorCair = (Employee)dataGridViewListVerifikasiDeposito.CurrentRow.Cells["verifikatorcair"].Value;
            Bunga idBunga = (Bunga)dataGridViewListVerifikasiDeposito.CurrentRow.Cells["bunga"].Value;
            Boolean aro = (Boolean)dataGridViewListVerifikasiDeposito.CurrentRow.Cells["aro"].Value;
            string keterangan = dataGridViewListVerifikasiDeposito.CurrentRow.Cells["keterangan"].Value.ToString();

            if (e.ColumnIndex == dataGridViewListVerifikasiDeposito.Columns["btnConfirm"].Index && e.RowIndex >= 0)
            {
                if (MessageBox.Show("Apakah anda yakin mengverifikasi cair deposito?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        Deposito dep = new Deposito(idDeposito, noRek, nominal, status, tglAwal, tglCair, verifikatorBuka, verifikatorCair, idBunga, aro, keterangan);
                        double denda = 0;
                        double bunga = 0;
                        if (DateTime.Now.ToShortDateString() == dep.TglCair.ToShortDateString())
                        {
                            bunga = nominal * idBunga.PersenBunga / 100;
                        }
                        else
                        {
                            denda = dep.Nominal * 5 / 100;
                        }
                        if (dep.UbahStatusCompleted(emp.Email, denda, bunga))
                        {
                            MessageBox.Show("Deposito telah dicairkan.");
                            FormVerifikasiCair_Load(sender, e);
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
