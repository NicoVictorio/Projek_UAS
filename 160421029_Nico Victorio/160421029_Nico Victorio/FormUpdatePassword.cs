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
    public partial class FormUpdatePassword : System.Windows.Forms.Form
    {
        public Pengguna tmpPengguna;
        public FormMenu formMenu;
        public FormUpdatePassword()
        {
            InitializeComponent();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if(textBoxPasswordLama.Text != tmpPengguna.Password)
                {
                    throw new Exception("Password tidak sama dengan data tersimpan");
                }
                else if (textBoxPasswordBaru.Text != textBoxUlangiPasswordBaru.Text)
                {
                    throw new Exception("Password tidak sama");
                }

                Pengguna k = new Pengguna(tmpPengguna.Nik, tmpPengguna.NamaDepan,
                    tmpPengguna.NamaKeluarga, tmpPengguna.Alamat, tmpPengguna.Email,
                    tmpPengguna.NoTelp, textBoxPasswordBaru.Text, tmpPengguna.Pin,
                    tmpPengguna.TglBuat, DateTime.Now, tmpPengguna.Pangkat);
                if (k.UbahData())
                {
                    MessageBox.Show("Data Password telah terubah", "Info");
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

        private void FormUpdatePassword_Load(object sender, EventArgs e)
        {
            formMenu = (FormMenu)this.MdiParent;
            tmpPengguna = Pengguna.penggunaByCode(formMenu.tmpPengguna.Nik.ToString());
        }
    }
}
