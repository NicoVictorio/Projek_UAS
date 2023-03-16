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
    public partial class FormMutasiRekening : Form
    {
        public Pengguna penggunaAsal;
        public Tabungan tabunganAsal;
        public FormMutasiRekening()
        {
            InitializeComponent();
        }

        private void FormMutasiRekening_Load(object sender, EventArgs e)
        {
            textBoxNomorRekening.Text = tabunganAsal.NoRekening;
            comboBoxJenisTransaksi.SelectedItem = "Semua";
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            DateTime tanggalAwal = dateTimePickerTanggalAwal.Value;
            DateTime tanggalAkhir = dateTimePickerTanggalAkhir.Value;
            if (tanggalAwal > tanggalAkhir)
            {
                throw new Exception("Tanggal awal mutasi harus lebih kecil dari tanggal akhir mutasi");
            }
            else
            {
                FormDaftarMutasi formDaftarMutasi = new FormDaftarMutasi();
                formDaftarMutasi.Owner = this;
                formDaftarMutasi.jenisTransaksi = comboBoxJenisTransaksi.Text;
                formDaftarMutasi.tanggalAkhir = dateTimePickerTanggalAkhir.Value;
                formDaftarMutasi.tanggalAwal = dateTimePickerTanggalAwal.Value;
                formDaftarMutasi.tabPengguna = tabunganAsal;
                formDaftarMutasi.ShowDialog();
            }
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
