using DiBa_Lib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace _160421029_Nico_Victorio
{
    public partial class FormUpdateTabungan : Form
    {
        public string tmpnoRek;
        FormDaftarTabungan formDaftarTabungan;
        Tabungan tmp;

        public FormUpdateTabungan()
        {
            InitializeComponent();
        }

        private void FormUpdateTabungan_Load(object sender, EventArgs e)
        {
            formDaftarTabungan = (FormDaftarTabungan)this.Owner;
            textBoxNoRek.Enabled = false;
            comboBoxPengguna.Enabled = false;

            List<Pengguna> listPengguna = Pengguna.BacaData("", "");
            List<Employee> listEmployee = Employee.BacaData("", "");

            comboBoxPengguna.DataSource = listPengguna;
            comboBoxPengguna.DisplayMember = "nama_depan";

            comboBoxVerifikator.DataSource = listEmployee;
            comboBoxVerifikator.DisplayMember = "nama_depan";

            tmp = Tabungan.tabunganByCode(tmpnoRek);
            if (tmp != null)
            {
                textBoxNoRek.Text = tmp.NoRekening;
                comboBoxPengguna.SelectedItem = tmp.Pengguna;
                textBoxSaldo.Text = tmp.Saldo.ToString();
                comboBoxStatus.SelectedItem = tmp.Status;
                textBoxKeterangan.Text = tmp.Keterangan;
                comboBoxVerifikator.SelectedItem = tmp.Employee;
            }
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            try
            {
                Pengguna pgDipilih = (Pengguna)comboBoxPengguna.SelectedItem;
                Employee emDipilih = (Employee)comboBoxVerifikator.SelectedItem;

                Tabungan k = new Tabungan(textBoxNoRek.Text, pgDipilih, double.Parse(textBoxSaldo.Text),
                    comboBoxStatus.Text, textBoxKeterangan.Text, tmp.Tgl_buat, DateTime.Now, null);
                if (k.UbahData())
                {
                    MessageBox.Show("Data Tabungan telah terubah", "Info");

                    formDaftarTabungan.FormDaftarTabungan_Load(this, e);
                    this.Close();
                }
                else
                {
                    throw new Exception("Tidak dapat mengubah data dalam database");
                }

            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
