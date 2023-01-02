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
            this.WindowState = FormWindowState.Maximized;
            this.IsMdiContainer = true;

            FormStart login = new FormStart();
            login.Owner = this;

            HideAllMenu();

            if (login.ShowDialog() == DialogResult.OK)
            {
                if (tmpPengguna != null)
                {
                    List<Tabungan> tmpListTabungan = Tabungan.BacaData("pengguna_email", tmpPengguna.Email);
                    tabPengguna = tmpListTabungan[0];

                    List<Deposito> tmpListDeposito = Deposito.DepositoByCode("aro", 1.ToString(), "no_rekening", tabPengguna.NoRekening);
                    for (int i = 0; i < tmpListDeposito.Count; i++)
                    {
                        if (tmpListDeposito[i].TglCair.ToShortDateString() == DateTime.Now.ToShortDateString() && tmpListDeposito[i].Status == "Aktif")
                        {
                            int bulan = tmpListDeposito[i].TglCair.Month - tmpListDeposito[i].TglAwal.Month;
                            double bunga = tmpListDeposito[i].Nominal * tmpListDeposito[i].Bunga.PersenBunga / 100;
                            if (tmpListDeposito[i].Keterangan == "Bunga masuk ke pokok deposito.")
                            {
                                tmpListDeposito[i].Nominal += bunga;
                                tmpListDeposito[i].TglAwal = DateTime.Now;
                                tmpListDeposito[i].TglCair = DateTime.Now.AddMonths(bulan);
                            }
                            else if (tmpListDeposito[i].Keterangan == "Bunga masuk ke rekening tabungan.")
                            {
                                tabPengguna.Saldo += bunga;
                                tmpListDeposito[i].TglAwal = DateTime.Now;
                                tmpListDeposito[i].TglCair = DateTime.Now.AddMonths(bulan);
                            }
                        }
                    }
                    if (tabPengguna.Status == "Aktif")
                    {
                        SetHakAkses();
                        
                        if (tmpPengguna.Pin == "")
                        {
                            MessageBox.Show("Silahkan buat PIN");
                            FormBuatPin formPin = new FormBuatPin();
                            formPin.Owner = this;
                            formPin.tabPengguna = tabPengguna;
                            formPin.pengguna = tmpPengguna;
                            formPin.ShowDialog();
                            if(formPin.DialogResult == DialogResult.OK)
                            {
                                List<Pengguna> tmpListPengguna = Pengguna.BacaData("email", tmpPengguna.Email);
                                tmpPengguna = tmpListPengguna[0];
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Harap menunggu konfirmasi admin");
                    }
                }
                else
                {
                    SetHakAkses();
                    int tabUnverifiedCount = 0;
                    int tabSuspendCount = 0;
                    int depUnverifiedCount = 0;
                    int depWaitingCount = 0;
                    if (tmpEmp != null)
                    {
                        List<Tabungan> listTabungan = Tabungan.BacaData("", "");
                        for (int i = 0; i < listTabungan.Count; i++)
                        {
                            if (listTabungan[i].Status == "Unverified")
                            {
                                tabUnverifiedCount++;
                            }
                            else if(listTabungan[i].Status == "Suspend")
                            {
                                tabSuspendCount++;
                            }
                        }
                        if (tabUnverifiedCount > 0 || tabSuspendCount > 0)
                        {
                            MessageBox.Show("Terdapat " + tabUnverifiedCount.ToString() + " tabungan unverified dan " + tabSuspendCount.ToString() + " tabungan suspend.");
                        }

                        List<Deposito> listDeposito = Deposito.BacaData("", "");
                        for (int i = 0; i < listDeposito.Count; i++)
                        {
                            if (listDeposito[i].Status == "Unverified")
                            {
                                depUnverifiedCount++;
                            }
                            else if (listDeposito[i].Status == "Waiting")
                            {
                                depWaitingCount++;
                            }
                        }
                        if (depUnverifiedCount > 0 || depWaitingCount > 0)
                        {
                            MessageBox.Show("Terdapat " + depUnverifiedCount.ToString() + " deposito unverified dan " + depWaitingCount.ToString() + " deposito siap cair.");
                        }
                    }
                }
            }
            else
            {
                this.Close();
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
                masterToolStripMenuItem.Visible = true;
                laporanToolStripMenuItem.Visible = true;
                
                akunToolStripMenuItem.Visible = true;
                topUpToolStripMenuItem.Visible = false;
                tabunganToolStripMenuItem.Visible = false;
                settingToolStripMenuItem.Visible = false;

                fiturToolStripMenuItem.Visible = false;
                verifyToolStripMenuItem.Visible = true;
            }
            else
            {
                masterToolStripMenuItem.Visible = false;
                laporanToolStripMenuItem.Visible = false;

                akunToolStripMenuItem.Visible = true;
                topUpToolStripMenuItem.Visible = true;
                tabunganToolStripMenuItem.Visible = true;
                settingToolStripMenuItem.Visible = true;

                fiturToolStripMenuItem.Visible = true;
                verifyToolStripMenuItem.Visible = false;
            }
        }

        public void HideAllMenu()
        {
            masterToolStripMenuItem.Visible = false;
            laporanToolStripMenuItem.Visible = false;
            akunToolStripMenuItem.Visible = false;
            topUpToolStripMenuItem.Visible = false;
            inboxToolStripMenuItem.Visible = false;
            fiturToolStripMenuItem.Visible = false;
            verifyToolStripMenuItem.Visible = false;
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

        private void laporanDepositoToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void laporanTransaksiToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void signOutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            tmpDeposito = null;
            tmpEmp = null;
            tmpPengguna = null;
            FormMenu_Load(sender, e);
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
    }
}
