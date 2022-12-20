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

            List<Tabungan> tmpListTabungan = Tabungan.BacaData("id_pengguna", penggunaAsal.Nik.ToString());
            Tabungan tabPengguna = tmpListTabungan[0];

            textBoxRekeningAsal.Text = tabPengguna.NoRekening;

            List<JenisTransaksi> listJenisTransaksi = JenisTransaksi.BacaData("", "");
            ComboBoxJenisTransaksi.DataSource = listJenisTransaksi;
            ComboBoxJenisTransaksi.DisplayMember = "kode";
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
                JenisTransaksi idJenisTransaksi = (JenisTransaksi)ComboBoxJenisTransaksi.SelectedItem;
                double nominal = double.Parse(textBoxNominal.Text);
                string keterangan = textBoxKeterangan.Text;
                Transaksi trans = new Transaksi(noRekeningSumber, 0, DateTime.Now,
                                                idJenisTransaksi, rekeningTujuan, 
                                                nominal, keterangan);
                if (trans.TambahData())
                {
                    MessageBox.Show("Data Transaksi telah tersimpan", "Info");
                    FormMenu frm = (FormMenu)this.MdiParent;
                    this.Close();
                }
                else
                {
                    throw new Exception("Tidak dapat menambahkan data dalam database");
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
