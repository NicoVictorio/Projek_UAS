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
    public partial class FormMenu : System.Windows.Forms.Form
    {
        public Pengguna tmpPengguna;
        public Employee tmpEmp;
        public Tabungan tabPengguna;
        public Pangkat tmpPangkat;
        public Deposito tmpDeposito;

        public FormMenu()
        {
            InitializeComponent();
        }

        public void FormMenu_Load(object sender, EventArgs e)
        {
            //memaksimalkan window
            this.WindowState = FormWindowState.Maximized;
            this.IsMdiContainer = true;

            //membuka form start
            FormStart start = new FormStart();
            start.Owner = this;

            //memanggil method HideAllMenu
            HideAllMenu();

            //kalau berhasil login
            if (start.ShowDialog() == DialogResult.OK)
            {
                //cek kalau yg login pengguna
                if (tmpPengguna != null)
                {
                    //baca tabungan pengguna yang terlogin
                    List<Tabungan> tmpListTabungan = Tabungan.BacaData("pengguna_email", tmpPengguna.Email);
                    tabPengguna = tmpListTabungan[0];

                    //cek apakah status tabungan pengguna terlogin sudah aktif atau belum
                    if (tabPengguna.Status == "Aktif")
                    {
                        //memanggil method SetHakAkses
                        SetHakAkses();

                        //cek apakah pengguna terlogin sudah memasukkan pin atau belum
                        if (tmpPengguna.Pin == "")
                        {
                            MessageBox.Show("Silahkan buat PIN");
                            
                            //memanggil form FormBuatPin
                            FormBuatPin formPin = new FormBuatPin();
                            formPin.Owner = this;
                            formPin.tabPengguna = tabPengguna; //mempassingkan tabungan pengguna terlogin
                            formPin.pengguna = tmpPengguna; // mempassingkan pengguna terlogin
                            formPin.ShowDialog();

                            //jika pin sudah terisi
                            if(formPin.DialogResult == DialogResult.OK)
                            {
                                //memperbaruhi data pengguna terlogin agar pin bisa dipakai
                                List<Pengguna> tmpListPengguna = Pengguna.BacaData("email", tmpPengguna.Email);
                                //buat ambil pengguna
                                tmpPengguna = tmpListPengguna[0];
                            }
                        }

                        //bunga rekening pertahun + biaya admin
                        //cek apakah tanggal perubahan sama dengan tanggal hari ini DAN status tabungan aktif
                        if (tabPengguna.Tgl_perubahan.ToShortDateString() == DateTime.Now.ToShortDateString() && tabPengguna.Tgl_perubahan != tabPengguna.Tgl_buat)
                        {
                            int bedaBulan = ((tabPengguna.Tgl_perubahan.Year      - tabPengguna.Tgl_buat.Year) * 12) + 
                                              tabPengguna.Tgl_perubahan.Month - tabPengguna.Tgl_buat.Month;
                            int biaya = 0;
                            if (tmpPengguna.Pangkat.ToString() == "BRZ")
                            {
                                biaya = 10000;
                            }
                            else if (tmpPengguna.Pangkat.ToString() == "SLV")
                            {
                                biaya = 5000;
                            }
                            else if (tmpPengguna.Pangkat.ToString() == "GLD")
                            {
                                biaya = 2000;
                            }
                            else if (tmpPengguna.Pangkat.ToString() == "PLT")
                            {
                                biaya = 1000;
                            }

                            Inbox inboxBiayaAdmin = new Inbox(0, tmpPengguna, "Biaya Administrasi sebesar " + biaya.ToString("C2"), DateTime.Now, "", DateTime.Now);
                            inboxBiayaAdmin.TambahData();

                            JenisTransaksi jenisTransaksiTax = JenisTransaksi.jenisTransaksiByCode(3);
                            string idTransaksiTax = Transaksi.GenerateNoTransaksi(jenisTransaksiTax.KodeTransaksi);
                            Transaksi transTax = new Transaksi(tabPengguna, idTransaksiTax, DateTime.Now,
                                                               jenisTransaksiTax, tabPengguna, biaya, 
                                                               "Biaya Administrasi sebesar " + biaya.ToString("C2"));
                            transTax.TambahDataDebit();

                            if (bedaBulan % 12 == 0)
                            {
                                //dapatkan bunga 3.6%
                                int nominal = (int)(tabPengguna.Saldo * 36 / 1000);
                                int pajak = 0; // dapatkan pajak

                                //kalau bunga diatas 50.000, maka akan dikenakan pajak 10% dari bunga
                                if (nominal > 50000)
                                {
                                    pajak = nominal * 10 / 100;
                                }

                                Inbox inboxBunga = new Inbox(0, tmpPengguna, "Anda mendapatkan bunga rekening sebesar " + nominal.ToString("C2"), DateTime.Now, "", DateTime.Now);
                                inboxBunga.TambahData();

                                JenisTransaksi jenisTransaksiInterest = JenisTransaksi.jenisTransaksiByCode(4);
                                string idTransaksiInterest = Transaksi.GenerateNoTransaksi(jenisTransaksiInterest.KodeTransaksi);
                                Transaksi transInterest = new Transaksi(tabPengguna, idTransaksiInterest, DateTime.Now,
                                                                        jenisTransaksiInterest, tabPengguna, nominal, 
                                                                        "Bunga tabungan sebesar " + nominal.ToString("C2"));
                                transInterest.TambahDataCredit();

                                //kalau ada pajak, maka mengurangi saldo dari pajak
                                if (pajak != 0)
                                {
                                    Inbox inboxPajak = new Inbox(0, tmpPengguna, "Anda dikenakan pajak sebesar " + pajak.ToString("C2"), DateTime.Now, "", DateTime.Now);
                                    inboxPajak.TambahData();

                                    JenisTransaksi jenisTransaksiPajak = JenisTransaksi.jenisTransaksiByCode(3);
                                    string idTransaksiPajak = Transaksi.GenerateNoTransaksi(jenisTransaksiPajak.KodeTransaksi);
                                    Transaksi transPajak = new Transaksi(tabPengguna, idTransaksiPajak, DateTime.Now,
                                                                         jenisTransaksiPajak, tabPengguna, pajak,
                                                                         "Pajak tabungan sebesar " + pajak.ToString("C2"));
                                    transPajak.TambahDataDebit();
                                }
                                MessageBox.Show("Anda mendapatkan bunga rekening sebesar " + nominal.ToString("C2") +
                                                " dengan pajak " + pajak.ToString("C2"));
                            }
                            DateTime tanggalPerubahan = tabPengguna.Tgl_perubahan.AddMonths(1);
                            Tabungan.UpdateTanggal(tabPengguna.NoRekening, tanggalPerubahan);

                            MessageBox.Show("Anda terkena biaya administrasi sebesar " + biaya.ToString("C2"));
                        }

                        //baca apakah pengguna punya deposito yang bertipe aro
                        List<Deposito> tmpListDepositoAro = Deposito.DepositoByCode("aro", true, "no_rekening", tabPengguna.NoRekening);
                       
                        //membaca semua deposito aro yang ada
                        for (int i = 0; i < tmpListDepositoAro.Count; i++)
                        {
                            //cek apakah tanggal cair sama dengan tanggal hari ini DAN status deposito aktif
                            if (tmpListDepositoAro[i].TglCair.ToShortDateString() == DateTime.Now.ToShortDateString())
                            {
                                int tahun = 0;
                                DateTime tanggalCair = DateTime.Now;

                                //mendapatkan berapa lama pengguna melakukan deposito dalam bulan
                                int bulan = tmpListDepositoAro[i].TglCair.Month - tmpListDepositoAro[i].TglAwal.Month;

                                if (bulan != 0)
                                {
                                    tanggalCair = tmpListDepositoAro[i].TglCair.AddMonths(bulan);
                                }
                                else if (bulan == 0)
                                {
                                    tahun = tmpListDepositoAro[i].TglCair.Year - tmpListDepositoAro[i].TglAwal.Year;
                                    tanggalCair = tmpListDepositoAro[i].TglCair.AddYears(tahun);
                                    bulan = tahun * 12;
                                }

                                //mendapatkan bunga dari deposito yang pengguna lakukan
                                int bunga = (int)(tmpListDepositoAro[i].Nominal * tmpListDepositoAro[i].Bunga.PersenBunga * bulan / 1200);

                                //memanggil method TambahBunga
                                if (tmpListDepositoAro[i].Keterangan == "Bunga masuk ke rekening tabungan.")
                                {
                                    Inbox inboxBunga = new Inbox(0, tmpPengguna, "Anda mendapatkan bunga deposito sebesar " + bunga.ToString("C2"), DateTime.Now, "", DateTime.Now);
                                    inboxBunga.TambahData();

                                    JenisTransaksi jenisTransaksiBunga = JenisTransaksi.jenisTransaksiByCode(4);
                                    string idTransaksiBunga = Transaksi.GenerateNoTransaksi(jenisTransaksiBunga.KodeTransaksi);
                                    Transaksi transBunga = new Transaksi(tabPengguna, idTransaksiBunga, DateTime.Now,
                                                                         jenisTransaksiBunga, tabPengguna, bunga,
                                                                         "Bunga deposito sebesar " + bunga.ToString("C2"));
                                    transBunga.TambahDataCredit();
                                }
                                else if (tmpListDepositoAro[i].Keterangan == "Bunga masuk ke pokok deposito.")
                                {
                                    Inbox inboxBunga = new Inbox(0, tmpPengguna, "Anda mendapatkan bunga deposito sebesar " + bunga.ToString("C2") + " yang masuk sebagai pokok deposito.", DateTime.Now, "", DateTime.Now);
                                    inboxBunga.TambahData();

                                    Deposito.TambahBunga(bunga, tabPengguna.NoRekening, tmpListDepositoAro[i].IdDeposito);
                                }

                                //mendeclare tanggal awal dan tanggal cair untuk deposito selanjutnya secara otomatis
                                DateTime tanggalAwal = tmpListDepositoAro[i].TglCair;

                                //memanggil method UpdateTanggal
                                Deposito.UpdateTanggal(tmpListDepositoAro[i].IdDeposito, tanggalAwal, tanggalCair);

                                MessageBox.Show("Anda mendapatkan bunga sebesar " + bunga.ToString("C2") + 
                                                " dari deposito " + tmpListDepositoAro[i].IdDeposito);
                            }
                        }

                        List<Deposito> tmpListDepositoNonAro = Deposito.DepositoByCode("aro", false, "no_rekening", tabPengguna.NoRekening);
                        int depSiapCairCount = 0;
                        //membaca semua deposito non-aro yang ada
                        for (int i = 0; i < tmpListDepositoNonAro.Count; i++)
                        {
                            if (tmpListDepositoNonAro[i].TglCair.ToShortDateString() == DateTime.Now.ToShortDateString() && tmpListDepositoNonAro[i].Status == "Aktif")
                            {
                                depSiapCairCount++;
                            }
                        }
                        if (depSiapCairCount > 0)
                        {
                            MessageBox.Show("Terdapat " + depSiapCairCount.ToString() + " deposito non-aro siap cair. Silahkan ajukan pencairan deposito.");
                        }
                    }
                    //kalau tabungan pengguna terlogin belum aktif
                    else
                    {
                        MessageBox.Show("Harap menunggu konfirmasi admin");
                    }
                }
                //cek kalau yang login employee
                else
                {
                    SetHakAkses(); //memanggil method SetHakAkses
                    int tabUnverifiedCount = 0; //menghitung tabungan unverified
                    int tabSuspendCount = 0; //menghitung tabungan suspend
                    int depUnverifiedCount = 0; //menghitung deposito unverified
                    int depWaitingCount = 0; // menghitung deposito waiting / siap cair

                    //membaca semua list tabungan
                    List<Tabungan> listTabungan = Tabungan.BacaData("", "");

                    //looping sebanyak list tabungan yang ada
                    for (int i = 0; i < listTabungan.Count; i++)
                    {
                        //cek apakah ada tabungan unverified
                        if (listTabungan[i].Status == "Unverified")
                        {
                            tabUnverifiedCount++; //kalau ada tabUnverifiedCountnya bertambah
                        }
                        //cek apakah ada tabungan suspend
                        else if (listTabungan[i].Status == "Suspend")
                        {
                            tabSuspendCount++; //kalau ada tabSuspendCountnya bertambah
                        }
                    }
                    //cek apakah ada tabungan unverified ATAU suspend
                    if (tabUnverifiedCount > 0 || tabSuspendCount > 0)
                    {
                        //kalau ada minimal 1 pada salah satu kondisi, maka dipanggil messagebox
                        MessageBox.Show("Terdapat " + tabUnverifiedCount.ToString() + " tabungan unverified dan " + tabSuspendCount.ToString() + " tabungan suspend.");
                    }

                    //membaca semua deposito yang ada
                    List<Deposito> listDeposito = Deposito.BacaData("", "");

                    //looping sebanyak list deposito yang ada
                    for (int i = 0; i < listDeposito.Count; i++)
                    {
                        //cek apakah ada deposito unverified
                        if (listDeposito[i].Status == "Unverified")
                        {
                            depUnverifiedCount++; //kalau ada depUnverifiedCountnya bertambah
                        }
                        //cek apakah ada deposito waiting / siap cair
                        else if (listDeposito[i].Status == "Waiting")
                        {
                            depWaitingCount++; //kalau ada depWaitingCountnya bertambah
                        }
                    }
                    //cek apakah ada deposito unverified ATAU waiting
                    if (depUnverifiedCount > 0 || depWaitingCount > 0)
                    {
                        //kalau ada minimal 1 pada salah satu kondisi, maka dipanggil messagebox
                        MessageBox.Show("Terdapat " + depUnverifiedCount.ToString() + " deposito unverified dan " + depWaitingCount.ToString() + " deposito siap cair.");
                    }
                }
            }
        }

        private void positionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Form form = Application.OpenForms["FormPosition"];
            if (form == null)
            {
                FormMasterPosition formPosition = new FormMasterPosition();
                formPosition.MdiParent = this;
                formPosition.Show();
            }
            else
            {
                form.Show();
                form.BringToFront();
            }
        }

        private void penggunaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Form form = Application.OpenForms["FormMasterPengguna"];
            if (form == null)
            {
                FormMasterPengguna formMasterPengguna = new FormMasterPengguna();
                formMasterPengguna.MdiParent = this;
                formMasterPengguna.Show();
            }
            else
            {
                form.Show();
                form.BringToFront();
            }
        }

        private void employeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Form form = Application.OpenForms["FormMasterEmployee"];
            if (form == null)
            {
                FormMasterEmployee formEmployee = new FormMasterEmployee();
                formEmployee.MdiParent = this;
                formEmployee.Show();
            }
            else
            {
                form.Show();
                form.BringToFront();
            }
        }

        private void jenisTransaksiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Form form = Application.OpenForms["FormJenisTransaksi"];
            if (form == null)
            {
                FormMasterJenisTransaksi formJenisTransaksi = new FormMasterJenisTransaksi();
                formJenisTransaksi.MdiParent = this;
                formJenisTransaksi.Show();
            }
            else
            {
                form.Show();
                form.BringToFront();
            }
        }

        private void inboxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Form form = Application.OpenForms["FormInbox"];
            if (form == null)
            {
                FormInbox formInbox = new FormInbox();
                formInbox.MdiParent = this;
                formInbox.Show();
            }
            else
            {
                form.Show();
                form.BringToFront();
            }
        }

        private void SetHakAkses()
        {
            if(tmpEmp != null)
            {
                if(tmpEmp.Position.IdPosition == 1)
                {
                    masterToolStripMenuItem.Visible = true;
                    tutupTabunganToolStripMenuItem.Visible = false;

                    akunToolStripMenuItem.Visible = true;
                    topUpToolStripMenuItem.Visible = false;
                    tabunganToolStripMenuItem.Visible = false;
                    settingToolStripMenuItem.Visible = false;
                    profileToolStripMenuItem.Visible = false;
                    inboxToolStripMenuItem.Visible = false;
                    mutasiRekeningToolStripMenuItem.Visible = false;

                    fiturToolStripMenuItem.Visible = false;
                    verifyToolStripMenuItem.Visible = true;
                }
                else
                {
                    masterToolStripMenuItem.Visible = false;
                    tutupTabunganToolStripMenuItem.Visible = false;

                    akunToolStripMenuItem.Visible = true;
                    topUpToolStripMenuItem.Visible = false;
                    tabunganToolStripMenuItem.Visible = false;
                    settingToolStripMenuItem.Visible = false;
                    profileToolStripMenuItem.Visible = false;
                    inboxToolStripMenuItem.Visible = false;
                    mutasiRekeningToolStripMenuItem.Visible = false;

                    fiturToolStripMenuItem.Visible = false;
                    verifyToolStripMenuItem.Visible = true;
                }
            }
            else
            {
                masterToolStripMenuItem.Visible = false;
                tutupTabunganToolStripMenuItem.Visible = true;

                akunToolStripMenuItem.Visible = true;
                topUpToolStripMenuItem.Visible = true;
                tabunganToolStripMenuItem.Visible = true;
                settingToolStripMenuItem.Visible = true;
                profileToolStripMenuItem.Visible = true;
                inboxToolStripMenuItem.Visible = true;
                mutasiRekeningToolStripMenuItem.Visible = true;

                fiturToolStripMenuItem.Visible = true;
                verifyToolStripMenuItem.Visible = false;
            }
        }

        public void HideAllMenu()
        {
            masterToolStripMenuItem.Visible = false;
            fiturToolStripMenuItem.Visible = false;
            verifyToolStripMenuItem.Visible = false;
            tutupTabunganToolStripMenuItem.Visible = false;

            akunToolStripMenuItem.Visible = true;
            profileToolStripMenuItem.Visible = true;
            topUpToolStripMenuItem.Visible = false;
            tabunganToolStripMenuItem.Visible = false;
            settingToolStripMenuItem.Visible = false;
            inboxToolStripMenuItem.Visible = false;
            mutasiRekeningToolStripMenuItem.Visible = false;
        }

        private void ubahPasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Form form = Application.OpenForms["FormUpdatePassword"];
            if (form == null)
            {
                FormUpdatePassword formUpdatePassword = new FormUpdatePassword();
                formUpdatePassword.MdiParent = this;
                formUpdatePassword.tmpPengguna = tmpPengguna;
                formUpdatePassword.Show();
            }
            else
            {
                form.Show();
                form.BringToFront();
            }
        }

        private void laporanTabunganToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Form form = Application.OpenForms["FormDaftarTabungan"];
            if (form == null)
            {
                FormDaftarTabungan formDaftarTabungan = new FormDaftarTabungan();
                formDaftarTabungan.MdiParent = this;
                formDaftarTabungan.Show();
            }
            else
            {
                form.Show();
                form.BringToFront();
            }
        }

        private void topUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Form form = Application.OpenForms["FormTopUp"];
            if (form == null)
            {
                FormTopUp formTopUp = new FormTopUp();
                formTopUp.MdiParent = this;
                formTopUp.Show();
            }
            else
            {
                form.Show();
                form.BringToFront();
            }
        }

        private void daftarTransferToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Form form = Application.OpenForms["FormDaftarAddressBook"];
            if (form == null)
            {
                FormDaftarAddressBook formDaftarAddressBook = new FormDaftarAddressBook();
                formDaftarAddressBook.MdiParent = this;
                formDaftarAddressBook.Show();
            }
            else
            {
                form.Show();
                form.BringToFront();
            }
        }

        private void transaksiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Form form = Application.OpenForms["FormTambahTransaksi"];
            if (form == null)
            {
                FormTambahTransaksi formTambahTransaksi = new FormTambahTransaksi();
                formTambahTransaksi.MdiParent = this;
                formTambahTransaksi.penggunaAsal = tmpPengguna;
                formTambahTransaksi.Show();
            }
            else
            {
                form.Show();
                form.BringToFront();
            }
        }

        private void depositoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Form form = Application.OpenForms["FormDaftarDeposito"];
            if (form == null)
            {
                FormDaftarDeposito formDaftarDeposito = new FormDaftarDeposito();
                formDaftarDeposito.MdiParent = this;
                formDaftarDeposito.Show();
            }
            else
            {
                form.Show();
                form.BringToFront();
            }
        }

        private void verifikasiTabunganToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Form form = Application.OpenForms["FormVerifikasiTabungan"];
            if (form == null)
            {
                FormVerifikasiTabungan formVerifikasiTabungan = new FormVerifikasiTabungan();
                formVerifikasiTabungan.MdiParent = this;
                formVerifikasiTabungan.Show();
            }
            else
            {
                form.Show();
                form.BringToFront();
            }
        }

        private void verifikasiDepositoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Form form = Application.OpenForms["FormVerifikasiDeposito"];
            if (form == null)
            {
                FormVerifikasiDeposito formVerifikasiDeposito = new FormVerifikasiDeposito();
                formVerifikasiDeposito.MdiParent = this;
                formVerifikasiDeposito.Show();
            }
            else
            {
                form.Show();
                form.BringToFront();
            }
        }

        private void verifikasiCairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Form form = Application.OpenForms["FormVerifikasiCair"];
            if (form == null)
            {
                FormVerifikasiCair formVerifikasiCair = new FormVerifikasiCair();
                formVerifikasiCair.MdiParent = this;
                formVerifikasiCair.Show();
            }
            else
            {
                form.Show();
                form.BringToFront();
            }
        }

        private void profileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Form form = Application.OpenForms["FormProfilePengguna"];
            if (form == null)
            {
                FormProfilePengguna formProfilePengguna = new FormProfilePengguna();
                formProfilePengguna.MdiParent = this;
                formProfilePengguna.tmpPengguna = tmpPengguna;
                formProfilePengguna.Show();
            }
            else
            {
                form.Show();
                form.BringToFront();
            }
        }

        private void tabunganToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Form form = Application.OpenForms["FormDaftarTabungan"];
            if (form == null)
            {
                FormDaftarTabungan formDaftarTabungan = new FormDaftarTabungan();
                formDaftarTabungan.MdiParent = this;
                formDaftarTabungan.Show();
            }
            else
            {
                form.Show();
                form.BringToFront();
            }
        }

        private void tabunganToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Form form = Application.OpenForms["FormTabunganPengguna"];
            if (form == null)
            {
                FormTabunganPengguna formTabunganPengguna = new FormTabunganPengguna();
                formTabunganPengguna.MdiParent = this;
                formTabunganPengguna.penggunaAsal = tmpPengguna;
                formTabunganPengguna.Show();
            }
            else
            {
                form.Show();
                form.BringToFront();
            }
        }

        private void mutasiRekeningToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Form form = Application.OpenForms["FormMutasiRekening"];
            if (form == null)
            {
                FormMutasiRekening formMutasiRekening = new FormMutasiRekening();
                formMutasiRekening.MdiParent = this;
                formMutasiRekening.penggunaAsal = tmpPengguna;
                formMutasiRekening.tabunganAsal = tabPengguna;
                formMutasiRekening.Show();
            }
            else
            {
                form.Show();
                form.BringToFront();
            }
        }

        private void signOutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            tmpDeposito = null;
            tmpEmp = null;
            tmpPengguna = null;
            tabPengguna = null;
            tmpPangkat = null;
            FormMenu_Load(sender, e);
        }

        private void transaksiToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Form form = Application.OpenForms["FormDaftarTransaksi"];
            if (form == null)
            {
                FormDaftarTransaksi formDaftarTransaksi = new FormDaftarTransaksi();
                formDaftarTransaksi.MdiParent = this;
                formDaftarTransaksi.Show();
            }
            else
            {
                form.Show();
                form.BringToFront();
            }
        }

        private void depositoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Form form = Application.OpenForms["FormMasterDeposito"];
            if (form == null)
            {
                FormMasterDeposito formMasterDeposito = new FormMasterDeposito();
                formMasterDeposito.MdiParent = this;
                formMasterDeposito.Show();
            }
            else
            {
                form.Show();
                form.BringToFront();
            }
        }

        private void tutupTabunganToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Apakah anda yakin ingin menutup tabungan?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    Inbox.HapusDataPengguna(tmpPengguna.Email);
                    Transaksi.HapusDataPengguna(tabPengguna.NoRekening);
                    AddressBook.HapusDataPengguna(tmpPengguna.Email);
                    Deposito.HapusDataPengguna(tabPengguna.NoRekening);
                    Tabungan.HapusDataPengguna(tmpPengguna.Email);
                    Pengguna.HapusDataPengguna(tmpPengguna.Email);

                    tmpDeposito = null;
                    tmpEmp = null;
                    tmpPengguna = null;
                    tabPengguna = null;
                    tmpPangkat = null;
                    FormMenu_Load(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
            }
        }
    }
}
