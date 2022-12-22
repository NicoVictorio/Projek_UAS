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
        FormMenu formMenu;
        public Pengguna penggunaAsal;
        Tabungan tabPengguna;
        public FormDaftarDeposito()
        {
            InitializeComponent();
        }

        public void FormDaftarDeposito_Load(object sender, EventArgs e)
        {
            formMenu = (FormMenu)this.MdiParent;
            penggunaAsal = formMenu.tmpPengguna;

            List<Tabungan> tmpListTabungan = Tabungan.BacaData("id_pengguna", penggunaAsal.Nik.ToString());
            tabPengguna = tmpListTabungan[0];

            listDeposito = Deposito.BacaData("", "");
            if (listDeposito.Count > 0)
            {
                dgvListDeposito.DataSource = listDeposito;
                if (dgvListDeposito.Columns.Count < 11)
                {
                    DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
                    buttonColumn.HeaderText = "Aksi";
                    buttonColumn.Text = "Cair";
                    buttonColumn.Name = "btnCairGrid";
                    buttonColumn.UseColumnTextForButtonValue = true;
                    dgvListDeposito.Columns.Add(buttonColumn);
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
            try
            {
                string idDeposito = dgvListDeposito.CurrentRow.Cells["idDeposito"].Value.ToString();
                Tabungan noRekening = (Tabungan)dgvListDeposito.CurrentRow.Cells["tabungan"].Value;

                string jatuhTempo = dgvListDeposito.CurrentRow.Cells["JatuhTempo"].Value.ToString();
                double nominal = (double)dgvListDeposito.CurrentRow.Cells["nominal"].Value;
                double bunga = (double)dgvListDeposito.CurrentRow.Cells["bunga"].Value;
                string status = dgvListDeposito.CurrentRow.Cells["status"].Value.ToString();

                DateTime tglBuat = (DateTime)dgvListDeposito.CurrentRow.Cells["tglBuat"].Value;
                DateTime tglPerubahan = (DateTime)dgvListDeposito.CurrentRow.Cells["tglPerubahan"].Value;
                Employee verifikatorBuka = (Employee)dgvListDeposito.CurrentRow.Cells["verivikatorbuka"].Value;
                Employee verifikatorCair = (Employee)dgvListDeposito.CurrentRow.Cells["verivikatorcair"].Value;

                Deposito dep = new Deposito(idDeposito, noRekening, jatuhTempo, nominal, bunga, status,
                                            tglBuat, tglPerubahan, verifikatorBuka, verifikatorCair);
                if (dep != null)
                {
                    if (e.ColumnIndex == dgvListDeposito.Columns["btnCairGrid"].Index)
                    {
                        DialogResult confirmation = MessageBox.Show("Apakah anda yakin ingin mencairkan deposito '" + dep.IdDeposito + "' pada tanggal " + DateTime.Now + " ?", "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        int bulan = HitungBulan(dep.JatuhTempo);
                        if (confirmation == DialogResult.Yes)
                        {
                            if (DateTime.Now.ToShortDateString() == dep.TglBuat.AddMonths(bulan).ToShortDateString())
                            {
                                if (dep.UbahStatusSiapCair())
                                {
                                    throw new Exception("Permintaan cair deposit berhasil. Harap tunggu konfirmasi admin");
                                    

                                }
                                FormDaftarDeposito_Load(sender, e);
                            }
                            else
                            {

                                throw new Exception("Pencairan deposit gagal. Anda akan dikenakan penalti 5% dari "
                                    + dep.Nominal + " dan dana akan dikembalikan tanpa bunga");
                            }
                        }
                        //if (dep.Status == "Aktif" && tabPengguna.Status == "Aktif")
                        //{
                        //    FormCairDeposito formCairDeposito = new FormCairDeposito();
                        //    formCairDeposito.Owner = this;
                        //    formCairDeposito.idDeposito = dep.IdDeposito;
                        //    formCairDeposito.ShowDialog();
                        //}
                        //else
                        //{
                        //    MessageBox.Show("Status deposito anda tidak aktif");
                        //}
                    }
                }
            }
            catch(Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        private int HitungBulan(string jatuhTempo)
        {
            int bulan = 0;
            if (jatuhTempo == "1 bulan")
            {
                bulan = 1;
            }
            else if (jatuhTempo == "3 bulan")
            {
                bulan = 3;
            }
            else if (jatuhTempo == "6 bulan")
            {
                bulan = 6;
            }
            else if (jatuhTempo == "1 tahun")
            {
                bulan = 12;
            }
            else if (jatuhTempo == "2 tahun")
            {
                bulan = 24;
            }
            else if (jatuhTempo == "3 tahun")
            {
                bulan = 36;
            }
            return bulan;
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
