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
                bool checker = textBoxEmail.Text.Contains("@gmail.com");
                if (checker == true)
                {
                    List<Pangkat> listPangkat = Pangkat.BacaData("kode_pangkat", "BRZ");
                    Pangkat pangkat = listPangkat[0];

                    Pengguna pengguna = new Pengguna(textBoxEmail.Text, 0, "", "", "", "",
                                                     textBoxPassword.Text, "",
                                                     DateTime.Now, DateTime.Now, pangkat);

                    string noRek = Tabungan.GenerateNoRek();

                    if (pengguna.TambahData(pengguna, noRek))
                    {
                        MessageBox.Show("Data Pengguna telah tersimpan", "Info");
                        FormStart frm = (FormStart)this.Owner;
                        this.Close();
                    }
                    else
                    {
                        throw new Exception("Tidak dapat menambahkan data dalam database");
                    }
                }
                else
                {
                    throw new Exception("Email tidak valid");
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
