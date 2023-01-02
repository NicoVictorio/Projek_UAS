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
    public partial class FormDaftarRekeningTujuan : Form
    {
        Pengguna pengguna;
        FormTambahTransaksi formTambahTransaksi;
        public List<AddressBook> listAddressBook = new List<AddressBook>();
        public FormDaftarRekeningTujuan()
        {
            InitializeComponent();
        }

        public void FormDaftarRekeningTujuan_Load(object sender, EventArgs e)
        {
            formTambahTransaksi = (FormTambahTransaksi)this.Owner;
            pengguna = formTambahTransaksi.penggunaAsal;
            string emailPengguna = pengguna.Email;

            listAddressBook = AddressBook.BacaDataPengguna("", "", emailPengguna);
            if (listAddressBook.Count > 0)
            {
                dgvListRekeningTujuan.DataSource = listAddressBook;
                if (dgvListRekeningTujuan.Columns.Count < 4)
                {
                    DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
                    buttonColumn.HeaderText = "Aksi";
                    buttonColumn.Text = "Pilih";
                    buttonColumn.Name = "btnPilihGrid";
                    buttonColumn.UseColumnTextForButtonValue = true;
                    dgvListRekeningTujuan.Columns.Add(buttonColumn);
                }
            }
            else
            {
                dgvListRekeningTujuan.DataSource = null;
            }
        }

        private void dgvListRekeningTujuan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string keterangan = dgvListRekeningTujuan.CurrentRow.Cells["keterangan"].Value.ToString();

            Pengguna pengguna = (Pengguna)dgvListRekeningTujuan.CurrentRow.Cells["pengguna"].Value;
            Tabungan noRek = (Tabungan)dgvListRekeningTujuan.CurrentRow.Cells["tabungan"].Value;

            AddressBook address = new AddressBook(noRek, pengguna, keterangan);
            if (address != null)
            {
                if (e.ColumnIndex == dgvListRekeningTujuan.Columns["btnPilihGrid"].Index)
                {
                    formTambahTransaksi = (FormTambahTransaksi)this.Owner;
                    formTambahTransaksi.rekeningTujuan = noRek;
                    formTambahTransaksi.penggunaTujuan = pengguna;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        private void tb_Kriteria_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string kriteria = "";
                string nilai = "";

                if (cb_Kriteria.Text == "Nama Pengguna")
                {
                    kriteria = "pengguna_email";
                }
                else if (cb_Kriteria.Text == "Nomor Rekening")
                {
                    kriteria = "no_rekening";
                }
                else if(cb_Kriteria.Text == "Keterangan")
                {
                    kriteria = "keterangan";
                }
                nilai = tb_Kriteria.Text;
                listAddressBook = AddressBook.BacaDataPengguna(kriteria, nilai, formTambahTransaksi.penggunaAsal.Email);

                if (listAddressBook.Count > 0)
                {
                    dgvListRekeningTujuan.DataSource = listAddressBook;
                }
                else
                {
                    dgvListRekeningTujuan.DataSource = null;
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
