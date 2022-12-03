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
    public partial class FormTambahEmployee : Form
    {
        FormMasterEmployee formEmployee;

        public FormTambahEmployee()
        {
            InitializeComponent();
        }

        private void FormTambahEmployee_Load(object sender, EventArgs e)
        {
            formEmployee = (FormMasterEmployee)this.Owner;

            comboBoxPosition.DataSource = formEmployee.listPosition;
            comboBoxPosition.DisplayMember = "nama";
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Position posDipilih = (Position)comboBoxPosition.SelectedItem;
                Employee emp = new Employee(0, textBoxNamaDepan.Text,
                textBoxNamaBelakang.Text, posDipilih, textBoxNIK.Text, textBoxEmail.Text,
                textBoxPassword.Text, DateTime.Now, DateTime.Now);
                if (emp.TambahData())
                {
                    MessageBox.Show("Data employee telah tersimpan", "Info");
                    FormMasterEmployee frm = (FormMasterEmployee)this.Owner;
                    frm.FormMasterEmployee_Load(this, e);
                    this.Close();
                }
                else
                {
                    throw new Exception("Tidak dapat menambahkan data dalam database");
                }

            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
