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
                    MessageBox.Show("Selamat datang " + tmpPengguna.NamaDepan, "Information");

                    List<Tabungan> tmpListTabungan = Tabungan.BacaData("id_pengguna", tmpPengguna.Nik.ToString());
                    Tabungan tabPengguna = tmpListTabungan[0];

                    if (tabPengguna.Status == "Aktif")
                    {
                        SetHakAkses();
                    }
                    else
                    {
                        MessageBox.Show("Harap menunggu konfirmasi admin");
                    }
                }
                else
                {
                    MessageBox.Show("Selamat datang " + tmpEmp.NamaDepan, "Information");
                    SetHakAkses();
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
                penggunaToolStripMenuItem.Visible = true;
                employeeToolStripMenuItem.Visible = true;
                positionToolStripMenuItem.Visible = true;
                jenisTransaksiToolStripMenuItem.Visible = true;

                laporanToolStripMenuItem.Visible = true;
                laporanTabunganToolStripMenuItem.Visible = true;
                laporanDepositoToolStripMenuItem.Visible = true;
                laporanTransaksiToolStripMenuItem.Visible = true;

                ubahPasswordToolStripMenuItem.Visible = false;
                settingToolStripMenuItem.Visible = false;

                fiturToolStripMenuItem.Visible = false;
                verifyToolStripMenuItem.Visible = true;
            }
            else
            {
                masterToolStripMenuItem.Visible = false;
                penggunaToolStripMenuItem.Visible = false;
                employeeToolStripMenuItem.Visible = false;
                positionToolStripMenuItem.Visible = false;
                jenisTransaksiToolStripMenuItem.Visible = false;

                laporanToolStripMenuItem.Visible = false;
                laporanTabunganToolStripMenuItem.Visible = false;
                laporanDepositoToolStripMenuItem.Visible = false;
                laporanTransaksiToolStripMenuItem.Visible = false;

                ubahPasswordToolStripMenuItem.Visible = true;
                settingToolStripMenuItem.Visible = true;

                fiturToolStripMenuItem.Visible = true;
                verifyToolStripMenuItem.Visible = false;
            }
        }

        private void HideAllMenu()
        {
            masterToolStripMenuItem.Visible = false;
            penggunaToolStripMenuItem.Visible = false;
            employeeToolStripMenuItem.Visible = false;
            positionToolStripMenuItem.Visible = false;
            jenisTransaksiToolStripMenuItem.Visible = false;

            laporanToolStripMenuItem.Visible = false;
            laporanTabunganToolStripMenuItem.Visible = false;
            laporanDepositoToolStripMenuItem.Visible = false;
            laporanTransaksiToolStripMenuItem.Visible = false;

            ubahPasswordToolStripMenuItem.Visible = false;
            settingToolStripMenuItem.Visible = false;

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
            Application.Exit();
        }
    }
}
