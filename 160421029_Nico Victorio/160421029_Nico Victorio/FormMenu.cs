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
    public partial class FormMenu : Form
    {
        public Pengguna tmpPengguna;
        public FormMenu()
        {
            InitializeComponent();
        }

        private void FormMenu_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.IsMdiContainer = true;
            try
            {
                Koneksi koneksi = new Koneksi();
                MessageBox.Show("Koneksi Berhasil");

                FormLoginPengguna login = new FormLoginPengguna();
                login.Owner = this;
                if (login.ShowDialog() == DialogResult.OK)
                {
                    //labelKodePegawai.Text = tmpPegawai.KodePegawai.ToString();
                    //labelNamaPegawai.Text = tmpPegawai.NamaPegawai;
                    MessageBox.Show("Selamat datang " + tmpPengguna.NamaDepan + " \nKoneksi berhasil", "Login Information");
                    //EnableHakAkses();
                    //mnuSignOut.Visible = true;
                }

            }
            catch (Exception x)
            {
                MessageBox.Show("Koneksi Gagal. Pesan Kesalahan : " + x.Message, "Informasi");
                this.Close();
            }
        }

        private void positionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = Application.OpenForms["FormMasterPosition"];
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
            Form form = Application.OpenForms["FormMasterPengguna"];
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
            Form form = Application.OpenForms["FormMasterEmployee"];
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
            Form form = Application.OpenForms["FormMasterJenisTransaksi"];
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

        private void tabunganToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
