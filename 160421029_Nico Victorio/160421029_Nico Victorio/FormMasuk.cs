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
    public partial class FormMasuk : Form
    {
        FormStartPengguna formStartPengguna;
        public FormMasuk()
        {
            InitializeComponent();
        }

        private void FormMasuk_Load(object sender, EventArgs e)
        {
            formStartPengguna = (FormStartPengguna)this.Owner;
        }

        private void FormMasuk_FormClosing(object sender, FormClosingEventArgs e)
        {
            formStartPengguna.Show();
        }
    }
}
