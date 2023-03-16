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
    public partial class FormDaftarMutasi : Form
    {
        public Tabungan tabPengguna;
        public string jenisTransaksi;
        public DateTime tanggalAwal;
        public DateTime tanggalAkhir;
        public List<Transaksi> listMutasi = new List<Transaksi>();

        public FormDaftarMutasi()
        {
            InitializeComponent();
        }

        private void FormDaftarMutasi_Load(object sender, EventArgs e)
        {
            listMutasi = Transaksi.BacaMutasi(tabPengguna.NoRekening, jenisTransaksi,
                                              tanggalAwal, tanggalAkhir);
            if (listMutasi.Count > 0)
            {
                dgvListMutasi.DataSource = listMutasi;
            }
            else
            {
                dgvListMutasi.DataSource = null;
            }
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
