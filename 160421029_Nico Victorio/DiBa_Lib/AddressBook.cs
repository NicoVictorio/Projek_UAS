using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiBa_Lib
{
    public class AddressBook
    {
        #region data members
        private Tabungan tabungan;
        private Pengguna pengguna;
        private string keterangan;
        #endregion

        #region constructors
        public AddressBook(Tabungan tabungan, Pengguna pengguna, string keterangan)
        {
            this.Tabungan = tabungan;
            this.Pengguna = pengguna;
            this.Keterangan = keterangan;
        }

        public AddressBook()
        {
            this.Tabungan = null;
            this.Pengguna = null;
            this.Keterangan = "";
        }
        #endregion

        #region properties
        public Tabungan Tabungan { get => tabungan; set => tabungan = value; }
        public Pengguna Pengguna { get => pengguna; set => pengguna = value; }
        public string Keterangan { get => keterangan; set => keterangan = value; }
        #endregion

        #region methods

        #endregion
    }
}
