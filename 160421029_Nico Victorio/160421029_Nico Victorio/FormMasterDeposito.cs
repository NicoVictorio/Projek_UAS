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
    public partial class FormMasterDeposito : Form
    {
        public List<Deposito> listDeposito = new List<Deposito>();
        FormMenu formMenu;

        public FormMasterDeposito()
        {
            InitializeComponent();
        }

        private void FormMasterDeposito_Load(object sender, EventArgs e)
        {
            formMenu = (FormMenu)this.MdiParent;

            listDeposito = Deposito.BacaData("", "");
            if (listDeposito.Count > 0)
            {
                dgvListDeposito.DataSource = listDeposito;
            }
            else
            {
                dgvListDeposito.DataSource = null;
            }
        }

        private void tb_Kriteria_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string kriteria = "";
                string nilai = "";
                if (cb_Kriteria.Text == "Id Deposito")
                {
                    kriteria = "id_deposito";
                }
                else if (cb_Kriteria.Text == "Nomor Rekening")
                {
                    kriteria = "no_rekening";
                }
                else if (cb_Kriteria.Text == "Nominal")
                {
                    kriteria = "nominal";
                }
                else if (cb_Kriteria.Text == "Status")
                {
                    kriteria = "status";
                }
                else if (cb_Kriteria.Text == "Tanggal Awal")
                {
                    kriteria = "tgl_buat";
                }
                else if (cb_Kriteria.Text == "Tanggal Cair")
                {
                    kriteria = "tgl_perubahan";
                }
                else if (cb_Kriteria.Text == "Verifikator Buka")
                {
                    kriteria = "verifikator_buka";
                }
                else if (cb_Kriteria.Text == "Verifikator Cair")
                {
                    kriteria = "verifikator_cair";
                }
                else if (cb_Kriteria.Text == "Id Bunga")
                {
                    kriteria = "idBunga";
                }
                else if (cb_Kriteria.Text == "Aro")
                {
                    kriteria = "aro";
                }
                else if (cb_Kriteria.Text == "Keterangan")
                {
                    kriteria = "keterangan";
                }

                nilai = tb_Kriteria.Text;
                listDeposito = Deposito.BacaData(kriteria, nilai);

                if (listDeposito.Count > 0)
                {
                    dgvListDeposito.DataSource = listDeposito;
                }
                else
                {
                    dgvListDeposito.DataSource = null;
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
