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
    public partial class FormPin : Form
    {
        FormTambahTransaksi formTambahTransaksi;
        Pengguna pengguna;
        int count = 0;
        public FormPin()
        {
            InitializeComponent();
        }

        private void FormPin_Load(object sender, EventArgs e)
        {
            formTambahTransaksi = (FormTambahTransaksi)this.Owner;
            pengguna = formTambahTransaksi.penggunaAsal;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if(textBoxPin.Text != pengguna.Pin)
            {
                MessageBox.Show("Maaf pin anda salah");
                count++;
                if(count == 3)
                {
                    MessageBox.Show("Anda salah memasukkan PIN 3 kali ");
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                }
            }
            else
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
