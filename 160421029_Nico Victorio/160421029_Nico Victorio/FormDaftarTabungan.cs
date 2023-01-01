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
    public partial class FormDaftarTabungan : Form
    {
        public List<Tabungan> listTabungan = new List<Tabungan>();
        public FormDaftarTabungan()
        {
            InitializeComponent();
        }

        public void FormDaftarTabungan_Load(object sender, EventArgs e)
        {
            listTabungan = Tabungan.BacaData("", "");
            if (listTabungan.Count > 0)
            {
                dgvListTabungan.DataSource = listTabungan;
                if (dgvListTabungan.Columns.Count < 10)
                {
                    DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
                    buttonColumn.HeaderText = "Aksi";
                    buttonColumn.Text = "Update";
                    buttonColumn.Name = "btnUbahGrid";
                    buttonColumn.UseColumnTextForButtonValue = true;
                    dgvListTabungan.Columns.Add(buttonColumn);

                    DataGridViewButtonColumn btnDeleteColumns = new DataGridViewButtonColumn();
                    btnDeleteColumns.HeaderText = "Aksi";
                    btnDeleteColumns.Text = "Delete";
                    btnDeleteColumns.Name = "btnHapusGrid";
                    btnDeleteColumns.UseColumnTextForButtonValue = true;
                    dgvListTabungan.Columns.Add(btnDeleteColumns);
                }
            }
            else
            {
                dgvListTabungan.DataSource = null;
            }
        }

        private void tb_Kriteria_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string kriteria = "";
                string nilai = "";

                if (cb_Kriteria.Text == "No Rekening")
                {
                    kriteria = "no_rekening";
                }
                else if (cb_Kriteria.Text == "Id Pengguna")
                {
                    kriteria = "id_pengguna";
                }
                else if (cb_Kriteria.Text == "Saldo")
                {
                    kriteria = "saldo";
                }
                else if (cb_Kriteria.Text == "Poin")
                {
                    kriteria = "poin";
                }
                else if (cb_Kriteria.Text == "Status")
                {
                    kriteria = "status";
                }
                else if (cb_Kriteria.Text == "Keterangan")
                {
                    kriteria = "jeterangan";
                }
                else if (cb_Kriteria.Text == "Tanggal Buat")
                {
                    kriteria = "tgl_buat";
                }
                else if (cb_Kriteria.Text == "Tanggal Perubahan")
                {
                    kriteria = "tgl_perubahan";
                }
                else if (cb_Kriteria.Text == "Verifikator")
                {
                    kriteria = "verivikator";
                }
                nilai = tb_Kriteria.Text;
                listTabungan = Tabungan.BacaData(kriteria, nilai);

                if (listTabungan.Count > 0)
                {
                    dgvListTabungan.DataSource = listTabungan;
                }
                else
                {
                    dgvListTabungan.DataSource = null;
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        private void dgvListTabungan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string noRek = dgvListTabungan.CurrentRow.Cells["norekening"].Value.ToString();
            double saldo = (double)dgvListTabungan.CurrentRow.Cells["saldo"].Value;
            double poin = (double)dgvListTabungan.CurrentRow.Cells["poin"].Value;
            string status = dgvListTabungan.CurrentRow.Cells["status"].Value.ToString();
            string keterangan = dgvListTabungan.CurrentRow.Cells["keterangan"].Value.ToString();

            DateTime tglBuat = (DateTime)dgvListTabungan.CurrentRow.Cells["tgl_Buat"].Value;
            DateTime tglPerubahan = (DateTime)dgvListTabungan.CurrentRow.Cells["tgl_Perubahan"].Value;
            Employee employee = (Employee)dgvListTabungan.CurrentRow.Cells["employee"].Value;
            Pengguna pengguna = (Pengguna)dgvListTabungan.CurrentRow.Cells["pengguna"].Value;

            Tabungan tab = new Tabungan(noRek, pengguna, saldo, poin, status, keterangan, tglBuat, tglPerubahan, employee);
            if (tab != null)
            {
                if (e.ColumnIndex == dgvListTabungan.Columns["btnUbahGrid"].Index)
                {
                    FormUpdateTabungan formUpdate = new FormUpdateTabungan();
                    formUpdate.Owner = this;
                    formUpdate.tmpnoRek = tab.NoRekening;
                    formUpdate.ShowDialog();
                }
                else if (e.ColumnIndex == dgvListTabungan.Columns["btnHapusGrid"].Index)
                {
                    try
                    {
                        DialogResult confirmation = MessageBox.Show("Apakah anda yakin ingin menghapus data tabungan '" + pengguna.NamaDepan + "'?", "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (confirmation == DialogResult.Yes)
                        {
                            if (tab.HapusData())
                            {
                                MessageBox.Show("Penghapusan data berhasil");
                                FormDaftarTabungan_Load(sender, e);
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
