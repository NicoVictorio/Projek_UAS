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
    
    public partial class FormDaftarTransaksi : Form
    {
        List<Transaksi> listTransaksi = new List<Transaksi>();
        public FormDaftarTransaksi()
        {
            InitializeComponent();
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            FormTambahTransaksi formTambahTransaksi = new FormTambahTransaksi();
            formTambahTransaksi.Owner = this;
            formTambahTransaksi.ShowDialog();
        }

        private void FormDaftarTransaksi_Load(object sender, EventArgs e)
        {
            listTransaksi = Transaksi.BacaData("", "");
            if (listTransaksi.Count > 0)
            {
                dgvListTransaksi.DataSource = listTransaksi;
            }
            else
            {
                dgvListTransaksi.DataSource = null;
            }
        }

        private void tb_Kriteria_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string kriteria = "";
                string nilai = "";

                if (cb_Kriteria.Text == "Rekening Sumber")
                {
                    kriteria = "rekening_sumber";
                }
                else if (cb_Kriteria.Text == "Id Transaksi")
                {
                    kriteria = "idtransaksi";
                }
                else if (cb_Kriteria.Text == "Tanggal Transaksi")
                {
                    kriteria = "tgl_transaksi";
                }
                else if (cb_Kriteria.Text == "Id Jenis Transaksi")
                {
                    kriteria = "id_jenisTransaksi";
                }
                else if (cb_Kriteria.Text == "Rekening Tujuan")
                {
                    kriteria = "rekening_tujuan";
                }
                else if (cb_Kriteria.Text == "Nominal")
                {
                    kriteria = "nominal";
                }
                else if (cb_Kriteria.Text == "Keterangan")
                {
                    kriteria = "keterangan";
                }
                nilai = tb_Kriteria.Text;
                listTransaksi = Transaksi.BacaData(kriteria, nilai);

                if (listTransaksi.Count > 0)
                {
                    dgvListTransaksi.DataSource = listTransaksi;
                }
                else
                {
                    dgvListTransaksi.DataSource = null;
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
