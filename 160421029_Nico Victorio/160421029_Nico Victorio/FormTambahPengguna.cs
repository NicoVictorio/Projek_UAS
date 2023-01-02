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
    public partial class FormTambahPengguna : System.Windows.Forms.Form
    {
        public FormTambahPengguna()
        {
            InitializeComponent();
        }

        private void buttonBuatAkun_Click(object sender, EventArgs e)
        {
            try
            {
                List<Pangkat> listPangkat = Pangkat.BacaData("kode_pangkat", "BRZ");
                Pangkat pkDipilih = listPangkat[0];
                Pengguna pengguna = new Pengguna(textBoxEmail.Text, int.Parse(textBoxNIK.Text), 
                                           textBoxNamaDepan.Text, textBoxNamaBelakang.Text, 
                                           textBoxAlamat.Text, textBoxNomorTelepon.Text, 
                                           textBoxPassword.Text, "", DateTime.Now, 
                                           DateTime.Now, pkDipilih);

                string noRek = Tabungan.GenerateNoRek();
                Tabungan tab = new Tabungan(noRek, pengguna, 0, 0, "Unverified", "", DateTime.Now, DateTime.Now, null);

                if (pengguna.TambahData(pengguna, noRek))
                {
                    MessageBox.Show("Data Pengguna telah tersimpan", "Info");
                    FormMasterPengguna frm = (FormMasterPengguna)this.Owner;
                    frm.FormMasterPengguna_Load(this, e);
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
            }
        }
    }
}
