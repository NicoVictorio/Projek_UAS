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
    public partial class FormMasterJenisTransaksi : System.Windows.Forms.Form
    {
        public List<JenisTransaksi> listTransaksi = new List<JenisTransaksi>();
        
        public FormMasterJenisTransaksi()
        {
            InitializeComponent();
        }

        public void FormJenisTransaksi_Load(object sender, EventArgs e)
        {
            listTransaksi = JenisTransaksi.BacaData("", "");
            dgvListJenisTransaksi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            if (listTransaksi.Count > 0)
            {
                dgvListJenisTransaksi.DataSource = listTransaksi; 
                if (dgvListJenisTransaksi.Columns.Count < 4)
                {
                    DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
                    buttonColumn.HeaderText = "Aksi";
                    buttonColumn.Text = "Update";
                    buttonColumn.Name = "btnUbahGrid";
                    buttonColumn.UseColumnTextForButtonValue = true;
                    dgvListJenisTransaksi.Columns.Add(buttonColumn);

                    DataGridViewButtonColumn btnDeleteColumns = new DataGridViewButtonColumn();
                    btnDeleteColumns.HeaderText = "Aksi";
                    btnDeleteColumns.Text = "Delete";
                    btnDeleteColumns.Name = "btnHapusGrid";
                    btnDeleteColumns.UseColumnTextForButtonValue = true;
                    dgvListJenisTransaksi.Columns.Add(btnDeleteColumns);
                }
            }
            else
            {
                dgvListJenisTransaksi.DataSource = null;
            }
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {

        }

        private void tb_Kriteria_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string kriteria = "";
                string nilai = "";
                if (cb_Kriteria.Text == "Id Jenis Transaksi")
                {
                    kriteria = "id_jenistransaksi";
                }
                else if (cb_Kriteria.Text == "Kode Transaksi")
                {
                    kriteria = "kode";
                }
                else if (cb_Kriteria.Text == "Nama Transaksi")
                {
                    kriteria = "nama";
                }
                nilai = tb_Kriteria.Text;
                listTransaksi = JenisTransaksi.BacaData(kriteria, nilai);

                if (listTransaksi != null && listTransaksi.Count > 0)
                {
                    dgvListJenisTransaksi.DataSource = listTransaksi;
                }
                else
                {
                    dgvListJenisTransaksi.DataSource = null;
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            FormTambahJenisTransaksi frm = new FormTambahJenisTransaksi();
            frm.Owner = this;
            frm.ShowDialog();
        }

        private void dgvListPosition_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int pIdTransaksi = (int)dgvListJenisTransaksi.CurrentRow.Cells["idJenisTransaksi"].Value;
            string pKodeTransaksi = dgvListJenisTransaksi.CurrentRow.Cells["kodetransaksi"].Value.ToString();
            string pNamaTransaksi = dgvListJenisTransaksi.CurrentRow.Cells["namatransaksi"].Value.ToString();
            JenisTransaksi k = new JenisTransaksi(pIdTransaksi, pKodeTransaksi, pNamaTransaksi);
            //Kategori k = Kategori.AmbilDataKolom(pKodeKategori);
            if (k != null)
            {
                if (e.ColumnIndex == dgvListJenisTransaksi.Columns["btnUbahGrid"].Index && e.RowIndex >= 0)
                {
                    FormUpdateJenisTransaksi formUpdateJenis = new FormUpdateJenisTransaksi();
                    formUpdateJenis.Owner = this;
                    //formUpdateJenis.kodeJenisTransaksi = k.KodeTransaksi;
                    formUpdateJenis.idJenisTransaksi = k.IdJenisTransaksi;
                    formUpdateJenis.ShowDialog();
                }
                else if (e.ColumnIndex == dgvListJenisTransaksi.Columns["btnHapusGrid"].Index && e.RowIndex >= 0)
                {
                    try
                    {
                        DialogResult deleteConfirm = MessageBox.Show("Apakah anda yakin ingin " +
                            "menghapus data kategori " + k.NamaTransaksi + " ?",
                            "Konfirmasi Hapus", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);
                        if (deleteConfirm == DialogResult.Yes)
                        {
                            k.HapusData();
                            MessageBox.Show("Data kategori telah dihapus");
                            FormJenisTransaksi_Load(sender, e);
                        }
                    }
                    catch (Exception x)
                    {
                        MessageBox.Show(x.Message, "Error", MessageBoxButtons.OK);
                    }
                }
            }
            else
            {
                MessageBox.Show("Terdapat kesalahan pada data");
            }
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
