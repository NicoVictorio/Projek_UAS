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
    public partial class FormTabunganPengguna : Form
    {
        FormMenu formMenu;
        public Pengguna penggunaAsal;
        public Tabungan tabunganAsal;
        public FormTabunganPengguna()
        {
            InitializeComponent();
        }

        private void FormTabunganPengguna_Load(object sender, EventArgs e)
        {
            formMenu = (FormMenu)this.MdiParent;
            
            List<Tabungan> tmpListTabungan = Tabungan.BacaData("pengguna_id", penggunaAsal.Id.ToString());
            tabunganAsal = tmpListTabungan[0];
            
            labelNomorRekening.Text = tabunganAsal.NoRekening;
            labelSaldo.Text = tabunganAsal.Saldo.ToString();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
