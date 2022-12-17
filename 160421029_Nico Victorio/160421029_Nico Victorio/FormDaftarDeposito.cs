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
    public partial class FormDaftarDeposito : Form
    {
        public List<Deposito> listDeposito = new List<Deposito>();
        public FormDaftarDeposito()
        {
            InitializeComponent();
        }

        public void FormDaftarDeposito_Load(object sender, EventArgs e)
        {
            listDeposito = Deposito.BacaData("", "");
            if (listDeposito.Count > 0)
            {
                dgvListDeposito.DataSource = listDeposito;
                if (dgvListDeposito.Columns.Count < 11)
                {
                    DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
                    buttonColumn.HeaderText = "Aksi";
                    buttonColumn.Text = "Update";
                    buttonColumn.Name = "btnUbahGrid";
                    buttonColumn.UseColumnTextForButtonValue = true;
                    dgvListDeposito.Columns.Add(buttonColumn);

                    DataGridViewButtonColumn btnDeleteColumns = new DataGridViewButtonColumn();
                    btnDeleteColumns.HeaderText = "Aksi";
                    btnDeleteColumns.Text = "Delete";
                    btnDeleteColumns.Name = "btnHapusGrid";
                    btnDeleteColumns.UseColumnTextForButtonValue = true;
                    dgvListDeposito.Columns.Add(btnDeleteColumns);
                }
            }
            else
            {
                dgvListDeposito.DataSource = null;
            }
        }

        private void tb_Kriteria_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string kriteria = "";
                string nilai = "";

                if (cb_Kriteria.Text == "ID Deposito")
                {
                    kriteria = "id_deposito";
                }
                else if (cb_Kriteria.Text == "Nomor Rekening")
                {
                    kriteria = "no_rekening";
                }
                else if (cb_Kriteria.Text == "Jatuh Tempo")
                {
                    kriteria = "nominal";
                }
                else if (cb_Kriteria.Text == "Bunga")
                {
                    kriteria = "bunga";
                }
                else if (cb_Kriteria.Text == "Status")
                {
                    kriteria = "status";
                }
                else if (cb_Kriteria.Text == "Tanggal Buat")
                {
                    kriteria = "tgl_buat";
                }
                else if (cb_Kriteria.Text == "Tanggal Perubahan")
                {
                    kriteria = "tgl_perubahan";
                }
                else if (cb_Kriteria.Text == "Verifikator Buka")
                {
                    kriteria = "verivikator_buka";
                }
                else if (cb_Kriteria.Text == "Verifikator Cair")
                {
                    kriteria = "verivikator_cair";
                }
                nilai = tb_Kriteria.Text;
                listDeposito = Deposito.BacaData(kriteria, nilai);

                if (listDeposito.Count > 0)
                {
                    dgvListDeposito.DataSource = listDeposito;
                }
                else
                {
                    dgvListDeposito.DataSource = null;
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        private void dgvListDeposito_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int idDeposito = (int)dgvListDeposito.CurrentRow.Cells["ID Deposito"].Value;
            Tabungan noRekening = (Tabungan)dgvListDeposito.CurrentRow.Cells["Nomor Rekening"].Value;

            string jatuhTempo = dgvListDeposito.CurrentRow.Cells["Jatuh Tempo"].Value.ToString();
            double nominal = (double)dgvListDeposito.CurrentRow.Cells["nominal"].Value;
            double bunga = (double)dgvListDeposito.CurrentRow.Cells["bunga"].Value;
            string status = dgvListDeposito.CurrentRow.Cells["status"].Value.ToString();

            DateTime tglBuat = (DateTime)dgvListDeposito.CurrentRow.Cells["tgl_Buat"].Value;
            DateTime tglPerubahan = (DateTime)dgvListDeposito.CurrentRow.Cells["tgl_Perubahan"].Value;
            Employee verifikatorBuka = (Employee)dgvListDeposito.CurrentRow.Cells["verifikator buka"].Value;
            Employee verifikatorCair = (Employee)dgvListDeposito.CurrentRow.Cells["verifikator cair"].Value;

            Deposito dep = new Deposito(idDeposito, noRekening, jatuhTempo, nominal, bunga, status, 
                tglBuat, tglPerubahan, verifikatorBuka, verifikatorBuka);
            if (dep != null)
            {
                if (e.ColumnIndex == dgvListDeposito.Columns["btnUbahGrid"].Index)
                {
                    FormUpdateDeposito formUpdate = new FormUpdateDeposito();
                    formUpdate.Owner = this;
                    formUpdate.idDeposito = dep.IdDeposito;
                    formUpdate.ShowDialog();
                }
                else if (e.ColumnIndex == dgvListDeposito.Columns["btnHapusGrid"].Index)
                {
                    try
                    {
                        DialogResult confirmation = MessageBox.Show(
                            "Apakah anda yakin ingin menghapus data deposito '" + 
                            idDeposito + "'?", "Konfirmasi Hapus", 
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (confirmation == DialogResult.Yes)
                        {
                            if (dep.HapusData())
                            {
                                MessageBox.Show("Penghapusan data berhasil");
                                FormDaftarDeposito_Load(sender, e);
                            }
                            else
                            {
                                MessageBox.Show("Penghapusan data gagal");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
