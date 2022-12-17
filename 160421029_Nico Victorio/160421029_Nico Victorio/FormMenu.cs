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

        private void FormMenu_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.IsMdiContainer = true;

            FormStart login = new FormStart();
            login.Owner = this;

            if (login.ShowDialog() == DialogResult.OK)
            {
                if (tmpPengguna != null)
                {
                    MessageBox.Show("Selamat datang " + tmpPengguna.NamaDepan, "Information");
                }
                else
                {
                    MessageBox.Show("Selamat datang " + tmpEmp.NamaDepan, "Information");
                }
                SetHakAkses();
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


        private void signOutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
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
            }
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
    }
}
