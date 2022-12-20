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
            FormTambahTransaksi formTambahTransaksi = new FormTambahTransaksi();
            formTambahTransaksi.Owner = this;
            formTambahTransaksi.ShowDialog();
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

        private void tb_Kriteria_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string kriteria = "";
                string nilai = "";

                if (cb_Kriteria.Text == "Rekening Sumber")
                {
                    kriteria = "rekening_sumber";
                }
                else if (cb_Kriteria.Text == "Id Transaksi")
                {
                    kriteria = "idtransaksi";
                }
                else if (cb_Kriteria.Text == "Tanggal Transaksi")
                {
                    kriteria = "tgl_transaksi";
                }
                else if (cb_Kriteria.Text == "Id Jenis Transaksi")
                {
                    kriteria = "id_jenisTransaksi";
                }
                else if (cb_Kriteria.Text == "Rekening Tujuan")
                {
                    kriteria = "rekening_tujuan";
                }
                else if (cb_Kriteria.Text == "Nominal")
                {
                    kriteria = "nominal";
                }
                else if (cb_Kriteria.Text == "Keterangan")
                {
                    kriteria = "keterangan";
                }
                nilai = tb_Kriteria.Text;
                listTransaksi = Transaksi.BacaData(kriteria, nilai);

                if (listTransaksi.Count > 0)
                {
                    dgvListTransaksi.DataSource = listTransaksi;
                }
                else
                {
                    dgvListTransaksi.DataSource = null;
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        private void dgvListTransaksi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int idTransaksi = (int)dgvListTransaksi.CurrentRow.Cells["IdTransaksi"].Value;
            double nominal = (double)dgvListTransaksi.CurrentRow.Cells["nominal"].Value;
            string keterangan = dgvListTransaksi.CurrentRow.Cells["keterangan"].Value.ToString();

            DateTime tglTransaksi = (DateTime)dgvListTransaksi.CurrentRow.Cells["TglTransaksi"].Value;
            JenisTransaksi jenisTransaksi = (JenisTransaksi)dgvListTransaksi.CurrentRow.Cells["IdJenisTransaksi"].Value;
            Tabungan rekeningSumber = (Tabungan)dgvListTransaksi.CurrentRow.Cells["NoRekeningSumber"].Value;
            Tabungan rekeningTujuan = (Tabungan)dgvListTransaksi.CurrentRow.Cells["NoRekeningTujuan"].Value;

            Transaksi trans = new Transaksi(rekeningSumber, idTransaksi, tglTransaksi, 
                jenisTransaksi, rekeningTujuan, nominal, keterangan);
            if (trans != null)
            {
                if (e.ColumnIndex == dgvListTransaksi.Columns["btnUbahGrid"].Index)
                {
                    FormUpdateTransaksi formUpdate = new FormUpdateTransaksi();
                    formUpdate.Owner = this;
                    formUpdate.rekeningSumber = trans.NoRekeningSumber.ToString();
                    formUpdate.idTransaksi = trans.IdTransaksi;
                    formUpdate.ShowDialog();
                }
                else if (e.ColumnIndex == dgvListTransaksi.Columns["btnHapusGrid"].Index)
                {
                    try
                    {
                        DialogResult confirmation = MessageBox.Show("Apakah anda yakin ingin menghapus data transaksi '" + idTransaksi + "'?", "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (confirmation == DialogResult.Yes)
                        {
                            if (trans.HapusData())
                            {
                                MessageBox.Show("Penghapusan data berhasil");
                                FormDaftarTransaksi_Load(sender, e);
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
