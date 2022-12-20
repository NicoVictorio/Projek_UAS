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
    public partial class FormSignInPengguna : Form
    {
        public FormSignInPengguna()
        {
            InitializeComponent();
        }

        private void buttonBuatAkun_Click(object sender, EventArgs e)
        {
            try
            {
                List<Pangkat> listPangkat = Pangkat.BacaData("kode_pangkat", "BRZ");
                Pangkat pkDipilih = listPangkat[0];
                //Pangkat pk = new Pangkat();
                //int dataCount = formPosition.listPosition.Count();
                Pengguna js = new Pengguna(int.Parse(textBoxNIK.Text), textBoxNamaDepan.Text,
                textBoxNamaBelakang.Text, textBoxAlamat.Text, textBoxEmail.Text,
                textBoxNomorTelepon.Text, textBoxPassword.Text, "",
                DateTime.Now, DateTime.Now, pkDipilih);

                //generate no rekening
                string noRek = Tabungan.GenerateNoRek();

                //panggil tabungan.TambahData()
                Tabungan tab = new Tabungan(noRek, js, 0, "Unverified", "", DateTime.Now, DateTime.Now, null);


                if (js.TambahData() && tab.TambahData())
                {

                    MessageBox.Show("Data Pengguna telah tersimpan", "Info");
                    FormLoginPengguna frm = (FormLoginPengguna)this.Owner;
                    frm.FormMasuk_Load(this, e);
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
