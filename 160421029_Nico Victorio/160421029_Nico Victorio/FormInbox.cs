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
    public partial class FormInbox : System.Windows.Forms.Form
    {
        public List<Inbox> listInbox = new List<Inbox>();
        public Pengguna pengguna;
        public Inbox inx;
        FormMenu formMenu;
        public FormInbox()
        {
            InitializeComponent();
        }

        public void FormInbox_Load(object sender, EventArgs e)
        {
            formMenu = (FormMenu)this.MdiParent;
            pengguna = formMenu.tmpPengguna;

            FormatDataGrid();
            listInbox = Inbox.DaftarPesan(pengguna.Email, "", "");
            btn_Add.Visible = false;

            dgvListInbox.Rows.Clear();
            if (listInbox.Count > 0)
            {
                foreach(Inbox inbox in listInbox)
                {
                    dgvListInbox.Rows.Add(inbox.Pesan, inbox.TglKirim, inbox.Status);
                    if (dgvListInbox.Columns.Count < 4)
                    {
                        DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
                        buttonColumn.HeaderText = "Aksi";
                        buttonColumn.Text = "Ubah Status";
                        buttonColumn.Name = "btnUbahStatusGrid";
                        buttonColumn.UseColumnTextForButtonValue = true;
                        dgvListInbox.Columns.Add(buttonColumn);

                        DataGridViewButtonColumn btnDeleteColumns = new DataGridViewButtonColumn();
                        btnDeleteColumns.HeaderText = "Aksi";
                        btnDeleteColumns.Text = "Delete";
                        btnDeleteColumns.Name = "btnHapusGrid";
                        btnDeleteColumns.UseColumnTextForButtonValue = true;
                        dgvListInbox.Columns.Add(btnDeleteColumns);
                    }
                }
            }
            else
            {
                dgvListInbox.DataSource = null;
            }
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            FormTambahInbox formTambahInbox = new FormTambahInbox();
            formTambahInbox.Owner = this;
            formTambahInbox.ShowDialog();
        }

        private void dgvListInbox_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int idPesan = int.Parse(dgvListInbox.CurrentRow.Cells["IdPesan"].Value.ToString());
            Pengguna pengguna = (Pengguna)dgvListInbox.CurrentRow.Cells["Pengguna"].Value;
            string pesan = dgvListInbox.CurrentRow.Cells["Pesan"].Value.ToString();
            DateTime tglKirim = (DateTime)dgvListInbox.CurrentRow.Cells["tglKirim"].Value;
            string status = dgvListInbox.CurrentRow.Cells["status"].Value.ToString();
            DateTime tglPerubahan = (DateTime)dgvListInbox.CurrentRow.Cells["tglPerubahan"].Value;

            inx = new Inbox(idPesan, pengguna, pesan, tglKirim, status, tglPerubahan);
            if (inx != null)
            {
                if (e.ColumnIndex == dgvListInbox.Columns["btnUbahStatusGrid"].Index)
                {
                    if (inx.UbahStatus())
                    {
                        MessageBox.Show("Ganti Status berhasil");
                        FormInbox_Load(sender, e);

                    }
                }
                else if (e.ColumnIndex == dgvListInbox.Columns["btnHapusGrid"].Index)
                {
                    try
                    {
                        DialogResult confirmation = MessageBox.Show("Apakah anda yakin ingin menghapus data Inbox '" + inx.IdPesan + "'?", "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (confirmation == DialogResult.Yes)
                        {
                            if (inx.HapusData())
                            {
                                MessageBox.Show("Penghapusan data berhasil");
                                FormInbox_Load(sender, e);
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

        private void tb_Kriteria_TextChanged(object sender, EventArgs e)
        {
            string kriteria = "";
            string nilai = "";

            if (cb_Kriteria.Text == "Id Pesan")
            {
                kriteria = "id_pesan";
            }
            else if (cb_Kriteria.Text == "Id Pengguna")
            {
                kriteria = "pengguna_id";
            }
            else if (cb_Kriteria.Text == "Pesan")
            {
                kriteria = "pesan";
            }
            else if (cb_Kriteria.Text == "Tanggal Kirim")
            {
                kriteria = "tanggal_kirim";
            }
            else if (cb_Kriteria.Text == "Status")
            {
                kriteria = "status";
            }
            else if (cb_Kriteria.Text == "Tanggal Perubahan")
            {
                kriteria = "tgl_perubahan";
            }
            
            nilai = tb_Kriteria.Text;
            listInbox = Inbox.BacaData(kriteria, nilai);

            if (listInbox.Count > 0)
            {
                dgvListInbox.DataSource = listInbox;
            }
            else
            {
                dgvListInbox.DataSource = null;
            }
        }

        private void FormatDataGrid()
        {
            dgvListInbox.Columns.Clear();

            dgvListInbox.Columns.Add("pesan", "Pesan");
            dgvListInbox.Columns.Add("tglKirim", "Tanggal Kirim");
            dgvListInbox.Columns.Add("status", "Status");

            dgvListInbox.Columns["pesan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvListInbox.Columns["tglKirim"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvListInbox.Columns["status"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dgvListInbox.AllowUserToAddRows = false;
            dgvListInbox.ReadOnly = true;
        }
    }
}
