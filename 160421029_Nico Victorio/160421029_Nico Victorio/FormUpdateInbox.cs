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
    public partial class FormUpdateInbox : System.Windows.Forms.Form
    {
        public int idPesan;
        //FormMasterEmployee formMasterEmployee;
        Inbox tmp;
        public FormUpdateInbox()
        {
            InitializeComponent();
        }

        private void FormUpdateInbox_Load(object sender, EventArgs e)
        {
            //formMasterEmployee = (FormMasterEmployee)this.Owner;
            //comboBoxPosition.DataSource = formMasterEmployee.listPosition;
            //comboBoxPosition.DisplayMember = "nama";
            //FormInbox formInbox = (FormInbox)this.Owner;
            List<Pengguna> listPengguna = Pengguna.BacaData("", "");
            comboBoxIdPengguna.Enabled = false;
            tmp = Inbox.inboxByCode(idPesan);
            if (tmp != null)
            {
                comboBoxIdPengguna.Text = tmp.Pengguna.Nik.ToString();
                textBoxPesan.Text = tmp.Pesan;
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                Pengguna pengguna = (Pengguna)comboBoxIdPengguna.SelectedItem;
                Inbox emp = new Inbox(tmp.IdPesan, pengguna, textBoxPesan.Text, tmp.TglKirim, tmp.Status, DateTime.Now);
                if (emp.UbahData())
                {
                    MessageBox.Show("Data employee telah terubah", "Info");
                    FormInbox formInbox = (FormInbox)this.Owner;
                    formInbox.FormInbox_Load(this, e);
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
    }
}
