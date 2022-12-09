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
    public partial class FormMasterPengguna : System.Windows.Forms.Form
    {
        public List<Pengguna> listPengguna = new List<Pengguna>();
        public List<Pangkat> listPangkat = new List<Pangkat>();
        public FormMasterPengguna()
        {
            InitializeComponent();
        }

        public void FormMasterPengguna_Load(object sender, EventArgs e)
        {
            listPengguna = Pengguna.BacaData("", "");
            listPangkat = Pangkat.BacaData("", "");
            if (listPengguna.Count > 0)
            {
                dgvListPengguna.DataSource = listPengguna;
                if (dgvListPengguna.Columns.Count < 12)
                {
                    DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
                    buttonColumn.HeaderText = "Aksi";
                    buttonColumn.Text = "Update";
                    buttonColumn.Name = "btnUbahGrid";
                    buttonColumn.UseColumnTextForButtonValue = true;
                    dgvListPengguna.Columns.Add(buttonColumn);

                    DataGridViewButtonColumn btnDeleteColumns = new DataGridViewButtonColumn();
                    btnDeleteColumns.HeaderText = "Aksi";
                    btnDeleteColumns.Text = "Delete";
                    btnDeleteColumns.Name = "btnHapusGrid";
                    btnDeleteColumns.UseColumnTextForButtonValue = true;
                    dgvListPengguna.Columns.Add(btnDeleteColumns);
                }
            }
            else
            {
                dgvListPengguna.DataSource = null;
            }
        }

        private void tb_Kriteria_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string kriteria = "";
                string nilai = "";

                if (cb_Kriteria.Text == "NIK")
                {
                    kriteria = "nik";
                }
                else if (cb_Kriteria.Text == "Nama Depan")
                {
                    kriteria = "nama_depan";
                }
                else if (cb_Kriteria.Text == "Nama Keluarga")
                {
                    kriteria = "nama_keluarga";
                }
                else if (cb_Kriteria.Text == "Alamat")
                {
                    kriteria = "alamat";
                }
                else if (cb_Kriteria.Text == "Email")
                {
                    kriteria = "email";
                }
                else if (cb_Kriteria.Text == "No Telepon")
                {
                    kriteria = "no_telepon";
                }
                else if (cb_Kriteria.Text == "Password")
                {
                    kriteria = "password";
                }
                else if (cb_Kriteria.Text == "Pin")
                {
                    kriteria = "pin";
                }
                else if (cb_Kriteria.Text == "Tanggal Buat")
                {
                    kriteria = "tgl_buat";
                }
                else if (cb_Kriteria.Text == "Tanggal Perubahan")
                {
                    kriteria = "tgl_perubahan";
                }
                else if (cb_Kriteria.Text == "Kode Pangkat")
                {
                    kriteria = "kode_pangkat";
                }
                nilai = tb_Kriteria.Text;
                listPengguna = Pengguna.BacaData(kriteria, nilai);

                if (listPengguna.Count > 0)
                {
                    dgvListPengguna.DataSource = listPengguna;
                }
                else
                {
                    dgvListPengguna.DataSource = null;
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        private void dgvListPengguna_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //int idPosition = int.Parse(dgvListPengguna.CurrentRow.Cells["idposition"].Value.ToString());
            int nik = (int)dgvListPengguna.CurrentRow.Cells["nik"].Value;
            string namaDepan = dgvListPengguna.CurrentRow.Cells["namadepan"].Value.ToString();
            string namaKeluarga = dgvListPengguna.CurrentRow.Cells["namakeluarga"].Value.ToString();
            string alamat = dgvListPengguna.CurrentRow.Cells["alamat"].Value.ToString();
            string email = dgvListPengguna.CurrentRow.Cells["email"].Value.ToString();
            string noTelp = dgvListPengguna.CurrentRow.Cells["noTelp"].Value.ToString();
            string password = dgvListPengguna.CurrentRow.Cells["password"].Value.ToString();
            string pin = dgvListPengguna.CurrentRow.Cells["pin"].Value.ToString();
            DateTime tglBuat =(DateTime) dgvListPengguna.CurrentRow.Cells["tglBuat"].Value;
            DateTime tglPerubahan = (DateTime)dgvListPengguna.CurrentRow.Cells["tglPerubahan"].Value;
            Pangkat pangkat = (Pangkat)dgvListPengguna.CurrentRow.Cells["pangkat"].Value;

            Pengguna pos = new Pengguna(nik, namaDepan, namaKeluarga, alamat, email, noTelp, 
                                        password, pin, tglBuat, tglPerubahan, pangkat);
            if (pos != null)
            {
                if (e.ColumnIndex == dgvListPengguna.Columns["btnUbahGrid"].Index)
                {
                    FormUpdatePengguna formUpdate = new FormUpdatePengguna();
                    formUpdate.Owner = this;
                    formUpdate.nik = pos.Nik.ToString();
                    formUpdate.ShowDialog();
                }
                else if (e.ColumnIndex == dgvListPengguna.Columns["btnHapusGrid"].Index)
                {
                    try
                    {
                        DialogResult confirmation = MessageBox.Show("Apakah anda yakin ingin menghapus data position '" + pos.NamaDepan + "'?", "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (confirmation == DialogResult.Yes)
                        {
                            if (pos.HapusData())
                            {
                                MessageBox.Show("Penghapusan data berhasil");
                                FormMasterPengguna_Load(sender, e);
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

        private void btn_Add_Click(object sender, EventArgs e)
        {
            FormTambahPengguna formBuatAkun = new FormTambahPengguna();
            formBuatAkun.Owner = this;
            formBuatAkun.ShowDialog();
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
