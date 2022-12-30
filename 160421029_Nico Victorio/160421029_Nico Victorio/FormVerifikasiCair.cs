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
            List<Deposito> listDeposito = Deposito.BacaData("status", "Siap Cair");
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
            DateTime tglBuat = DateTime.Parse(dataGridViewListVerifikasiDeposito.CurrentRow.Cells["tglbuat"].Value.ToString());
            DateTime tglPerubahan = DateTime.Parse(dataGridViewListVerifikasiDeposito.CurrentRow.Cells["tglperubahan"].Value.ToString());
            Employee verivikatorBuka = (Employee)dataGridViewListVerifikasiDeposito.CurrentRow.Cells["verivikatorbuka"].Value;
            Employee verivikatorCair = (Employee)dataGridViewListVerifikasiDeposito.CurrentRow.Cells["verivikatorcair"].Value;
            Bunga idBunga = (Bunga)dataGridViewListVerifikasiDeposito.CurrentRow.Cells["idbunga"].Value;
            Boolean aro = (Boolean)dataGridViewListVerifikasiDeposito.CurrentRow.Cells["aro"].Value;

            if (e.ColumnIndex == dataGridViewListVerifikasiDeposito.Columns["btnConfirm"].Index && e.RowIndex >= 0)
            {
                if (MessageBox.Show("Apakah anda yakin mengverifikasi cair deposito?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        Deposito dep = new Deposito(idDeposito, noRek, nominal, status, tglBuat, tglPerubahan, verivikatorBuka, verivikatorCair, idBunga, aro);
                        if (dep.UbahStatusCompleted(emp.Id))
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
    }
}
