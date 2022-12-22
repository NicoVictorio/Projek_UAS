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
    public partial class FormBuatPin : Form
    {
        FormMenu formMenu;
        public Pengguna pengguna;
        public Tabungan tabPengguna;
        public FormBuatPin()
        {
            InitializeComponent();
        }

        private void FormBuatPin_Load(object sender, EventArgs e)
        {
            formMenu = (FormMenu)this.Owner;
            pengguna = formMenu.tmpPengguna;
            tabPengguna = formMenu.tabPengguna;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (textBoxPin.Text != textBoxUlangiPin.Text)
            {
                MessageBox.Show("Cek kembali pin anda");
            }
            else
            {
                if (pengguna.TambahPin(textBoxPin.Text))
                {
                    MessageBox.Show("Pin berhasil ditambahkan");
                    this.Close();
                }
            }
        }
    }
}
