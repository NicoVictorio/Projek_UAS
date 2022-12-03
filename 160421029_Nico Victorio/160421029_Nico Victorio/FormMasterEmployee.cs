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
    public partial class FormMasterEmployee : Form
    {
        public List<Employee> listEmployee = new List<Employee>();
        public List<Position> listPosition = new List<Position>();

        public FormMasterEmployee()
        {
            InitializeComponent();
        }

        public void FormMasterEmployee_Load(object sender, EventArgs e)
        {
            listEmployee = Employee.BacaData("", "");
            listPosition = Position.BacaData("", "");
            if (listEmployee.Count > 0)
            {
                dgvListEmployee.DataSource = listEmployee;
                if (dgvListEmployee.Columns.Count < 10)
                {
                    DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
                    buttonColumn.HeaderText = "Aksi";
                    buttonColumn.Text = "Update";
                    buttonColumn.Name = "btnUbahGrid";
                    buttonColumn.UseColumnTextForButtonValue = true;
                    dgvListEmployee.Columns.Add(buttonColumn);

                    DataGridViewButtonColumn btnDeleteColumns = new DataGridViewButtonColumn();
                    btnDeleteColumns.HeaderText = "Aksi";
                    btnDeleteColumns.Text = "Delete";
                    btnDeleteColumns.Name = "btnHapusGrid";
                    btnDeleteColumns.UseColumnTextForButtonValue = true;
                    dgvListEmployee.Columns.Add(btnDeleteColumns);
                }
            }
            else
            {
                dgvListEmployee.DataSource = null;
            }
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            FormTambahEmployee formTambahEmployee = new FormTambahEmployee();
            formTambahEmployee.Owner = this;
            formTambahEmployee.ShowDialog();
        }

        private void tb_Kriteria_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string kriteria = "";
                string nilai = "";

                if (cb_Kriteria.Text == "ID")
                {
                    kriteria = "id";
                }
                else if (cb_Kriteria.Text == "Nama Depan")
                {
                    kriteria = "nama_depan";
                }
                else if (cb_Kriteria.Text == "Nama Belakang")
                {
                    kriteria = "nama_belakang";
                }
                else if (cb_Kriteria.Text == "Position")
                {
                    kriteria = "position_id";
                }
                else if (cb_Kriteria.Text == "NIK")
                {
                    kriteria = "nik";
                }
                else if (cb_Kriteria.Text == "Email")
                {
                    kriteria = "email";
                }
                else if (cb_Kriteria.Text == "Password")
                {
                    kriteria = "password";
                }
                else if (cb_Kriteria.Text == "Tanggal Buat")
                {
                    kriteria = "tgl_buat";
                }
                else if (cb_Kriteria.Text == "Tanggal Perubahan")
                {
                    kriteria = "tgl_perubahan";
                }
                nilai = tb_Kriteria.Text;
                listEmployee = Employee.BacaData(kriteria, nilai);

                if (listEmployee.Count > 0)
                {
                    dgvListEmployee.DataSource = listEmployee;
                }
                else
                {
                    dgvListEmployee.DataSource = null;
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        private void dgvListEmployee_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = int.Parse(dgvListEmployee.CurrentRow.Cells["ID"].Value.ToString());
            string namaDepan = dgvListEmployee.CurrentRow.Cells["namaDepan"].Value.ToString();
            string namaKeluarga = dgvListEmployee.CurrentRow.Cells["namaKeluarga"].Value.ToString();
            Position position = (Position)dgvListEmployee.CurrentRow.Cells["Position"].Value;
            string nik = dgvListEmployee.CurrentRow.Cells["NIK"].Value.ToString();
            string email = dgvListEmployee.CurrentRow.Cells["Email"].Value.ToString();
            string password = dgvListEmployee.CurrentRow.Cells["Password"].Value.ToString();
            DateTime tglBuat = (DateTime)dgvListEmployee.CurrentRow.Cells["tglBuat"].Value;
            DateTime tglPerubahan = (DateTime)dgvListEmployee.CurrentRow.Cells["tglPerubahan"].Value;

            Employee emp = new Employee(id, namaDepan, namaKeluarga, position, nik, email, password, tglBuat, tglPerubahan);
            if (emp != null)
            {
                if (e.ColumnIndex == dgvListEmployee.Columns["btnUbahGrid"].Index)
                {
                    FormUpdateEmployee formUpdateEmployee = new FormUpdateEmployee();
                    formUpdateEmployee.Owner = this;
                    formUpdateEmployee.idEmployee = emp.Id;
                    formUpdateEmployee.ShowDialog();
                }
                else if (e.ColumnIndex == dgvListEmployee.Columns["btnHapusGrid"].Index)
                {
                    try
                    {
                        DialogResult confirmation = MessageBox.Show("Apakah anda yakin ingin menghapus data employee '" + emp.NamaDepan + "'?", "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (confirmation == DialogResult.Yes)
                        {
                            if (emp.HapusData())
                            {
                                MessageBox.Show("Penghapusan data berhasil");
                                FormMasterEmployee_Load(sender, e);
                            }
                            else
                            {
                                MessageBox.Show("Penghapusan data gagal");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
