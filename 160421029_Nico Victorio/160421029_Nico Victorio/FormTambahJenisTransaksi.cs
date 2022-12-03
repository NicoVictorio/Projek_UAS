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
    public partial class FormTambahJenisTransaksi : Form
    {
        FormMasterJenisTransaksi formJenisTransaksi;
        public FormTambahJenisTransaksi()
        {
            InitializeComponent();
        }

        private void FormTambahJenisTransaksi_Load(object sender, EventArgs e)
        {
            formJenisTransaksi = (FormMasterJenisTransaksi) this.Owner;
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            try
            {
                //int dataCount = formJenisTransaksi.listTransaksi.Count();
                JenisTransaksi js = new JenisTransaksi(1,tb_KodeJenisTransaksi.Text, tb_NamaJenisTransaksi.Text);
                if (js.TambahData())
                {
                    MessageBox.Show("Data Jenis Transaksi telah tersimpan", "Info");
                    FormMasterJenisTransaksi frm = (FormMasterJenisTransaksi)this.Owner;
                    frm.FormJenisTransaksi_Load(this, e);
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
                //MessageBox.Show("Penyimpanan gagal. Pesan kesalahan: " + x.Message, "Kesalahan");
            }
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
