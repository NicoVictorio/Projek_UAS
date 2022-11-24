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
    public partial class FormMasterPengguna : Form
    {
        public List<Pengguna> listPengguna = new List<Pengguna>();
        public FormMasterPengguna()
        {
            InitializeComponent();
        }

        private void FormMasterPengguna_Load(object sender, EventArgs e)
        {
            listPengguna = Pengguna.BacaData("", "");
            if (listPengguna.Count > 0)
            {
                dgvListPengguna.DataSource = listPengguna;
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
    }
}
