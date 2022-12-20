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
    public partial class FormTambahAddressBook : Form
    {
        FormDaftarAddressBook form;
        public FormTambahAddressBook()
        {
            InitializeComponent();
        }

        private void FormTambahAddressBook_Load(object sender, EventArgs e)
        {
            form = (FormDaftarAddressBook)this.Owner;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Tabungan noRekening = Tabungan.tabunganByCode(textBoxNomorRekening.Text);
                Pengguna penggunaLogin = form.penggunaLogin;
                Pengguna pengguna = noRekening.Pengguna;
                string namaPengguna = noRekening.Pengguna.NamaDepan;
                string keterangan = textBoxKeterangan.Text;

                AddressBook ab = new AddressBook(noRekening, penggunaLogin, keterangan);
                if (ab != null)
                {
                    DialogResult confirmation = MessageBox.Show(
                        "Apakah anda yakin ingin menambahkan address book '" +
                         namaPengguna + "'?", "Konfirmasi Tambah",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (confirmation == DialogResult.Yes)
                    {
                        if (ab.TambahData())
                        {
                            MessageBox.Show("Anda berhasil menambahkan data address book baru", "Info");
                            FormDaftarAddressBook frm = (FormDaftarAddressBook)this.Owner;
                            frm.FormDaftarAddressBook_Load(this, e);
                            this.Close();
                        }
                        else
                        {
                            throw new Exception("Anda tidak berhasil menambahkan data address book baru");
                        }
                    }
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
