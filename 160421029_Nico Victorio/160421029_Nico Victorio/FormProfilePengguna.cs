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
    public partial class FormProfilePengguna : Form
    {
        FormMenu formMenu;
        public Pengguna tmpPengguna;
        public FormProfilePengguna()
        {
            InitializeComponent();
        }

        private void FormProfilePengguna_Load(object sender, EventArgs e)
        {
            formMenu = (FormMenu)this.MdiParent;
            buttonSave.Text = "Update";

            textBoxNamaDepan.Enabled = false;
            textBoxNamaDepan.Text = tmpPengguna.NamaDepan;

            textBoxNamaBelakang.Enabled = false;
            textBoxNamaBelakang.Text = tmpPengguna.NamaKeluarga;

            textBoxAlamat.Enabled = false;
            textBoxAlamat.Text = tmpPengguna.Alamat;

            textBoxNIK.Enabled = false;
            textBoxNIK.Text = tmpPengguna.Nik.ToString();

            textBoxNomorTelepon.Enabled = false;
            textBoxNomorTelepon.Text = tmpPengguna.NoTelp;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if(buttonSave.Text == "Update")
            {
                textBoxNamaDepan.Enabled = true;
                textBoxNamaBelakang.Enabled = true;
                textBoxAlamat.Enabled = true;
                textBoxNIK.Enabled = true;
                textBoxNomorTelepon.Enabled = true;
                buttonSave.Text = "Save";
            }
            else if(buttonSave.Text == "Save")
            {
                try
                {
                    Pengguna pengguna = new Pengguna(tmpPengguna.Email,
                                                     int.Parse(textBoxNIK.Text),
                                                     textBoxNamaDepan.Text,
                                                     textBoxNamaBelakang.Text,
                                                     textBoxAlamat.Text,
                                                     textBoxNomorTelepon.Text,
                                                     tmpPengguna.Password,
                                                     tmpPengguna.Pin, tmpPengguna.TglBuat,
                                                     DateTime.Now, tmpPengguna.Pangkat);
                    if (pengguna.UbahData())
                    {
                        MessageBox.Show("Data Pengguna telah terubah", "Info");
                        formMenu.tmpPengguna = pengguna;
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

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
