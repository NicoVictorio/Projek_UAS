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
    public partial class FormTambahTabungan : Form
    {
        public FormTambahTabungan()
        {
            InitializeComponent();
        }

        private void FormTambahTabungan_Load(object sender, EventArgs e)
        {
            List<Pengguna> listPengguna = Pengguna.BacaData("","");

            comboBoxPengguna.DataSource = listPengguna;
            comboBoxPengguna.DisplayMember = "nik";
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            try
            {
                Pengguna pgDipilih = (Pengguna)comboBoxPengguna.SelectedItem;
                string noRek = Tabungan.GenerateNoRek();
                Tabungan tb = new Tabungan(noRek, pgDipilih, 0, "", "", DateTime.Now, DateTime.Now, null);

                if (tb.TambahData())
                {

                    MessageBox.Show("Data Tabungan telah tersimpan", "Info");
                    FormDaftarTabungan frm = (FormDaftarTabungan)this.Owner;
                    frm.FormDaftarTabungan_Load(this, e);
                    this.Close();
                }
                else
                {
                    throw new Exception("Tidak dapat menambahkan data dalam database");
                }

            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //MessageBox.Show("Penyimpanan gagal. Pesan kesalahan: " + x.Message, "Kesalahan");
            }
        }
    }
}
