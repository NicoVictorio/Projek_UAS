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
    public partial class FormTambahPosition : System.Windows.Forms.Form
    {
        FormMasterPosition formPosition;
        //int dataCount;
        public FormTambahPosition()
        {
            InitializeComponent();
        }

        private void FormTambahPosition_Load(object sender, EventArgs e)
        {
            formPosition = (FormMasterPosition)this.Owner;
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            try
            {
                //int dataCount = formPosition.listPosition.Count();
                Position js = new Position(1, tb_NamaPosition.Text, tb_Keterangan.Text);
                if (js.TambahData())
                {
                    MessageBox.Show("Data Position telah tersimpan", "Info");
                    FormMasterPosition frm = (FormMasterPosition)this.Owner;
                    frm.FormPosition_Load(this, e);
                    this.Close();
                }
                else
                {
                    throw new Exception("Tidak dapat menambahkan data dalam database");
                }

            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //MessageBox.Show("Penyimpanan gagal. Pesan kesalahan: " + x.Message, "Kesalahan");
            }
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
