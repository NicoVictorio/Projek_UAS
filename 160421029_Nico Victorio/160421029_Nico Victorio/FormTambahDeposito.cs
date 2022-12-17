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
    public partial class FormTambahDeposito : Form
    {
        public FormTambahDeposito()
        {
            InitializeComponent();
        }

        private void FormTambahDeposito_Load(object sender, EventArgs e)
        {

            List<Tabungan> listTabungan = Tabungan.BacaData("", "");
            List<Employee> listEmployee = Employee.BacaData("","");

            comboBoxVerifikatorBuka.DataSource = listEmployee;
            comboBoxVerifikatorBuka.DisplayMember = "nik";

            comboBoxVerifikatorCair.DataSource = listEmployee;
            comboBoxVerifikatorCair.DisplayMember = "nik";

            comboBoxNomorRekening.DataSource = listTabungan;
            comboBoxNomorRekening.DisplayMember = "noRekening";

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Tabungan tabDipilih = (Tabungan)comboBoxNomorRekening.SelectedItem;
                Employee empBukaDipilih = (Employee)comboBoxVerifikatorBuka.SelectedItem;
                Employee empCairDipilih = (Employee)comboBoxVerifikatorCair.SelectedItem;
                Deposito dep = new Deposito(0, tabDipilih, comboBoxJatuhTempo.Text, double.Parse(textBoxNominal.Text),
                    double.Parse(textBoxBunga.Text), "", DateTime.Now, DateTime.Now, empBukaDipilih, empCairDipilih);

                if (dep.TambahData())
                {

                    MessageBox.Show("Data Deposito telah tersimpan", "Info");
                    FormDaftarDeposito frm = (FormDaftarDeposito)this.Owner;
                    frm.FormDaftarDeposito_Load(this, e);
                    this.Close();
                }
                else
                {
                    throw new Exception("Tidak dapat menambahkan data dalam database");
                }
            }
            catch(Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }
    }
}
