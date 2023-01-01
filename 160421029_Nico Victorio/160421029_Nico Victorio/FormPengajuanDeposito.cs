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

            List<Tabungan> tmpListTabungan = Tabungan.BacaData("pengguna_id", penggunaAsal.Id.ToString());
            tabPengguna = tmpListTabungan[0];

            if (tabPengguna.Status == "Aktif")
            {
                labelId.Text = penggunaAsal.Id.ToString();
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
                int idPengguna = penggunaAsal.Id;
                string idDeposito = Deposito.GenerateNoDeposito(idPengguna);

                List<Tabungan> tmpListTabungan = Tabungan.BacaData("pengguna_id", penggunaAsal.Id.ToString());
                tabPengguna = tmpListTabungan[0];
                Tabungan rekeningSumber = tabPengguna;

                string jatuhTempo = comboBoxJatuhTempo.Text;
                double nominal = double.Parse(textBoxNominal.Text);
                
                Bunga bunga = new Bunga();
                List<Bunga> tmpListBunga = new List<Bunga>();

                if (jatuhTempo == "1 bulan")
                {
                    if (nominal >= 10000000 && nominal < 50000000)
                    {
                        tmpListBunga = Bunga.BacaBunga("jatuhtempo", jatuhTempo, "nominal", "10 juta s/d < 50 juta");
                    }
                    else if (nominal >= 50000000 && nominal < 100000000)
                    {
                        tmpListBunga = Bunga.BacaBunga("jatuhtempo", jatuhTempo, "nominal", "50 juta s/d < 100 juta");
                    }
                    else if (nominal >= 100000000)
                    {
                        tmpListBunga = Bunga.BacaBunga("jatuhtempo", jatuhTempo, "nominal", ">= 100 juta");
                    }
                    else
                    {
                        throw new Exception("Nominal deposito minimal 10 juta.");
                    }
                }
                else if (jatuhTempo == "3 bulan")
                {
                    if (nominal >= 10000000 && nominal < 50000000)
                    {
                        tmpListBunga = Bunga.BacaBunga("jatuhtempo", jatuhTempo, "nominal", "10 juta s/d < 50 juta");
                    }
                    else if (nominal >= 50000000 && nominal < 100000000)
                    {
                        tmpListBunga = Bunga.BacaBunga("jatuhtempo", jatuhTempo, "nominal", "50 juta s/d < 100 juta");
                    }
                    else if (nominal >= 100000000)
                    {
                        tmpListBunga = Bunga.BacaBunga("jatuhtempo", jatuhTempo, "nominal", ">= 100 juta");
                    }
                    else
                    {
                        throw new Exception("Nominal deposito minimal 10 juta.");
                    }
                }
                else if (jatuhTempo == "6 bulan")
                {
                    if (nominal >= 10000000 && nominal < 50000000)
                    {
                        tmpListBunga = Bunga.BacaBunga("jatuhtempo", jatuhTempo, "nominal", "10 juta s/d < 50 juta");
                    }
                    else if (nominal >= 50000000 && nominal < 100000000)
                    {
                        tmpListBunga = Bunga.BacaBunga("jatuhtempo", jatuhTempo, "nominal", "50 juta s/d < 100 juta");
                    }
                    else if (nominal >= 100000000)
                    {
                        tmpListBunga = Bunga.BacaBunga("jatuhtempo", jatuhTempo, "nominal", ">= 100 juta");
                    }
                    else
                    {
                        throw new Exception("Nominal deposito minimal 10 juta.");
                    }
                }
                else if (jatuhTempo == "12 bulan")
                {
                    if (nominal >= 10000000 && nominal < 50000000)
                    {
                        tmpListBunga = Bunga.BacaBunga("jatuhtempo", jatuhTempo, "nominal", "10 juta s/d < 50 juta");
                    }
                    else if (nominal >= 50000000 && nominal < 100000000)
                    {
                        tmpListBunga = Bunga.BacaBunga("jatuhtempo", jatuhTempo, "nominal", "50 juta s/d < 100 juta");
                    }
                    else if (nominal >= 100000000)
                    {
                        tmpListBunga = Bunga.BacaBunga("jatuhtempo", jatuhTempo, "nominal", ">= 100 juta");
                    }
                    else
                    {
                        throw new Exception("Nominal deposito minimal 10 juta.");
                    }
                }
                else if (jatuhTempo == "24 bulan")
                {
                    if (nominal >= 10000000 && nominal < 50000000)
                    {
                        tmpListBunga = Bunga.BacaBunga("jatuhtempo", jatuhTempo, "nominal", "10 juta s/d < 50 juta");
                    }
                    else if (nominal >= 50000000 && nominal < 100000000)
                    {
                        tmpListBunga = Bunga.BacaBunga("jatuhtempo", jatuhTempo, "nominal", "50 juta s/d < 100 juta");
                    }
                    else if (nominal >= 100000000)
                    {
                        tmpListBunga = Bunga.BacaBunga("jatuhtempo", jatuhTempo, "nominal", ">= 100 juta");
                    }
                    else
                    {
                        throw new Exception("Nominal deposito minimal 10 juta.");
                    }
                }
                else if (jatuhTempo == "36 bulan")
                {
                    if (nominal >= 10000000 && nominal < 50000000)
                    {
                        tmpListBunga = Bunga.BacaBunga("jatuhtempo", jatuhTempo, "nominal", "10 juta s/d < 50 juta");
                    }
                    else if (nominal >= 50000000 && nominal < 100000000)
                    {
                        tmpListBunga = Bunga.BacaBunga("jatuhtempo", jatuhTempo, "nominal", "50 juta s/d < 100 juta");
                    }
                    else if (nominal >= 100000000)
                    {
                        tmpListBunga = Bunga.BacaBunga("jatuhtempo", jatuhTempo, "nominal", ">= 100 juta");
                    }
                    else
                    {
                        throw new Exception("Nominal deposito minimal 10 juta.");
                    }
                }
                bunga = tmpListBunga[0];
                bool aro = false;
                if (checkBoxARO.Checked)
                {
                    aro = true;
                }
                string status = "Unverified";
                if (nominal <= tabPengguna.Saldo)
                {
                    Deposito dep = new Deposito(idDeposito, rekeningSumber, nominal, status, DateTime.Now, DateTime.Now, null, null, bunga, aro);
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
                else
                {
                    throw new Exception("Saldo anda tidak mencukupi.");
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonDetail_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Form form = Application.OpenForms["FormMasterBunga"];
            if (form == null)
            {
                FormMasterBunga formMasterDeposito = new FormMasterBunga();
                formMasterDeposito.Owner = this;
                formMasterDeposito.Show();
            }
            else
            {
                form.Show();
                form.BringToFront();
            }
        }

        private void checkBoxARO_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxARO.Checked)
            {
                radioButtonDeposito.Enabled = true;
                radioButtonTabungan.Enabled = true;
            }
            else
            {
                radioButtonDeposito.Enabled = false;
                radioButtonTabungan.Enabled = false;
            }
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
