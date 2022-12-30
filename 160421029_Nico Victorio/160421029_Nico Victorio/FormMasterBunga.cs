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
    public partial class FormMasterBunga : Form
    {
        public List<Bunga> listBunga = new List<Bunga>();

        public FormMasterBunga()
        {
            InitializeComponent();
        }

        private void FormMasterBunga_Load(object sender, EventArgs e)
        {
            listBunga = Bunga.BacaData("", "");
            if (listBunga.Count > 0)
            {
                dataGridViewListBunga.DataSource = listBunga;
            }
            else
            {
                dataGridViewListBunga.DataSource = null;
            }
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
