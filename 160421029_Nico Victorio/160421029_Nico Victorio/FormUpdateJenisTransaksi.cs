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
    public partial class FormUpdateJenisTransaksi : Form
    {
        //public string kodeJenisTransaksi;
        public int idJenisTransaksi;
        FormJenisTransaksi formJenisTransaksi;
        public FormUpdateJenisTransaksi()
        {
            InitializeComponent();
        }

        private void FormUpdateJenisTransaksi_Load(object sender, EventArgs e)
        {
            //tb_KodeJenisTransaksi.Enabled = false;
            formJenisTransaksi = (FormJenisTransaksi)this.Owner;
            JenisTransaksi tmp = JenisTransaksi.jenisTransaksiByCode(idJenisTransaksi);
            if (tmp != null)
            {
                tb_KodeJenisTransaksi.Text = tmp.KodeTransaksi;
                tb_NamaJenisTransaksi.Text = tmp.NamaTransaksi;
            }
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            try
            {
                JenisTransaksi k = new JenisTransaksi(idJenisTransaksi,tb_KodeJenisTransaksi.Text, tb_NamaJenisTransaksi.Text);
                if (k.UbahData())
                {
                    MessageBox.Show("Data Jenis Transaksi telah terubah", "Info");
                    
                    formJenisTransaksi.FormJenisTransaksi_Load(this, e);
                    this.Close();
                }
                else
                {
                    throw new Exception("Tidak dapat mengubah data dalam database");
                }

            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
