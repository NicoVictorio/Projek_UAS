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
            string sql = "SELECT no_rekening, id_pengguna, keterangan " +
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
                tmpPengguna.Nik = hasil.GetInt32(1);
                adb.Pengguna = tmpPengguna;

                adb.Keterangan = hasil.GetString(2);

                listAddressBook.Add(adb);
            }
            return listAddressBook;
        }

        public static List<AddressBook> BacaDataPengguna(string kriteria, string nilaiKriteria, int idPengguna)
        {
            string sql = "SELECT no_rekening, id_pengguna, keterangan " +
                         "FROM addressbook ";
            if (kriteria == "")
            {
                sql += ";";
            }
            else
            {
                sql += " WHERE " + kriteria + " LIKE '%" + nilaiKriteria + "%' " + 
                       " AND id_pengguna = " + idPengguna + ";";
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
                tmpPengguna.Nik = hasil.GetInt32(1);
                adb.Pengguna = tmpPengguna;

                adb.Keterangan = hasil.GetString(2);

                listAddressBook.Add(adb);
            }
            return listAddressBook;
        }

        public bool TambahData()
        {
            string sql = "INSERT INTO addressbook(no_rekening, id_pengguna, keterangan)" +
                " VALUES ('" + this.tabungan.NoRekening + "', " + this.Pengguna.Nik + ", '" +
                this.keterangan + "')";
            bool result = Koneksi.executeDML(sql);
            return result;
        }

        public bool UbahData()
        {
            string sql = "UPDATE addressbook SET id_pengguna = " + this.Pengguna.Nik +
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
            string sql = "SELECT ab.keterangan, p.nik, t.no_rekening " +
                         "\nFROM addressbook ab " +
                         "\nINNER JOIN Pengguna p on p.nik = ab.id_pengguna " +
                         "\nINNER JOIN Tabungan t on t.no_rekening = ab.no_rekening " +
                         "\nWHERE ab.id_pengguna = " + pengguna.Nik + 
                         " AND ab.no_rekening = '" + tabungan.NoRekening + "';";
            MySqlDataReader hasil = Koneksi.ambilData(sql);
            if (hasil.Read() == true)
            {
                AddressBook address = new AddressBook();
                address.Keterangan = hasil.GetString("keterangan");

                Pengguna peng = new Pengguna();
                peng.Nik = hasil.GetInt32("id_pengguna");
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