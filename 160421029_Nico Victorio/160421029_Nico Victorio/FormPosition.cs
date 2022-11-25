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
    public partial class FormPosition : Form
    {
        public List<Position> listPosition = new List<Position>();
        public FormPosition()
        {
            InitializeComponent();
        }

        public void FormPosition_Load(object sender, EventArgs e)
        {
            listPosition = Position.BacaData("", "");
            dgvListPosition.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            if (listPosition != null && listPosition.Count > 0)
            {
                dgvListPosition.DataSource = listPosition;
                if (dgvListPosition.Columns.Count < 4)
                {
                    DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
                    buttonColumn.HeaderText = "Aksi";
                    buttonColumn.Text = "Update";
                    buttonColumn.Name = "btnUbahGrid";
                    buttonColumn.UseColumnTextForButtonValue = true;
                    dgvListPosition.Columns.Add(buttonColumn);

                    DataGridViewButtonColumn btnDeleteColumns = new DataGridViewButtonColumn();
                    btnDeleteColumns.HeaderText = "Aksi";
                    btnDeleteColumns.Text = "Delete";
                    btnDeleteColumns.Name = "btnHapusGrid";
                    btnDeleteColumns.UseColumnTextForButtonValue = true;
                    dgvListPosition.Columns.Add(btnDeleteColumns);
                }
            }
            else
            {
                dgvListPosition.DataSource = null;
            }
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            string kriteria = "";
            string nilai = "";
            if (cb_Kriteria.Text == "Id Position")
            {
                kriteria = "id";
            }
            else if (cb_Kriteria.Text == "Nama Position")
            {
                kriteria = "Nama";
            }
            else if (cb_Kriteria.Text == "Keterangan")
            {
                kriteria = "Keterangan";
            }
            nilai = tb_Kriteria.Text;
            listPosition = Position.BacaData(kriteria, nilai);
            if (listPosition != null && listPosition.Count > 0)
            {
                dgvListPosition.DataSource = listPosition;
            }
            else
            {
                dgvListPosition.DataSource = null;
            }
        }

        private void tb_Kriteria_TextChanged(object sender, EventArgs e)
        {
            string kriteria = "";
            string nilai = "";
            if (cb_Kriteria.Text == "Id Position")
            {
                kriteria = "id";
            }
            else if (cb_Kriteria.Text == "Nama Position")
            {
                kriteria = "Nama";
            }
            else if (cb_Kriteria.Text == "Keterangan")
            {
                kriteria = "Keterangan";
            }
            nilai = tb_Kriteria.Text;
            listPosition = Position.BacaData(kriteria, nilai);
            if (listPosition != null && listPosition.Count > 0)
            {
                dgvListPosition.DataSource = listPosition;
            }
            else
            {
                dgvListPosition.DataSource = null;
            }
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            FormTambahPosition formTambahPosition = new FormTambahPosition();
            formTambahPosition.Owner = this;
            formTambahPosition.ShowDialog();
        }


        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvListPosition_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int idPosition = int.Parse(dgvListPosition.CurrentRow.Cells["idposition"].Value.ToString());
            string namaPosition = dgvListPosition.CurrentRow.Cells["namaposition"].Value.ToString();
            string keterangan = dgvListPosition.CurrentRow.Cells["keterangan"].Value.ToString();
            Position pos = new Position(idPosition, namaPosition, keterangan);
            if (pos != null)
            {
                if (e.ColumnIndex == dgvListPosition.Columns["btnUbahGrid"].Index)
                {
                    FormUpdatePosition formUpdate = new FormUpdatePosition();
                    formUpdate.Owner = this;
                    formUpdate.idPosition = pos.IdPosition;
                    formUpdate.ShowDialog();
                }
                else if (e.ColumnIndex == dgvListPosition.Columns["btnHapusGrid"].Index)
                {
                    try
                    {
                        DialogResult confirmation = MessageBox.Show("Apakah anda yakin ingin menghapus data position '" + pos.NamaPosition + "'?", "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (confirmation == DialogResult.Yes)
                        {
                            if (pos.HapusData())
                            {
                                MessageBox.Show("Penghapusan data berhasil");
                                FormPosition_Load(sender, e);
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
    }
}