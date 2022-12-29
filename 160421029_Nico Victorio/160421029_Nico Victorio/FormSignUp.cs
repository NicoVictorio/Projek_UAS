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
    public partial class FormSignUp : Form
    {
        FormMenu formMenu;
        public Pengguna tmpPengguna;
        public Employee tmpEmployee;
        public FormSignUp()
        {
            InitializeComponent();
        }

        private void FormSignUp_Load(object sender, EventArgs e)
        {
            formMenu = (FormMenu)this.MdiParent;
        }

        private void buttonSignUp_Click(object sender, EventArgs e)
        {
            try
            {
                List<Pangkat> listPangkat = Pangkat.BacaData("kode_pangkat", "BRZ");
                Pangkat pkDipilih = listPangkat[0];
                Pengguna pengguna = new Pengguna(0, 0, "", "", "", textBoxEmail.Text,
                                           "", textBoxPassword.Text, "",
                                           DateTime.Now, DateTime.Now, pkDipilih);
           
                string noRek = Tabungan.GenerateNoRek();

                Tabungan tab = new Tabungan(noRek, pengguna, 0, "Unverified", "", DateTime.Now, DateTime.Now, null);

                if (pengguna.TambahData() && tab.TambahData())
                {
                    MessageBox.Show("Data Pengguna telah tersimpan", "Info");
                    FormLogin frm = (FormLogin)this.Owner;
                    frm.FormLogin_Load(this, e);
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

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
