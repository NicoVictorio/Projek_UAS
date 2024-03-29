﻿using System;
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

            List<Tabungan> tmpListTabungan = Tabungan.BacaData("pengguna_email", penggunaAsal.Email);
            tabPengguna = tmpListTabungan[0];

            if (tabPengguna.Status == "Aktif")
            {
                labelEmail.Text = penggunaAsal.Email;
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
                string emailPengguna = penggunaAsal.Email;
                string idDeposito = Deposito.GenerateNoDeposito(emailPengguna);

                List<Tabungan> tmpListTabungan = Tabungan.BacaData("pengguna_email", penggunaAsal.Email);
                tabPengguna = tmpListTabungan[0];
                Tabungan rekeningSumber = tabPengguna;

                string jatuhTempo = comboBoxJatuhTempo.Text;
                long nominal = long.Parse(textBoxNominal.Text);
                
                Bunga bunga = new Bunga();
                List<Bunga> tmpListBunga = new List<Bunga>();

                int bulan = 0;
                if (jatuhTempo == "1 bulan")
                {
                    bulan = 1;
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
                    bulan = 3;
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
                    bulan = 6;
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
                    bulan = 12;
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
                    bulan = 24;
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
                    bulan = 36;
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
                string keterangan = "";
                if (checkBoxARO.Checked)
                {
                    aro = true;
                    if (radioButtonDeposito.Checked)
                    {
                        keterangan = "Bunga masuk ke pokok deposito.";
                    }
                    else if (radioButtonTabungan.Checked)
                    {
                        keterangan = "Bunga masuk ke rekening tabungan.";
                    }
                }
                string status = "Unverified";
                if (nominal <= tabPengguna.Saldo)
                {
                    Deposito dep = new Deposito(idDeposito, rekeningSumber, nominal, status, DateTime.Now, DateTime.Now.AddMonths(bulan), null, null, bunga, aro, keterangan);
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
