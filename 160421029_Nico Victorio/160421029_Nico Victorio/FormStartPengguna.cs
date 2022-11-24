using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _160421029_Nico_Victorio
{
    public partial class FormStartPengguna : Form
    {
        FormStart formStart;
        public FormStartPengguna()
        {
            InitializeComponent();
        }

        private void buttonBuatAkun_Click(object sender, EventArgs e)
        {
            FormBuatAkun form = new FormBuatAkun();
            form.Owner = this;
            this.Hide();
            form.ShowDialog();
        }

        private void buttonMasuk_Click(object sender, EventArgs e)
        {
            FormMasuk form = new FormMasuk();
            form.Owner = this;
            this.Hide();
            form.ShowDialog();
        }

        private void buttonKembali_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormStartPengguna_Load(object sender, EventArgs e)
        {
            formStart = (FormStart)this.Owner;
        }

        private void FormStartPengguna_FormClosing(object sender, FormClosingEventArgs e)
        {
            formStart.Show();
        }
    }
}
