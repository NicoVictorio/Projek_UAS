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
        public Employee tmpEmployee;
        public DialogResult asEmployee, asPengguna;
        public FormStart()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            FormLogin form = new FormLogin();
            form.Owner = this;
            if (form.ShowDialog() == DialogResult.OK) // dialogresult formlogin ke formstart
            {
                this.DialogResult = DialogResult.OK; // dialogresult formstart ke formmenu
                FormMenu formMenu = (FormMenu)this.Owner;
                if (tmpEmployee != null)
                {
                    formMenu.tmpEmp = tmpEmployee;
                }
                else if (tmpPengguna != null)
                {
                    formMenu.tmpPengguna = tmpPengguna;
                }
                this.Close();
            }
        }

        private void buttonSignUp_Click(object sender, EventArgs e)
        {
            FormSignUp form = new FormSignUp();
            form.Owner = this;
            if (form.ShowDialog() == DialogResult.OK)
            {
                this.DialogResult = DialogResult.OK;
                FormMenu formmenu = (FormMenu)this.Owner;
                this.Close();
            }
        }
    }
}
