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
    public partial class FormPengajuanDeposito : Form
    {
        FormDaftarDeposito form;
        Pengguna penggunaAsal;
        Tabungan tabPengguna;
        public FormPengajuanDeposito()
        {
            InitializeComponent();
        }

        private void FormPengajuanDeposito_Load(object sender, EventArgs e)
        {
            form = (FormDaftarDeposito)this.Owner;
            penggunaAsal = form.penggunaAsal;

            List<Tabungan> tmpListTabungan = Tabungan.BacaData("id_pengguna", penggunaAsal.Nik.ToString());
            tabPengguna = tmpListTabungan[0];

            if (tabPengguna.Status == "Aktif")
            {
                labelId.Text = penggunaAsal.Nik.ToString();
                labelNomorRekening.Text = tabPengguna.NoRekening;
            }
            else
            {
                MessageBox.Show("Tabungan anda tidak aktif. " +
                                "\nSilahkan hubungi Customer Service untuk mengaktifkan kembali.");
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                int idPengguna = penggunaAsal.Nik;
                string idDeposito = Deposito.GenerateNoDeposito(idPengguna);

                List<Tabungan> tmpListTabungan = Tabungan.BacaData("id_pengguna", penggunaAsal.Nik.ToString());
                tabPengguna = tmpListTabungan[0];
                Tabungan rekeningSumber = tabPengguna;

                string jatuhTempo = comboBoxJatuhTempo.Text;
                double nominal = double.Parse(textBoxNominal.Text);
                double bunga = 0.0;
                if (jatuhTempo == "1 bulan")
                {
                    bunga = 0.03/12;
                }
                else if (jatuhTempo == "3 bulan") 
                {
                    bunga = 0.05/12;
                }
                else if(jatuhTempo == "6 bulan")
                {
                    bunga = 0.06/12;
                }
                else if (jatuhTempo == "1 tahun")
                {
                    bunga = 0.08 / 12;
                }
                else if (jatuhTempo == "2 tahun")
                {
                    bunga = 0.08 / 12;
                }
                else if (jatuhTempo == "3 tahun")
                {
                    bunga = 0.08 / 12;
                }
                string status = "Unverified";
                Deposito dep = new Deposito(idDeposito, rekeningSumber, jatuhTempo, nominal, bunga, status, DateTime.Now, DateTime.Now, null, null);
                if (dep.TambahData())
                {
                    MessageBox.Show("Pengajuan deposito telah berhasil.", "Info");
                    FormDaftarDeposito frm = (FormDaftarDeposito)this.Owner;
                    frm.FormDaftarDeposito_Load(sender, e);
                    this.Close();
                }
                else
                {
                    throw new Exception("Pengajuan deposito gagal.");
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
