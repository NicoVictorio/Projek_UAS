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
    public partial class FormDaftarAddressBook : System.Windows.Forms.Form
    {
        FormMenu formMenu;
        public Pengguna penggunaLogin;
        public List<AddressBook> listAddressBook = new List<AddressBook>();
        public FormDaftarAddressBook()
        {
            InitializeComponent();
        }

        public void FormDaftarAddressBook_Load(object sender, EventArgs e)
        {
            formMenu = (FormMenu)this.MdiParent;
            penggunaLogin = formMenu.tmpPengguna;

            listAddressBook = AddressBook.BacaDataEmployee("pengguna_email", penggunaLogin.Email.ToString());
            if (listAddressBook.Count > 0)
            {
                dgvListAddressBook.DataSource = listAddressBook;
                if (dgvListAddressBook.Columns.Count < 4)
                {
                    DataGridViewButtonColumn btnDeleteColumns = new DataGridViewButtonColumn();
                    btnDeleteColumns.HeaderText = "Aksi";
                    btnDeleteColumns.Text = "Delete";
                    btnDeleteColumns.Name = "btnHapusGrid";
                    btnDeleteColumns.UseColumnTextForButtonValue = true;
                    dgvListAddressBook.Columns.Add(btnDeleteColumns);
                }
            }
            else
            {
                dgvListAddressBook.DataSource = null;
            }
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            FormTambahAddressBook formTambahAddressBook = new FormTambahAddressBook();
            formTambahAddressBook.Owner = this;
            formTambahAddressBook.ShowDialog();
        }

        private void tb_Kriteria_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string kriteria = "";
                string nilai = "";

                if (cb_Kriteria.Text == "Keterangan")
                {
                    kriteria = "keterangan";
                }
                else if (cb_Kriteria.Text == "Pengguna")
                {
                    kriteria = "pengguna_email";
                }
                else if (cb_Kriteria.Text == "Nomor Rekening")
                {
                    kriteria = "no_rekening";
                }

                nilai = tb_Kriteria.Text;
                listAddressBook = AddressBook.BacaDataPengguna(kriteria, nilai, formMenu.tmpPengguna.Email);

                if (listAddressBook.Count > 0)
                {
                    dgvListAddressBook.DataSource = listAddressBook;
                }
                else
                {
                    dgvListAddressBook.DataSource = null;
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        private void dgvListAddressBook_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string keterangan = dgvListAddressBook.CurrentRow.Cells["keterangan"].Value.ToString();

            Pengguna pengguna = (Pengguna)dgvListAddressBook.CurrentRow.Cells["pengguna"].Value;
            Tabungan noRek = (Tabungan)dgvListAddressBook.CurrentRow.Cells["tabungan"].Value;

            AddressBook address = new AddressBook(noRek, pengguna, keterangan);
            if (address != null)
            {
                if (e.ColumnIndex == dgvListAddressBook.Columns["btnHapusGrid"].Index)
                {
                    try
                    {
                        DialogResult confirmation = MessageBox.Show("Apakah anda yakin ingin menghapus data address book '" + address.Pengguna.Nik + "'?", "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (confirmation == DialogResult.Yes)
                        {
                            if (address.HapusData())
                            {
                                MessageBox.Show("Penghapusan data berhasil");
                                FormDaftarAddressBook_Load(sender, e);
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
