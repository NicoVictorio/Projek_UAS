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
    public partial class FormStart : Form
    {
        public FormStart()
        {
            InitializeComponent();
        }

        private void buttonPengguna_Click(object sender, EventArgs e)
        {
            FormStartPengguna form = new FormStartPengguna();
            form.Owner = this;
            this.Hide();
            form.ShowDialog();
        }

        private void buttonEmployee_Click(object sender, EventArgs e)
        {
            FormStartEmployee form = new FormStartEmployee();
            form.Owner = this;
            this.Hide();
            form.ShowDialog();
        }
    }
}
