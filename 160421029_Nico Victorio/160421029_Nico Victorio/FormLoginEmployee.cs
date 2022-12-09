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
    public partial class FormLoginEmployee : System.Windows.Forms.Form
    {
        public Employee tmpEmp;

        public FormLoginEmployee()
        {
            InitializeComponent();
        }

        private void FormLoginEmployee_Load(object sender, EventArgs e)
        {
            try
            {
                Koneksi koneksi = new Koneksi(dbSetting.Default.hostname, dbSetting.Default.dbname,
                                  dbSetting.Default.uid, dbSetting.Default.password);
                MessageBox.Show("Koneksi berhasil");
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message, "Error");
            }
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxEmail.Text == "")
                {
                    throw new Exception("Email/No Telepon tidak boleh kosong");
                }
                if (textBoxPassword.Text == "")
                {
                    throw new Exception("Password tidak boleh kosong");
                }
                tmpEmp = Employee.Login(textBoxEmail.Text, textBoxPassword.Text);
                if (tmpEmp != null)
                {
                    this.DialogResult = DialogResult.OK;
                    FormStart form = (FormStart)this.Owner;
                    form.tmpEmp = tmpEmp;
                }
                else
                {
                    throw new Exception("Kombinasi username dan password tidak ditemukan");
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message, "Error");
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
