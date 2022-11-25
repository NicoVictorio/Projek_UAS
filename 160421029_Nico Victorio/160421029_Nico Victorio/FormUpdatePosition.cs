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
    public partial class FormUpdatePosition : Form
    {
        public int idPosition;
        public FormUpdatePosition()
        {
            InitializeComponent();
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            try
            {
                if (tb_IdPosition.Text == "")
                {
                    tb_IdPosition.Focus();
                    throw new Exception("Id position harus diisi");
                }
                else if (tb_NamaPosition.Text == "")
                {
                    tb_NamaPosition.Focus();
                    throw new Exception("Nama posisi harus diisi");
                }
                else if (tb_Keterangan.Text == "")
                {
                    tb_Keterangan.Focus();
                    throw new Exception("Keterangan harus diisi");
                }

                Position pos = new Position(int.Parse(tb_IdPosition.Text), tb_NamaPosition.Text, tb_Keterangan.Text);

                if (pos.UbahData())
                {
                    MessageBox.Show("Data position baru berhasil diubah ke database.");
                    FormPosition form = (FormPosition)this.Owner;
                    form.FormPosition_Load(sender, e);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Data position baru gagal diubah ke database.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormUpdatePosition_Load(object sender, EventArgs e)
        {
            FormPosition frm = (FormPosition)this.Owner;
            Position tmp = Position.positionByCode(idPosition);
            if (tmp != null)
            {
                tb_IdPosition.Text = tmp.IdPosition.ToString();
                tb_NamaPosition.Text = tmp.NamaPosition;
                tb_Keterangan.Text = tmp.Keterangan;
            }
        }
    }
}
