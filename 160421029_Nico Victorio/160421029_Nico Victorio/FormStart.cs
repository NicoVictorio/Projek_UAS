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
    public partial class FormStart : System.Windows.Forms.Form
    {
        public Pengguna tmpPengguna;
        public Employee tmpEmp;
        public DialogResult asEmployee, asPengguna;
        public FormStart()
        {
            InitializeComponent();
        }

        private void buttonPengguna_Click(object sender, EventArgs e)
        {
            FormLoginPengguna form = new FormLoginPengguna();
            form.Owner = this;
            if (form.ShowDialog() == DialogResult.OK)
            {
                this.DialogResult = DialogResult.OK;
                this.tmpPengguna = form.tmp;
                FormMenu formmenu = (FormMenu)this.Owner;
                formmenu.tmpPengguna = tmpPengguna;
                this.Close();
            }
        }

        private void buttonEmployee_Click(object sender, EventArgs e)
        {
            FormLoginEmployee form = new FormLoginEmployee();
            form.Owner = this;
            if (form.ShowDialog() == DialogResult.OK)
            {
                this.DialogResult = DialogResult.OK;
                this.tmpEmp = form.tmpEmp;
                FormMenu formmenu = (FormMenu)this.Owner;
                formmenu.tmpEmp = tmpEmp;
                this.Close();
            }
        }
    }
}
