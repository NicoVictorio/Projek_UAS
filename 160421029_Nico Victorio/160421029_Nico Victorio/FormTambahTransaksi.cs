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
    public partial class FormTambahTransaksi : Form
    {
        FormMenu formMenu;
        public Pengguna penggunaAsal;
        public Tabungan rekeningTujuan;
        public Pengguna penggunaTujuan;

        public FormTambahTransaksi()
        {
            InitializeComponent();
        }

        private void FormTransaksi_Load(object sender, EventArgs e)
        {
            textBoxRekeningAsal.Enabled = false;
            formMenu = (FormMenu)this.MdiParent;
            penggunaAsal = formMenu.tmpPengguna;

            List<Tabungan> tmpListTabungan = Tabungan.BacaData("pengguna_id", penggunaAsal.Id.ToString());
            Tabungan tabPengguna = tmpListTabungan[0];

            textBoxRekeningAsal.Text = tabPengguna.NoRekening;

            List<JenisTransaksi> listJenisTransaksi = JenisTransaksi.BacaData("", "");
        }

        private void buttonCariRekening_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Form form = Application.OpenForms["FormDaftarRekeningTujuan"];
            if (form == null)
            {
                FormDaftarRekeningTujuan formDaftarRekeningTujuan = new FormDaftarRekeningTujuan();
                formDaftarRekeningTujuan.Owner = this;
                if (formDaftarRekeningTujuan.ShowDialog() == DialogResult.OK)
                {
                    textBoxRekeningTujuan.Text = rekeningTujuan.NoRekening.ToString();
                }
            }
            else
            {
                form.Show();
                form.BringToFront();
            }
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                Tabungan noRekeningSumber = Tabungan.tabunganByCode(textBoxRekeningAsal.Text);
                JenisTransaksi jenisTransaksi = JenisTransaksi.jenisTransaksiByCode(1);
                double nominal = double.Parse(textBoxNominal.Text);
                string keterangan = textBoxKeterangan.Text;
                string idTransaksi = Transaksi.GenerateNoTransaksi(jenisTransaksi.KodeTransaksi);
                rekeningTujuan = Tabungan.tabunganByCode(textBoxRekeningTujuan.Text);
                Transaksi trans = new Transaksi(noRekeningSumber, idTransaksi, DateTime.Now,
                                                jenisTransaksi, rekeningTujuan, 
                                                nominal, keterangan);

                FormPin formPin = new FormPin();
                formPin.Owner = this;

                if (formPin.ShowDialog() == DialogResult.OK)
                {
                    if(noRekeningSumber.Saldo - nominal >= 0)
                    {
                        if (trans.TambahData(jenisTransaksi.KodeTransaksi))
                        {
                            MessageBox.Show("Data Transaksi telah tersimpan", "Info");
                            List<AddressBook> listAddressbook = AddressBook.BacaDataPengguna("no_rekening", rekeningTujuan.NoRekening, penggunaAsal.Id);
                            if (listAddressbook.Count == 0)
                            {
                                DialogResult confirmation = MessageBox.Show("Simpan " + rekeningTujuan.NoRekening + " ke address book?", "Konfirmasi Address Book", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (confirmation == DialogResult.Yes)
                                {
                                    AddressBook ab = new AddressBook(rekeningTujuan, penggunaAsal, "");
                                    if (ab.TambahData())
                                    {
                                        MessageBox.Show("Address Book berhasil ditambahkan");
                                    }
                                }
                            }
                            FormMenu frm = (FormMenu)this.MdiParent;
                            this.Close();
                        }
                        else
                        {
                            throw new Exception("Tidak dapat menambahkan data dalam database");
                        }
                    }
                    else
                    {
                        throw new Exception("Saldo anda tidak mencukupi");
                    }
                }
                else if(formPin.count == 3)
                {
                    if (noRekeningSumber.UbahStatusSuspend())
                    {
                        MessageBox.Show("Akun anda telah disuspend sementara");
                        this.Close();
                        formMenu.HideAllMenu();
                    }
                    
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
