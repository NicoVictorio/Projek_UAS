using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using MySql.Data.MySqlClient;

namespace DiBa_Lib
{
    public class Pengguna
    {
        #region data members
        private string email;
        private int nik;
        private string namaDepan;
        private string namaKeluarga;
        private string alamat;
        private string noTelp;
        private string password;
        private string pin;
        private DateTime tglBuat;
        private DateTime tglPerubahan;
        private Pangkat pangkat;
        private List<AddressBook> listAddressBook;
        #endregion

        #region constructors
        public Pengguna(string email, int nik, string namaDepan, string namaKeluarga, string alamat, 
                        string noTelp, string password, string pin, DateTime tglBuat, 
                        DateTime tglPerubahan, Pangkat pangkat)
        {
            this.Email = email;
            this.Nik = nik;
            this.NamaDepan = namaDepan;
            this.NamaKeluarga = namaKeluarga;
            this.Alamat = alamat;
            this.NoTelp = noTelp;
            this.Password = password;
            this.Pin = pin;
            this.TglBuat = tglBuat;
            this.TglPerubahan = tglPerubahan;
            this.Pangkat = pangkat;
            this.ListAddressBook = new List<AddressBook>();
        }

        public Pengguna()
        {
            Email = "";
            Nik = 0;
            NamaDepan = "";
            NamaKeluarga = "";
            Alamat = "";
            NoTelp = "";
            Password = "";
            Pin = "";
            TglBuat = DateTime.Now;
            TglPerubahan = DateTime.Now;
            Pangkat = null;
            this.ListAddressBook = null;
        }
        #endregion

        #region properties
        public string Email { get => email; set => email = value; }
        public int Nik { get => nik; set => nik = value; }
        public string NamaDepan { get => namaDepan; set => namaDepan = value; }
        public string NamaKeluarga { get => namaKeluarga; set => namaKeluarga = value; }
        public string Alamat { get => alamat; set => alamat = value; }
        public string NoTelp { get => noTelp; set => noTelp = value; }
        public string Password { get => password; set => password = value; }
        public string Pin { get => pin; set => pin = value; }
        public DateTime TglBuat { get => tglBuat; set => tglBuat = value; }
        public DateTime TglPerubahan { get => tglPerubahan; set => tglPerubahan = value; }
        public Pangkat Pangkat { get => pangkat; set => pangkat = value; }
        public List<AddressBook> ListAddressBook { get => listAddressBook; set => listAddressBook = value; }
        #endregion

        #region methods
        public static List<Pengguna> BacaData(string kriteria, string nilaiKriteria)
        {
            string sql = "";

            if (kriteria == "")
            {
                sql = "select p.email, p.nik, p.nama_depan, p.nama_keluarga, p.alamat, p.no_telepon, p.password, " +
                "p.pin, p.tgl_buat, p.tgl_perubahan, pg.kode_pangkat, pg.jenis_pangkat from pengguna as p inner join pangkat as pg " +
                "on p.kode_pangkat = pg.kode_pangkat ";
            }
            else
            {
                sql = "select p.email, p.nik, p.nama_depan, p.nama_keluarga, p.alamat, p.no_telepon, p.password, " +
                "p.pin, p.tgl_buat, p.tgl_perubahan, pg.kode_pangkat,  pg.jenis_pangkat  from pengguna as p inner join pangkat as pg on p.kode_pangkat = pg.kode_pangkat "
                + "where " + kriteria + " like '%" + nilaiKriteria + "%'";
            }

            MySqlDataReader hasil = Koneksi.ambilData(sql);

            //buat list untk menampung data 
            List<Pengguna> listPengguna = new List<Pengguna>();
            while (hasil.Read() == true)
            {
                Pangkat pg = new Pangkat(hasil.GetValue(10).ToString(), hasil.GetValue(11).ToString());

                Pengguna p = new Pengguna(hasil.GetString(0), hasil.GetInt32(1), hasil.GetString(2), hasil.GetString(3),
                    hasil.GetString(4), hasil.GetString(5), hasil.GetString(6), hasil.GetString(7),
                    DateTime.Parse(hasil.GetValue(8).ToString()), DateTime.Parse(hasil.GetValue(9).ToString()), pg);
                listPengguna.Add(p);
            }
            return listPengguna;
        }

        public  bool TambahData(Pengguna p, string noRek)
        {
            using (TransactionScope transcope = new TransactionScope())
            {
                try
                {
                    Koneksi k = new Koneksi();
                    string sql = "INSERT INTO pengguna (email, nik, nama_depan, nama_keluarga, alamat, " +
                             "no_telepon, password, pin, tgl_buat, tgl_perubahan, kode_pangkat) " +
                             "values ('" + this.Email + "', "
                                         + this.Nik + ", '"
                                         + this.NamaDepan.Replace("'", "\\'") + "', '"
                                         + this.NamaKeluarga.Replace("'", "\\'") + "', '"
                                         + this.Alamat + "', '"
                                         + this.NoTelp + "', '"
                                         + this.Password + "', '"
                                         + this.Pin + "', '"
                                         + this.TglBuat.ToString("yyyy-MM-dd HH-mm-ss") + "', '"
                                         + this.TglPerubahan.AddMonths(1).ToString("yyyy-MM-dd HH-mm-ss") + "', '"
                                         + this.Pangkat.KodePangkat + "');";
                    bool result = Koneksi.executeDML(sql,k);
                    
                    Tabungan tab = new Tabungan(noRek, p, 0, 0, "Unverified", "", DateTime.Now, DateTime.Now, null);
                    tab.TambahData(k);
                    
                    transcope.Complete();
                    return result;
                }
                catch(Exception x)
                {
                    transcope.Dispose();
                    throw new Exception(x.Message);
                }
            }
        }

        public  bool UbahData()
        {
            string sql = "update pengguna set nik = " + this.Nik + 
                                     ", nama_depan = '" + this.NamaDepan.Replace("'", "\\'") + 
                                     "', nama_keluarga = '" + this.NamaKeluarga +
                                     "', alamat = '" + this.Alamat + 
                                     "', no_telepon = '" + this.NoTelp + 
                                     "', password = '" + this.Password + 
                                     "', pin = '" + this.Pin + 
                                     "', tgl_buat = '" + this.TglBuat.ToString("yyyy-MM-dd HH-mm-ss") + 
                                     "', tgl_perubahan = '" + this.TglPerubahan.ToString("yyyy-MM-dd HH-mm-ss") +
                                     "' where email = '" + this.Email + "';";
            bool result = Koneksi.executeDML(sql);
            return result;
        }

        public bool HapusData()
        {
            string sql = "DELETE FROM pengguna " +
                         " WHERE email = '" + this.Email + "';";
            bool result = Koneksi.executeDML(sql);
            return result;
        }

        public static Pengguna Login(string username, string password)
        {
            string sql = "";

            if (username == "" || password == "")
            {
                throw new Exception("Email atau password tidak boleh kosong");
            }
            else
            {
                sql = "select p.email, p.nik, p.nama_depan, p.nama_keluarga, p.alamat, p.no_telepon, p.password, " +
                "p.pin, p.tgl_buat, p.tgl_perubahan,pg.kode_pangkat,  pg.jenis_pangkat  from pengguna as p inner join pangkat as pg on p.kode_pangkat = pg.kode_pangkat "
                + "WHERE(p.email = '" + username + "') and password = '" + password + "';";
            }

            MySqlDataReader hasil = Koneksi.ambilData(sql);
            Pengguna tmp;
            if (hasil.Read() == true)
            {
                Pangkat pg = new Pangkat(hasil.GetValue(10).ToString(), hasil.GetValue(11).ToString());

                tmp = new Pengguna(hasil.GetString(0), hasil.GetInt32(1), hasil.GetString(2), hasil.GetString(3),
                    hasil.GetString(4), hasil.GetString(5), hasil.GetString(6), hasil.GetString(7),
                    DateTime.Parse(hasil.GetValue(8).ToString()), DateTime.Parse(hasil.GetValue(9).ToString()), pg);
                return tmp;
            }
            return null;
        }

        public static Pengguna penggunaByCode(string email)
        {
            string sql = "select p.email, p.nik, p.nama_depan,p.nama_keluarga, p.alamat, p.no_telepon, p.password, " +
                "p.pin, p.tgl_buat, p.tgl_perubahan, pg.kode_pangkat, pg.jenis_pangkat  from pengguna as p inner join pangkat as pg " +
                "on p.kode_pangkat = pg.kode_pangkat where p.email = '" + email + "';";
            MySqlDataReader hasil = Koneksi.ambilData(sql);
            Pengguna tmp;
            if (hasil.Read() == true)
            {
                Pangkat pg = new Pangkat(hasil.GetValue(10).ToString(), hasil.GetValue(11).ToString());

                tmp = new Pengguna(hasil.GetString(0), hasil.GetInt32(1), hasil.GetString(2), hasil.GetString(3),
                    hasil.GetString(4), hasil.GetString(5), hasil.GetString(6), hasil.GetString(7),
                    DateTime.Parse(hasil.GetValue(8).ToString()), DateTime.Parse(hasil.GetValue(9).ToString()), pg);
                return tmp;
            }
            else
            {
                return null;
            }
        }

        public bool UbahPassword()
        {
            string sql = "UPDATE pengguna SET password ='" + this.Password + "' where email = '" + this.Email + "';";
            bool result = Koneksi.executeDML(sql);
            return result;
        }

        public bool TambahPin(string pin)
        {
            string sql = "UPDATE pengguna SET pin = '" + pin  + "' where email = '" + this.Email + "';";
            bool result = Koneksi.executeDML(sql);
            return result;
        }

        public static bool UpdatePangkat(string nomorRekening, string email)
        {
            List<Tabungan> tmpListTabungan = Tabungan.BacaData("no_rekening", nomorRekening);
            Tabungan tabPengguna = tmpListTabungan[0];
            string sql = "";
            if (tabPengguna.Poin < 1000000)
            {
                sql = "UPDATE pengguna SET kode_pangkat = 'BRZ' " +
                      "WHERE email = '" + email + "';";
            }
            else if (tabPengguna.Poin >= 1000000 && tabPengguna.Poin < 10000000)
            {
                sql = "UPDATE pengguna SET kode_pangkat = 'SLV' " +
                      "WHERE email = '" + email + "';";
            }
            else if (tabPengguna.Poin >= 10000000 && tabPengguna.Poin < 100000000)
            {
                sql = "UPDATE pengguna SET kode_pangkat = 'GLD' " +
                      "WHERE email = '" + email + "';";
            }
            else
            {
                sql = "UPDATE pengguna SET kode_pangkat = 'PLT' " +
                      "WHERE email = '" + email + "';";
            }
            bool result = Koneksi.executeDML(sql);
            return result;
        }

        public static bool UpdatePangkat(string nomorRekening, Koneksi k)
        {
            List<Tabungan> tmpListTabungan = Tabungan.BacaData("no_rekening", nomorRekening);
            Tabungan tabPengguna = tmpListTabungan[0];
            string sql = "";
            if (tabPengguna.Poin < 1000000)
            {
                sql = "UPDATE pengguna SET pangkat = 'BRZ' " +
                      "INNER JOIN tabungan tab on tab.pengguna_email = pengguna.email " +
                      "WHERE tab.no_rekening = " + nomorRekening + ";";
            }
            else if (tabPengguna.Poin >= 1000000 && tabPengguna.Poin < 10000000)
            {
                sql = "UPDATE pengguna SET pangkat = 'SLV' " +
                      "INNER JOIN tabungan tab on tab.pengguna_email = pengguna.email " +
                      "WHERE tab.no_rekening = " + nomorRekening + ";";
            }
            else if (tabPengguna.Poin >= 10000000 && tabPengguna.Poin < 100000000)
            {
                sql = "UPDATE pengguna SET pangkat = 'GLD' " +
                      "INNER JOIN tabungan tab on tab.pengguna_email = pengguna.email " +
                      "WHERE tab.no_rekening = " + nomorRekening + ";";
            }
            else
            {
                sql = "UPDATE pengguna SET pangkat = 'PLT' " +
                      "INNER JOIN tabungan tab on tab.pengguna_email = pengguna.email " +
                      "WHERE tab.no_rekening = " + nomorRekening + ";";
            }
            bool result = Koneksi.executeDML(sql, k);
            return result;
        }

        public static void HapusDataPengguna(string email)
        {
            string sql = "DELETE from pengguna where email = '" + email + "';";
            Koneksi.executeDML(sql);
        }

        public override string ToString()
        {
            return Email;
        }
        #endregion
    }
}