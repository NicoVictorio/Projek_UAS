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
    public partial class FormMutasiRekening : Form
    {
        public Pengguna penggunaAsal;
        public Tabungan tabunganAsal;
        public FormMutasiRekening()
        {
            InitializeComponent();
        }

        private void FormMutasiRekening_Load(object sender, EventArgs e)
        {
            textBoxNomorRekening.Text = tabunganAsal.NoRekening;
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            FormPin formPin = new FormPin();
            formPin.Owner = this;

            if(formPin.ShowDialog() == DialogResult.OK)
            {
                FormDaftarMutasi formDaftarMutasi = new FormDaftarMutasi();
                formDaftarMutasi.Owner = this;
                formDaftarMutasi.tabPengguna = tabunganAsal;
            }
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
