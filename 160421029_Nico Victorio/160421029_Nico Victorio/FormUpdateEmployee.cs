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
    public partial class FormUpdateEmployee : Form
    {
        public int idEmployee;
        FormMasterEmployee formMasterEmployee;
        Employee tmp;

        public FormUpdateEmployee()
        {
            InitializeComponent();
        }

        private void FormUpdateEmployee_Load(object sender, EventArgs e)
        {
            formMasterEmployee = (FormMasterEmployee)this.Owner;
            comboBoxPosition.DataSource = formMasterEmployee.listPosition;
            comboBoxPosition.DisplayMember = "nama";
            textBoxID.Enabled = false;
            tmp = Employee.employeeByCode(idEmployee);
            if (tmp != null)
            {
                textBoxID.Text = tmp.Id.ToString();
                textBoxNamaDepan.Text = tmp.NamaDepan;
                textBoxNamaBelakang.Text = tmp.NamaKeluarga;
                comboBoxPosition.SelectedItem = tmp.Position;
                textBoxNIK.Text = tmp.Nik;
                textBoxEmail.Text = tmp.Email;
                textBoxPassword.Text = tmp.Password;
                textBoxUlangiPassword.Text = tmp.Password;
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                Position posDipilih = (Position)comboBoxPosition.SelectedItem;
                Employee emp = new Employee(int.Parse(textBoxID.Text), textBoxNamaDepan.Text,
                textBoxNamaBelakang.Text, posDipilih, textBoxNIK.Text, textBoxEmail.Text,
                textBoxPassword.Text, tmp.TglBuat, DateTime.Now); ;
                if (emp.UbahData())
                {
                    MessageBox.Show("Data employee telah terubah", "Info");

                    formMasterEmployee.FormMasterEmployee_Load(this, e);
                    this.Close();
                }
                else
                {
                    throw new Exception("Tidak dapat mengubah data dalam database");
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
