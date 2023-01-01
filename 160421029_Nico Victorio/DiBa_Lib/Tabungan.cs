using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Transactions;

namespace DiBa_Lib
{
    public class Tabungan
    {
        #region data members
        private string noRekening;
        private Pengguna pengguna;
        private double saldo;
        private double poin;
        private string status;
        private string keterangan;
        private DateTime tgl_buat;
        private DateTime tgl_perubahan;
        private Employee employee;
        #endregion

        #region constructors
        public Tabungan()
        {
            this.NoRekening = "";
            this.Pengguna = null;
            this.Saldo = 0.0;
            this.Poin = 0.0;
            this.Status = "";
            this.Keterangan = "";
            this.Tgl_buat = DateTime.Now;
            this.Tgl_perubahan = DateTime.Now;
            this.Employee = null;
        }

        public Tabungan(string noRekening, Pengguna pengguna, double saldo, double poin, string status, string keterangan, DateTime tgl_buat, DateTime tgl_perubahan, Employee employee)
        {
            this.NoRekening = noRekening;
            this.Pengguna = pengguna;
            this.Saldo = saldo;
            this.Poin = poin;
            this.Status = status;
            this.Keterangan = keterangan;
            this.Tgl_buat = tgl_buat;
            this.Tgl_perubahan = tgl_perubahan;
            this.Employee = employee;
        }
        #endregion

        #region properties
        public string NoRekening { get => noRekening; set => noRekening = value; }
        public Pengguna Pengguna { get => pengguna; set => pengguna = value; }
        public double Saldo { get => saldo; set => saldo = value; }
        public double Poin { get => poin; set => poin = value; }
        public string Status { get => status; set => status = value; }
        public string Keterangan { get => keterangan; set => keterangan = value; }
        public DateTime Tgl_buat { get => tgl_buat; set => tgl_buat = value; }
        public DateTime Tgl_perubahan { get => tgl_perubahan; set => tgl_perubahan = value; }
        public Employee Employee { get => employee; set => employee = value; }
        #endregion

        #region methods
        public static string GenerateNoRek()
        {
            string sql = "SELECT RIGHT(no_rekening,2) as NoRek FROM tabungan WHERE " +
                " Date(tgl_perubahan) = Date(CURRENT_DATE) order by tgl_perubahan DESC limit 1";
            MySqlDataReader hasil = Koneksi.ambilData(sql);
            string hasilNoRek = "";
            if (hasil.Read())
            {
                if (hasil.GetString(0) != "")
                {
                    int noRek = hasil.GetInt32(0) + 1;
                    hasilNoRek = DateTime.Now.Year.ToString() +
                        DateTime.Now.Month.ToString().PadLeft(2, '0') +
                        DateTime.Now.Day.ToString().PadLeft(2, '0') +
                        noRek.ToString().PadLeft(2, '0');
                }
            }
            else
            {
                hasilNoRek = DateTime.Now.Year.ToString() +
                    DateTime.Now.Month.ToString().PadLeft(2, '0') +
                    DateTime.Now.Day.ToString().PadLeft(2, '0') +
                    "01";
            }
            return hasilNoRek;
        }

        public static List<Tabungan> BacaData(string kriteria, string nilaiKriteria)
        {
            string sql = "SELECT no_rekening, pengguna_id, saldo, poin, status, IFNULL(keterangan,'') as keterangan, " +
                         "tgl_buat, tgl_perubahan, IFNULL(verifikator, 0) as verifikator " +
                         "FROM tabungan ";
            if (kriteria == "")
            {
                sql += ";";
            }
            else
            {
                sql += " WHERE " + kriteria + " LIKE '%" + nilaiKriteria + "%';";
            }

            MySqlDataReader hasil = Koneksi.ambilData(sql);

            List<Tabungan> listTabungan = new List<Tabungan>();

            while (hasil.Read() == true)
            {
                Tabungan tab = new Tabungan();
                tab.NoRekening = hasil.GetString("no_rekening");
 
                Pengguna tmpPengguna = new Pengguna();
                tmpPengguna.Id = hasil.GetInt32("pengguna_id");
                tab.Pengguna = tmpPengguna;

                tab.Saldo = hasil.GetDouble("saldo");
                tab.Poin = hasil.GetDouble("poin");
                tab.Status = hasil.GetString("status");
                tab.Keterangan = hasil.GetString("keterangan");
                tab.Tgl_buat = DateTime.Parse(hasil.GetValue(6).ToString());
                tab.Tgl_perubahan = DateTime.Parse(hasil.GetValue(7).ToString());

                Employee tmpEmployee = new Employee();
                tmpEmployee.Id = hasil.GetInt32("verifikator");
                tab.Employee = tmpEmployee;

                listTabungan.Add(tab);
            }
            return listTabungan;
        }

        public bool TambahData()
        {
            string sql = "INSERT INTO tabungan (no_rekening, pengguna_id, saldo, poin, status, " +
                                         "keterangan, tgl_buat, tgl_perubahan) " +
                         " VALUES ('" + this.NoRekening + "', " + this.Pengguna.Id + ", " +
                                        this.Saldo + ", " + this.Poin + ", '" + 
                                        this.Status + "', '" + this.Keterangan + "', '" +
                                        this.Tgl_buat.ToString("yyyy-MM-dd HH-mm-ss") + "', '" + 
                                        this.Tgl_perubahan.ToString("yyyy-MM-dd HH-mm-ss") + "');";
            bool result = Koneksi.executeDML(sql);
            return result;
        }

        public bool TambahData(Koneksi k)
        {
            string sql = "INSERT INTO tabungan (no_rekening, pengguna_id, saldo, poin, status, " +
                                         "keterangan, tgl_buat, tgl_perubahan) " +
                         " VALUES ('" + this.NoRekening + "', " + this.Pengguna.Id + ", " +
                                        this.Saldo + ", " + this.Poin + ", '" +
                                        this.Status + "', '" + this.Keterangan + "', '" +
                                        this.Tgl_buat.ToString("yyyy-MM-dd HH-mm-ss") + "', '" +
                                        this.Tgl_perubahan.ToString("yyyy-MM-dd HH-mm-ss") + "');";
            bool result = Koneksi.executeDML(sql,k);
            return result;
        }

        public bool UbahData()
        {
            string sql = "UPDATE tabungan SET pengguna_id = " + this.Pengguna.Id + 
                         ", saldo = " + this.Saldo + ", poin = " + this.Poin + 
                         ", status = '" + this.Status + "', keterangan = '" + this.Keterangan + 
                         "', tgl_buat = '" + this.Tgl_buat.ToString("yyyy-MM-dd HH-mm-ss") + 
                         "', tgl_perubahan = '" + this.Tgl_perubahan.ToString("yyyy-MM-dd HH-mm-ss") + "' " +
                         " WHERE no_rekening = '" + this.NoRekening + "';";
            bool result = Koneksi.executeDML(sql);
            return result;
        }

        public static void TambahSaldo(string nomorRekening, int nominal)
        {
            string sql = "UPDATE tabungan SET saldo = saldo + " + nominal +
                         " WHERE no_rekening = '" + nomorRekening + "';";
            bool result = Koneksi.executeDML(sql);
        }

        public static void UpdateSaldoTransaksi(string jenisTransaksi, string nomorRekening, double nominal, Koneksi k)
        {
            using (TransactionScope transcope = new TransactionScope())
            {
                try
                {
                    string sql = "";
                    if (jenisTransaksi == "pengeluaran")
                    {
                        sql = "UPDATE tabungan SET saldo = saldo - " + nominal +
                                     " WHERE no_rekening = '" + nomorRekening + "';";
                        UpdatePoin(nomorRekening, nominal, k);
                    }
                    else
                    {
                        sql = "UPDATE tabungan SET saldo = saldo + " + nominal +
                                     " WHERE no_rekening = '" + nomorRekening + "';";
                    }
                    Koneksi.executeDML(sql, k);
                    transcope.Complete();
                }
                catch (Exception ex)
                {
                    transcope.Dispose();
                    throw new Exception(ex.Message);
                }
            }
        }

        public static void UpdatePoin(string nomorRekening, double nominal, Koneksi k)
        {
            string sql = "UPDATE tabungan SET poin = poin + " + (nominal * 10 / 100) +
                         " WHERE no_rekening = '" + nomorRekening + "';";
            Koneksi.executeDML(sql, k);
        }

        public bool HapusData()
        {
            string sql = "DELETE from tabungan where no_rekening = " + this.NoRekening + ";";
            bool result = Koneksi.executeDML(sql);
            return result;
        }

        public static Tabungan tabunganByCode(string noRek)
        {
            string sql = "SELECT no_rekening, pengguna_id, saldo, poin, status, " +
                         "IFNULL(keterangan,'') as keterangan, tgl_buat, tgl_perubahan, " +
                         "verifikator FROM tabungan WHERE no_rekening = '" + noRek + "'";
            MySqlDataReader hasil = Koneksi.ambilData(sql);
            if (hasil.Read() == true)
            {
                Tabungan tab = new Tabungan();
                tab.NoRekening = hasil.GetString(0);
                tab.Saldo = hasil.GetDouble(2);
                tab.Poin = hasil.GetDouble(3);
                tab.Status = hasil.GetString(4);
                tab.Keterangan = hasil.GetString(5);
                tab.Tgl_buat = DateTime.Parse(hasil.GetString(6));
                tab.Tgl_perubahan = DateTime.Parse(hasil.GetString(7));

                Pengguna tmpPengguna = new Pengguna();
                tmpPengguna.Id = hasil.GetInt32(1);
                tab.Pengguna = tmpPengguna;

                Employee tmpEmployee = new Employee();
                tmpEmployee.Id = hasil.GetInt32(8);
                tab.Employee = tmpEmployee;
                return tab;
            }
            else
            {
                return null;
            }
        }

        public bool UbahStatus(int idEmployee)
        {
            string sql = "UPDATE tabungan SET status = 'Aktif', verifikator=" + idEmployee +  
                         " where no_rekening ='" + this.NoRekening + "';";
            this.Employee = Employee.employeeByCode(idEmployee);
            bool result = Koneksi.executeDML(sql);
            return result;
        }

        public bool UbahStatusSuspend()
        {
            string sql = "UPDATE tabungan SET status = 'Suspend', verifikator = NULL"  +
                         " where no_rekening ='" + this.NoRekening + "';";
            bool result = Koneksi.executeDML(sql);
            return result;
        }

        public override string ToString()
        {
            return noRekening;
        }
        #endregion
    }
}