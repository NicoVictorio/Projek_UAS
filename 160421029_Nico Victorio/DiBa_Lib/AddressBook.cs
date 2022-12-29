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
        public static List<AddressBook> BacaDataEmployee(string kriteria, string nilaiKriteria)
        {
            string sql = "SELECT no_rekening, pengguna_id, keterangan " +
                         "FROM addressbook ";
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
            List<AddressBook> listAddressBook = new List<AddressBook>();
            while (hasil.Read() == true)
            {
                AddressBook adb = new AddressBook();

                Tabungan tmpTabungan = new Tabungan();
                tmpTabungan.NoRekening = hasil.GetString(0);
                adb.Tabungan = tmpTabungan;

                Pengguna tmpPengguna = new Pengguna();
                tmpPengguna.Id = hasil.GetInt32(1);
                adb.Pengguna = tmpPengguna;

                adb.Keterangan = hasil.GetString(2);

                listAddressBook.Add(adb);
            }
            return listAddressBook;
        }

        public static List<AddressBook> BacaDataPengguna(string kriteria, string nilaiKriteria, int idPengguna)
        {
            string sql = "SELECT no_rekening, pengguna_id, keterangan " +
                         "FROM addressbook ";
            if (kriteria == "")
            {
                sql += "WHERE pengguna_id = " + idPengguna + ";";
            }
            else
            {
                sql += " WHERE " + kriteria + " LIKE '%" + nilaiKriteria + "%' " +
                       " AND pengguna_id = " + idPengguna + ";";
            }

            MySqlDataReader hasil = Koneksi.ambilData(sql);

            //buat list untk menampung data 
            List<AddressBook> listAddressBook = new List<AddressBook>();
            while (hasil.Read() == true)
            {
                AddressBook adb = new AddressBook();

                Tabungan tmpTabungan = new Tabungan();
                tmpTabungan.NoRekening = hasil.GetString(0);
                adb.Tabungan = tmpTabungan;

                Pengguna tmpPengguna = new Pengguna();
                tmpPengguna.Id = hasil.GetInt32(1);
                adb.Pengguna = tmpPengguna;

                adb.Keterangan = hasil.GetString(2);

                listAddressBook.Add(adb);
            }
            return listAddressBook;
        }

        public bool TambahData()
        {
            string sql = "INSERT INTO addressbook(no_rekening, pengguna_id, keterangan)" +
                " VALUES ('" + this.tabungan.NoRekening + "', " + this.Pengguna.Id + ", '" +
                this.keterangan + "')";
            bool result = Koneksi.executeDML(sql);
            return result;
        }

        public bool UbahData()
        {
            string sql = "UPDATE addressbook SET pengguna_id = " + this.Pengguna.Id +
                         ", keterangan = '" + this.Keterangan +
                         "'\nWHERE no_rekening = '" + this.Tabungan.NoRekening + "';";
            bool result = Koneksi.executeDML(sql);
            return result;
        }

        public bool HapusData()
        {
            string sql = "DELETE from addressbook where no_rekening = '" + this.Tabungan.NoRekening + "';";
            bool result = Koneksi.executeDML(sql);
            return result;
        }

        public static AddressBook addressBookByCode(Pengguna pengguna, Tabungan tabungan)
        {
            string sql = "SELECT ab.keterangan, p.id, t.no_rekening " +
                         "\nFROM addressbook ab " +
                         "\nINNER JOIN Pengguna p on p.id = ab.pengguna_id " +
                         "\nINNER JOIN Tabungan t on t.no_rekening = ab.no_rekening " +
                         "\nWHERE ab.pengguna_id = " + pengguna.Id + 
                         " AND ab.no_rekening = '" + tabungan.NoRekening + "';";
            MySqlDataReader hasil = Koneksi.ambilData(sql);
            if (hasil.Read() == true)
            {
                AddressBook address = new AddressBook();
                address.Keterangan = hasil.GetString("keterangan");

                Pengguna peng = new Pengguna();
                peng.Id = hasil.GetInt32("pengguna_id");
                address.pengguna = peng;

                Tabungan tab = new Tabungan();
                tab.NoRekening = hasil.GetString("norekening");
                address.tabungan = tab;
                return address;
            }
            else
            {
                return null;
            }
        }
        #endregion
    }
}