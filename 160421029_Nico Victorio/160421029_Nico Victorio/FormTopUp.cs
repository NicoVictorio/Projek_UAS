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
    public partial class FormTopUp : Form
    {
        FormMenu formMenu;
        public Pengguna penggunaAsal;
        public Tabungan tabungan;
        public FormTopUp()
        {
            InitializeComponent();
        }

        private void FormTopUp_Load(object sender, EventArgs e)
        {
            formMenu = (FormMenu)this.MdiParent;
            penggunaAsal = formMenu.tmpPengguna;

            List<Tabungan> tmpListTabungan = Tabungan.BacaData("pengguna_email", penggunaAsal.Email);
            tabungan = tmpListTabungan[0];
        }

        private void buttonTopUp_Click(object sender, EventArgs e)
        {
            try
            {
                int nominal = int.Parse(textBoxNominal.Text);
                Tabungan.TambahSaldo(tabungan.NoRekening, nominal);
                MessageBox.Show("Saldo telah berhasil ditambahkan");
                formMenu.tabPengguna = tabungan;
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
