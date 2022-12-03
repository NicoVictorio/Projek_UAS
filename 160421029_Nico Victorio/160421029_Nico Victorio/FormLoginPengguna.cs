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
        //FormLogin formLogin;
        public FormLoginPengguna()
        {
            InitializeComponent();
        }

        private void FormMasuk_Load(object sender, EventArgs e)
        {
            //formLogin = (FormLogin)this.Owner;
        }

        private void FormMasuk_FormClosing(object sender, FormClosingEventArgs e)
        {
            //formStartPengguna.Show();
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
                Pengguna tmp = Pengguna.Login(textBoxEmailNoTelp.Text, textBoxPassword.Text);
                if (tmp != null)
                {
                    this.DialogResult = DialogResult.OK;

                    FormMenu frm = (FormMenu)this.Owner;
                    frm.tmpPengguna = tmp;

                    this.Close();
                }
                else
                {
                    throw new Exception("Data pengguna tidak ditemukan");
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message, "Error");
            }
        }
    }
}
