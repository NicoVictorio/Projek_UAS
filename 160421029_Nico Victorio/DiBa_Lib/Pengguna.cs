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
        private int id;
        private int nik;
        private string namaDepan;
        private string namaKeluarga;
        private string alamat;
        private string email;
        private string noTelp;
        private string password;
        private string pin;
        private DateTime tglBuat;
        private DateTime tglPerubahan;
        private Pangkat pangkat;
        private List<AddressBook> listAddressBook;
        #endregion

        #region constructors
        public Pengguna(int id, int nik, string namaDepan, string namaKeluarga, string alamat, string email,
            string noTelp, string password, string pin, DateTime tglBuat, DateTime tglPerubahan, Pangkat pangkat)
        {
            this.Id = id;
            this.Nik = nik;
            this.NamaDepan = namaDepan;
            this.NamaKeluarga = namaKeluarga;
            this.Alamat = alamat;
            this.Email = email;
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
            Id = 0;
            Nik = 0;
            NamaDepan = "";
            NamaKeluarga = "";
            Alamat = "";
            Email = "";
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
        public int Id { get => id; set => id = value; }
        public int Nik { get => nik; set => nik = value; }
        public string NamaDepan { get => namaDepan; set => namaDepan = value; }
        public string NamaKeluarga { get => namaKeluarga; set => namaKeluarga = value; }
        public string Alamat { get => alamat; set => alamat = value; }
        public string Email { get => email; set => email = value; }
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
                sql = "select p.id, p.nik, p.nama_depan, p.nama_keluarga, p.alamat, p.email, p.no_telepon, p.password, " +
                "p.pin, p.tgl_buat, p.tgl_perubahan, pg.kode_pangkat, pg.jenis_pangkat from pengguna as p inner join pangkat as pg " +
                "on p.kode_pangkat = pg.kode_pangkat ";
                //sql = "select *  from pengguna as p inner join pangkat as pg " +
                //"on p.kode_pangkat = pg.kode_pangkat ";
            }
            else
            {
                sql = "select p.id, p.nik, p.nama_depan,p.nama_keluarga, p.alamat, p.email, p.no_telepon, p.password, " +
                "p.pin, p.tgl_buat, p.tgl_perubahan, pg.kode_pangkat,  pg.jenis_pangkat  from pengguna as p inner join pangkat as pg on p.kode_pangkat = pg.kode_pangkat "
                + "where " + kriteria + " like '%" + nilaiKriteria + "%'";
            }

            MySqlDataReader hasil = Koneksi.ambilData(sql);

            //buat list untk menampung data 
            List<Pengguna> listPengguna = new List<Pengguna>();
            while (hasil.Read() == true)
            {
                Pangkat pg = new Pangkat(hasil.GetValue(11).ToString(), hasil.GetValue(12).ToString());

                Pengguna p = new Pengguna(hasil.GetInt32(0), hasil.GetInt32(1), hasil.GetString(2), hasil.GetString(3),
                    hasil.GetString(4), hasil.GetString(5), hasil.GetString(6), hasil.GetString(7), hasil.GetString(8),
                    DateTime.Parse(hasil.GetValue(9).ToString()), DateTime.Parse(hasil.GetValue(10).ToString()), pg);
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
                    string sql = "INSERT INTO pengguna (nik, nama_depan, nama_keluarga, alamat, email, " +
                             "no_telepon, password, pin, tgl_buat, tgl_perubahan, kode_pangkat) " +
                             "values (" + this.Nik + ", '"
                                        + this.NamaDepan.Replace("'", "\\'") + "', '"
                                        + this.NamaKeluarga.Replace("'", "\\'") + "', '"
                                        + this.Alamat + "', '"
                                        + this.Email + "', '"
                                        + this.NoTelp + "', '"
                                        + this.Password + "', '"
                                        + this.Pin + "', '"
                                        + this.TglBuat.ToString("yyyy-MM-dd HH-mm-ss") + "', '"
                                        + this.TglPerubahan.ToString("yyyy-MM-dd HH-mm-ss") + "', '"
                                        + this.Pangkat.KodePangkat + "');";
                    bool result = Koneksi.executeDML(sql,k);
                    
                    Tabungan tab = new Tabungan(noRek, p, 0, "Unverified", "", DateTime.Now, DateTime.Now, null);
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
                                     ", nama_depan= '" + this.NamaDepan.Replace("'", "\\'") + 
                                     "', nama_keluarga= '" + this.NamaKeluarga +
                                     "', alamat= '" + this.Alamat + 
                                     "', email= '" + this.Email + 
                                     "', no_telepon= '" + this.NoTelp + 
                                     "', password= '" + this.Password + 
                                     "', pin= '" + this.Pin + 
                                     "', tgl_buat='" + this.TglBuat.ToString("yyyy-MM-dd HH-mm-ss") + 
                                     "', tgl_perubahan='" + this.TglPerubahan.ToString("yyyy-MM-dd HH-mm-ss") +
                                     "' where id = " + this.Id + ";";
            bool result = Koneksi.executeDML(sql);
            return result;
        }

        public bool HapusData()
        {
            string sql = "DELETE FROM pengguna " +
                         " WHERE id = '" + this.Id + "';";
            bool result = Koneksi.executeDML(sql);
            return result;
        }

        public static Pengguna Login(string username, string password)
        {
            string sql = "";

            if (username == "" || password == "")
            {
                throw new Exception("Email/No Telp atau password tidak boleh kosong");
            }
            else
            {
                sql = "select p.id, p.nik, p.nama_depan,p.nama_keluarga, p.alamat, p.email, p.no_telepon, p.password, " +
                "p.pin, p.tgl_buat, p.tgl_perubahan,pg.kode_pangkat,  pg.jenis_pangkat  from pengguna as p inner join pangkat as pg on p.kode_pangkat = pg.kode_pangkat "
                + "WHERE(p.email = '" + username + "') and password = '" + password + "';";
            }

            MySqlDataReader hasil = Koneksi.ambilData(sql);
            Pengguna tmp;
            if (hasil.Read() == true)
            {
                Pangkat pg = new Pangkat(hasil.GetValue(11).ToString(), hasil.GetValue(12).ToString());

                tmp = new Pengguna(hasil.GetInt32(0), hasil.GetInt32(1), hasil.GetString(2), hasil.GetString(3),
                    hasil.GetString(4), hasil.GetString(5), hasil.GetString(6), hasil.GetString(7), hasil.GetString(8),
                    DateTime.Parse(hasil.GetValue(9).ToString()), DateTime.Parse(hasil.GetValue(10).ToString()), pg);
                return tmp;
            }
            return null;
        }

        public static Pengguna penggunaByCode(string id)
        {
            string sql = "select p.id, p.nik, p.nama_depan,p.nama_keluarga, p.alamat, p.email, p.no_telepon, p.password, " +
                "p.pin, p.tgl_buat, p.tgl_perubahan, pg.kode_pangkat, pg.jenis_pangkat  from pengguna as p inner join pangkat as pg " +
                "on p.kode_pangkat = pg.kode_pangkat where p.id = '" + id + "';";
            MySqlDataReader hasil = Koneksi.ambilData(sql);
            Pengguna tmp;
            if (hasil.Read() == true)
            {
                Pangkat pg = new Pangkat(hasil.GetValue(11).ToString(), hasil.GetValue(12).ToString());

                tmp = new Pengguna(hasil.GetInt32(0), hasil.GetInt32(1), hasil.GetString(2), hasil.GetString(3),
                    hasil.GetString(4), hasil.GetString(5), hasil.GetString(6), hasil.GetString(7), hasil.GetString(8),
                    DateTime.Parse(hasil.GetValue(9).ToString()), DateTime.Parse(hasil.GetValue(10).ToString()), pg);
                return tmp;
            }
            else
            {
                return null;
            }
        }

        public bool UbahPassword()
        {
            string sql = "UPDATE pengguna SET password ='" + this.Password + "' where id = " + this.Id + ";";
            bool result = Koneksi.executeDML(sql);
            return result;
        }

        public bool TambahPin(string pin)
        {
            string sql = "UPDATE pengguna SET pin ='" + pin  + "' where id = " + this.Id + ";";
            bool result = Koneksi.executeDML(sql);
            return result;
        }

        public override string ToString()
        {
            return Id.ToString();
        }
        #endregion
    }
}