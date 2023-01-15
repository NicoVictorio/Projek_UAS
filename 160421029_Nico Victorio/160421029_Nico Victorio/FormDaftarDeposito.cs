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
        public Pengguna penggunaAsal;
        FormMenu formMenu;
        Tabungan tabPengguna;

        public FormDaftarDeposito()
        {
            InitializeComponent();
        }

        public void FormDaftarDeposito_Load(object sender, EventArgs e)
        {
            formMenu = (FormMenu)this.MdiParent;
            penggunaAsal = formMenu.tmpPengguna;

            List<Tabungan> tmpListTabungan = Tabungan.BacaData("pengguna_email", penggunaAsal.Email);
            tabPengguna = tmpListTabungan[0];

            listDeposito = Deposito.BacaData("no_rekening", tabPengguna.NoRekening);
            if (listDeposito.Count > 0)
            {
                dgvListDeposito.DataSource = listDeposito;
                if (dgvListDeposito.Columns.Count < 12)
                {
                    DataGridViewButtonColumn buttonCair = new DataGridViewButtonColumn();
                    buttonCair.HeaderText = "Aksi";
                    buttonCair.Text = "Cair";
                    buttonCair.Name = "btnCairGrid";
                    buttonCair.UseColumnTextForButtonValue = true;
                    dgvListDeposito.Columns.Add(buttonCair);

                    DataGridViewButtonColumn buttonUpdate = new DataGridViewButtonColumn();
                    buttonUpdate.HeaderText = "Aksi";
                    buttonUpdate.Text = "Update";
                    buttonUpdate.Name = "btnUpdateGrid";
                    buttonUpdate.UseColumnTextForButtonValue = true;
                    dgvListDeposito.Columns.Add(buttonUpdate);
                }
            }
            else
            {
                dgvListDeposito.DataSource = null;
            }
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            FormPengajuanDeposito formPengajuanDeposito = new FormPengajuanDeposito();
            formPengajuanDeposito.Owner = this;
            formPengajuanDeposito.ShowDialog();
        }

        private void tb_Kriteria_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string kriteria = "";
                string nilai = "";
                if (cb_Kriteria.Text == "Id Deposito")
                {
                    kriteria = "id_deposito";
                }
                else if (cb_Kriteria.Text == "Nomor Rekening")
                {
                    kriteria = "no_rekening";
                }
                else if (cb_Kriteria.Text == "Nominal")
                {
                    kriteria = "nominal";
                }
                else if (cb_Kriteria.Text == "Status")
                {
                    kriteria = "status";
                }
                else if (cb_Kriteria.Text == "Tanggal Awal")
                {
                    kriteria = "tgl_buat";
                }
                else if (cb_Kriteria.Text == "Tanggal Cair")
                {
                    kriteria = "tgl_perubahan";
                }
                else if (cb_Kriteria.Text == "Verifikator Buka")
                {
                    kriteria = "verifikator_buka";
                }
                else if (cb_Kriteria.Text == "Verifikator Cair")
                {
                    kriteria = "verifikator_cair";
                }
                else if (cb_Kriteria.Text == "Id Bunga")
                {
                    kriteria = "idBunga";
                }
                else if (cb_Kriteria.Text == "Aro")
                {
                    kriteria = "aro";
                }
                else if (cb_Kriteria.Text == "Keterangan")
                {
                    kriteria = "keterangan";
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
            try
            {
                string idDeposito = dgvListDeposito.CurrentRow.Cells["idDeposito"].Value.ToString();
                Tabungan noRekening = (Tabungan)dgvListDeposito.CurrentRow.Cells["tabungan"].Value;

                long nominal = (long)dgvListDeposito.CurrentRow.Cells["nominal"].Value;
                string status = dgvListDeposito.CurrentRow.Cells["status"].Value.ToString();

                DateTime tglAwal = (DateTime)dgvListDeposito.CurrentRow.Cells["tglAwal"].Value;
                DateTime tglCair = (DateTime)dgvListDeposito.CurrentRow.Cells["tglCair"].Value;
                Employee verifikatorBuka = (Employee)dgvListDeposito.CurrentRow.Cells["verifikatorbuka"].Value;
                Employee verifikatorCair = (Employee)dgvListDeposito.CurrentRow.Cells["verifikatorcair"].Value;

                Bunga idBunga = (Bunga)dgvListDeposito.CurrentRow.Cells["bunga"].Value;
                bool aro = (bool)dgvListDeposito.CurrentRow.Cells["aro"].Value;

                string keterangan = dgvListDeposito.CurrentRow.Cells["keterangan"].Value.ToString();
                Deposito dep = new Deposito(idDeposito, noRekening, nominal, status,
                                            tglAwal, tglCair, verifikatorBuka, 
                                            verifikatorCair, idBunga, aro, keterangan);
                if (dep != null)
                {
                    if (e.ColumnIndex == dgvListDeposito.Columns["btnCairGrid"].Index && dep.Aro != true)
                    {
                        if (dep.Status == "Aktif")
                        {
                            DialogResult confirmation = MessageBox.Show("Apakah anda yakin ingin mencairkan deposito '" + dep.IdDeposito + "' pada tanggal " + DateTime.Now + " ?", "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (confirmation == DialogResult.Yes)
                            {
                                if (dep.UbahStatusWaiting())
                                {
                                    FormDaftarDeposito_Load(sender, e);
                                    throw new Exception("Pencairan deposit berhasil. Harap tunggu konfirmasi admin.");
                                }
                            }
                        }
                        else if (dep.Status == "Unverified")
                        {
                            throw new Exception("Deposito anda belum terverifikasi oleh employee. Silahkan verifikasi terlebih dahulu.");
                        }
                        else if (dep.Status == "Waiting")
                        {
                            throw new Exception("Deposito anda masih dalam proses verifikasi. Harap tunggu.");
                        }
                        else if (dep.Status == "Completed")
                        {
                            throw new Exception("Deposito anda sudah cair.");
                        }
                    }
                    else if(e.ColumnIndex == dgvListDeposito.Columns["btnUpdateGrid"].Index && dep.Aro == true)
                    {
                        dep.UbahStatusAro(aro);
                        FormDaftarDeposito_Load(sender, e);
                    }
                    else if (e.ColumnIndex == dgvListDeposito.Columns["btnCairGrid"].Index && dep.Aro == true)
                    {
                        throw new Exception("Anda tidak bisa mencairkan deposito bertipe aro.");
                    }
                    else if (e.ColumnIndex == dgvListDeposito.Columns["btnUpdateGrid"].Index && dep.Aro != true)
                    {
                        throw new Exception("Anda tidak bisa mengubah deposito menjadi aro.");
                    }
                }
            }
            catch(Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
