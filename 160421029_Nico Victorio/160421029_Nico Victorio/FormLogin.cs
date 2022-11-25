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
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void loginPenggunaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormMasuk frm = new FormMasuk();
            //frm.Owner = this;
            frm.ShowDialog();
        }

        private void loginEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormStartEmployee frm = new FormStartEmployee();
            frm.Owner = this;
            frm.ShowDialog();
        }

        private void buatAkunPenggunaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormBuatAkun frm = new FormBuatAkun();
            frm.Owner = this;
            frm.ShowDialog();
        }
    }
}
