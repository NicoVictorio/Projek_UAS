using MySql.Data.MySqlClient;
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
        public static List<AddressBook> BacaData(string kriteria, string nilaiKriteria)
        {
            string sql = "SELECT no_rekening,id_pengguna, keterangan" +
                         "FROM inbox ";
            if (kriteria == "")
            {
                sql += ";";
            }
            else
            {
                sql += " WHERE " + kriteria + " LIKE '%" + nilaiKriteria + "%';";
            }

            MySqlDataReader hasil = Koneksi.ambilData(sql);

            //buat list untk menampung data 
            List<AddressBook> listInbox = new List<AddressBook>();
            while (hasil.Read() == true)
            {
                AddressBook adb = new AddressBook();
                adb.Keterangan = hasil.GetString(2);

                Pengguna tmpPengguna = new Pengguna();
                tmpPengguna.Nik = hasil.GetInt32(1);
                adb.Pengguna = tmpPengguna;

                Tabungan tmpTabungan = new Tabungan();
                tmpTabungan.NoRekening = hasil.GetString(2);
                adb.Tabungan = tmpTabungan;

                listInbox.Add(adb);
            }
            return listInbox;
        }

        public bool TambahData()
        {
            string sql = "INSERT INTO addressBook(no_rekening,id_pengguna, keterangan)" +
                " VALUES ('" + this.Pengguna.Nik + "','" + this.tabungan.NoRekening + "', '" +
                this.keterangan + "')";
            bool result = Koneksi.executeDML(sql);
            return result;
        }
        #endregion
    }
}
