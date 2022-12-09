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
    public partial class FormUpdatePengguna : System.Windows.Forms.Form
    {
        public string nik;
        FormMasterPengguna formMasterPengguna;
        Pengguna tmp;
        public FormUpdatePengguna()
        {
            InitializeComponent();
        }

        private void FormUpdatePengguna_Load(object sender, EventArgs e)
        {
            formMasterPengguna = (FormMasterPengguna)this.Owner;
            textBoxNIK.Enabled = false;
            tmp = Pengguna.penggunaByCode(nik);
            if (tmp != null)
            {
                textBoxNIK.Text = tmp.Nik.ToString();
                textBoxNamaDepan.Text = tmp.NamaDepan;
                textBoxNamaBelakang.Text = tmp.NamaKeluarga;
                textBoxAlamat.Text = tmp.Alamat;
                textBoxEmail.Text = tmp.Email;
                textBoxNomorTelepon.Text = tmp.NoTelp;
                textBoxPassword.Text = tmp.Password;
                textBoxPin.Text = tmp.Pin;
            }
        }

        private void buttonUpdateData_Click(object sender, EventArgs e)
        {
            try
            {
                Pengguna k = new Pengguna(int.Parse(textBoxNIK.Text),textBoxNamaDepan.Text,
                    textBoxNamaBelakang.Text,textBoxAlamat.Text,textBoxEmail.Text,
                    textBoxNomorTelepon.Text,textBoxPassword.Text,textBoxPin.Text,
                    tmp.TglBuat,DateTime.Now,tmp.Pangkat); 
                if (k.UbahData())
                {
                    MessageBox.Show("Data Pengguna telah terubah", "Info");

                    formMasterPengguna.FormMasterPengguna_Load(this, e);
                    this.Close();
                }
                else
                {
                    throw new Exception("Tidak dapat mengubah data dalam database");
                }

            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
