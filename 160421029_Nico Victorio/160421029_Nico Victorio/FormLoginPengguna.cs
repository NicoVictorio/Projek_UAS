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
    public partial class FormLoginPengguna : Form
    {
        public Pengguna tmp;
        //FormLogin formLogin;
        public FormLoginPengguna()
        {
            InitializeComponent();
        }

        private void FormMasuk_Load(object sender, EventArgs e)
        {
            try
            {
                Koneksi koneksi = new Koneksi(dbSetting.Default.hostname, dbSetting.Default.dbname,
                                  dbSetting.Default.uid, dbSetting.Default.password);
                MessageBox.Show("Koneksi berhasil");
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message, "Error");
            }
        }

        private void buttonMasuk_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxEmailNoTelp.Text == "")
                {
                    throw new Exception("Email/No Telepon tidak boleh kosong");
                }
                if (textBoxPassword.Text == "")
                {
                    throw new Exception("Password tidak boleh kosong");
                }
                tmp = Pengguna.Login(textBoxEmailNoTelp.Text, textBoxPassword.Text);
                if (tmp != null)
                {
                    this.DialogResult = DialogResult.OK;
                    FormStart form = (FormStart)this.Owner;
                    form.tmpPengguna = tmp;
                }
                else
                {
                    throw new Exception("Kombinasi username dan password tidak ditemukan");
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message, "Error");
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
