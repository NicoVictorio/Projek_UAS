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
    public partial class FormTambahInbox : Form
    {
        
        public FormTambahInbox()
        {
            InitializeComponent();
        }

        private void FormTambahInbox_Load(object sender, EventArgs e)
        {
            FormInbox formInbox = (FormInbox)this.Owner;
            List<Pengguna> lisPengguna = Pengguna.BacaData("", "");

            comboBoxIdPengguna.DataSource = lisPengguna;
            comboBoxIdPengguna.DisplayMember = "Nik";
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            try
            {
                Pengguna penggunaDipilih = (Pengguna) comboBoxIdPengguna.SelectedItem;
                Inbox js = new Inbox(0, penggunaDipilih, textBoxPesan.Text,DateTime.Now,"Belum Terbaca",DateTime.Now); ;
                if (js.TambahData())
                {
                    MessageBox.Show("Data Inbox telah tersimpan", "Info");
                    FormInbox frm = (FormInbox)this.Owner;
                    frm.FormInbox_Load(this, e);
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

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
