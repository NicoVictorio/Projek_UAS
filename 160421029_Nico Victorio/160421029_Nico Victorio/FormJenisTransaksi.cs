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
    public partial class FormJenisTransaksi : Form
    {
        public List<JenisTransaksi> listTransaksi = new List<JenisTransaksi>();
        public FormJenisTransaksi()
        {
            InitializeComponent();
        }

        private void FormJenisTransaksi_Load(object sender, EventArgs e)
        {
            listTransaksi = JenisTransaksi.BacaData("", "");
            if (listTransaksi.Count > 0)
            {
                dgvListJenisTransaksi.DataSource = listTransaksi;
            }
            else
            {
                dgvListJenisTransaksi.DataSource = null;
            }
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {

        }

        private void tb_Kriteria_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_Add_Click(object sender, EventArgs e)
        {

        }

        private void btn_Update_Click(object sender, EventArgs e)
        {

        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvListPosition_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
