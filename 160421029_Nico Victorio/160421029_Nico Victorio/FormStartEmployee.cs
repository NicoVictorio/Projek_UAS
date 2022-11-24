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
    public partial class FormStartEmployee : Form
    {
        FormStart formStart;
        public FormStartEmployee()
        {
            InitializeComponent();
        }

        private void buttonKembali_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {

        }

        private void FormStartEmployee_Load(object sender, EventArgs e)
        {
            formStart = (FormStart)this.Owner;
        }

        private void FormStartEmployee_FormClosing(object sender, FormClosingEventArgs e)
        {
            formStart.Show();
        }
    }
}
