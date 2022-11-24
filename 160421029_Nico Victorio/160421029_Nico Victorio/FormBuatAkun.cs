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
    public partial class FormBuatAkun : Form
    {
        FormStartPengguna formStartPengguna;
        public FormBuatAkun()
        {
            InitializeComponent();
        }

        private void FormBuatAkun_Load(object sender, EventArgs e)
        {
            formStartPengguna = (FormStartPengguna)this.Owner;
        }

        private void FormBuatAkun_FormClosing(object sender, FormClosingEventArgs e)
        {
            formStartPengguna.Show();
        }
    }
}
