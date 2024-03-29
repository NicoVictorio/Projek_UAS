﻿using System;
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
        public Tabungan tabPengguna;

        public FormTambahTransaksi()
        {
            InitializeComponent();
        }

        private void FormTransaksi_Load(object sender, EventArgs e)
        {
            textBoxRekeningAsal.Enabled = false;
            formMenu = (FormMenu)this.MdiParent;
            penggunaAsal = formMenu.tmpPengguna;

            List<Tabungan> tmpListTabungan = Tabungan.BacaData("pengguna_email", penggunaAsal.Email);
            tabPengguna = tmpListTabungan[0];

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
                JenisTransaksi jenisTransaksiDebit = JenisTransaksi.jenisTransaksiByCode(1);
                JenisTransaksi jenisTransaksiCredit = JenisTransaksi.jenisTransaksiByCode(2);
                double nominal = double.Parse(textBoxNominal.Text);
                string keterangan = textBoxKeterangan.Text;

                string idTransaksiDebit = Transaksi.GenerateNoTransaksi(jenisTransaksiDebit.KodeTransaksi);
                string idTransaksiCredit = Transaksi.GenerateNoTransaksi(jenisTransaksiCredit.KodeTransaksi);

                rekeningTujuan = Tabungan.tabunganByCode(textBoxRekeningTujuan.Text);
                Transaksi transDebit = new Transaksi(noRekeningSumber, idTransaksiDebit, DateTime.Now,
                                                     jenisTransaksiDebit, rekeningTujuan, 
                                                     nominal, keterangan);
                Transaksi transCredit = new Transaksi(noRekeningSumber, idTransaksiCredit, DateTime.Now,
                                                      jenisTransaksiCredit, rekeningTujuan,
                                                      nominal, keterangan);

                FormPin formPin = new FormPin();
                formPin.Owner = this;

                if (formPin.ShowDialog() == DialogResult.OK)
                {
                    if(noRekeningSumber.Saldo - nominal >= 0)
                    {
                        if (transDebit.TambahDataDebit() && transCredit.TambahDataCredit())
                        {
                            MessageBox.Show("Data Transaksi telah tersimpan", "Info");
                            List<AddressBook> listAddressbook = AddressBook.BacaDataPengguna("no_rekening", rekeningTujuan.NoRekening, penggunaAsal.Email);
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

        private void FormTambahTransaksi_FormClosing(object sender, FormClosingEventArgs e)
        {
            Pengguna.UpdatePangkat(tabPengguna.NoRekening, penggunaAsal.Email);
        }
    }
}
