using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using MySql.Data.MySqlClient;

namespace DiBa_Lib
{
    public class Deposito
    {
        #region data members
        string idDeposito;
        Tabungan tabungan;
        long nominal;
        string status;
        DateTime tglAwal;
        DateTime tglCair;
        Employee verifikatorBuka;
        Employee verifikatorCair;
        Bunga bunga;
        Boolean aro;
        string keterangan;
        #endregion

        #region constructors
        public Deposito(string idDeposito, Tabungan tabungan, long nominal, string status, DateTime tglAwal, DateTime tglCair, Employee verifikatorBuka, Employee verifikatorCair, Bunga bunga, Boolean aro, string keterangan)
        {
            IdDeposito = idDeposito;
            Tabungan = tabungan;
            Nominal = nominal;
            Status = status;
            TglAwal = tglAwal;
            TglCair = tglCair;
            VerifikatorBuka = verifikatorBuka;
            VerifikatorCair = verifikatorCair;
            Bunga = bunga;
            Aro = aro;
            Keterangan = keterangan;
        }

        public Deposito()
        {
            this.IdDeposito = "";
            this.Tabungan = null;
            this.Nominal = 0;
            this.Status = "";
            this.TglAwal = DateTime.Now;
            this.TglCair = DateTime.Now;
            this.VerifikatorBuka = null;
            this.VerifikatorCair = null;
            this.Bunga = null;
            this.Aro = false;
            this.Keterangan = "";
        }
        #endregion

        #region properties
        public string IdDeposito { get => idDeposito; set => idDeposito = value; }
        public Tabungan Tabungan { get => tabungan; set => tabungan = value; }
        public long Nominal { get => nominal; set => nominal = value; }
        public string Status { get => status; set => status = value; }
        public DateTime TglAwal { get => tglAwal; set => tglAwal = value; }
        public DateTime TglCair { get => tglCair; set => tglCair = value; }
        public Employee VerifikatorBuka { get => verifikatorBuka; set => verifikatorBuka = value; }
        public Employee VerifikatorCair { get => verifikatorCair; set => verifikatorCair = value; }
        public Bunga Bunga { get => bunga; set => bunga = value; }
        public Boolean Aro { get => aro; set => aro = value; }
        public string Keterangan { get => keterangan; set => keterangan = value; }
        #endregion

        #region methods
        public static string AmbilNoRek(string emailPengguna)
        {
            string sql = "SELECT RIGHT(no_rekening,4) as NoRek FROM tabungan WHERE " +
                          "pengguna_email = '" + emailPengguna + "';";
            MySqlDataReader hasilNoRek = Koneksi.ambilData(sql);
            string noRek = "";
            if (hasilNoRek.Read())
            {
                noRek = hasilNoRek.GetString(0);
            }
            return noRek;
        }

        public static string GenerateNoDeposito(string emailPengguna)
        {
            string sql = "SELECT RIGHT(id_deposito,4) as NoDep FROM deposito WHERE " +
                    " Date(tgl_awal) = Date(CURRENT_DATE) order by tgl_awal DESC limit 1";
            MySqlDataReader hasil = Koneksi.ambilData(sql);
            string hasilNoDep = "";
            string noRek = AmbilNoRek(emailPengguna);
            if (hasil.Read())
            {
                if (hasil.GetString(0) != "")
                {
                    int noDep = hasil.GetInt32(0) + 1;
                    hasilNoDep = DateTime.Now.Year.ToString() + "/" +
                                 DateTime.Now.Month.ToString().PadLeft(2, '0') + "/" +
                                 DateTime.Now.Day.ToString().PadLeft(2, '0') + "/" +
                                 noRek.PadLeft(4, '0') + "/" +
                                 noDep.ToString().PadLeft(4, '0');
                }
            }
            else
            {
                hasilNoDep = DateTime.Now.Year.ToString() + "/" +
                             DateTime.Now.Month.ToString().PadLeft(2, '0') + "/" +
                             DateTime.Now.Day.ToString().PadLeft(2, '0') + "/" +
                             noRek.PadLeft(4, '0') + "/" +
                             "0001";
            }
            return hasilNoDep;
        }

        public static List<Deposito> BacaData(string kriteria, string nilaiKriteria)
        {
            string sql = "SELECT id_deposito, no_rekening, nominal, " +
                         "status, tgl_awal, tgl_cair, " +
                         "IFNULL(verifikator_buka, 0) as verifikator_buka, " +
                         "IFNULL(verifikator_cair, 0) as verifikator_cair, " + 
                         "idBunga, aro, keterangan FROM deposito ";

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
            List<Deposito> listDeposito = new List<Deposito>();

            while (hasil.Read() == true)
            {
                Deposito dep = new Deposito();
                dep.IdDeposito = hasil.GetString(0);
                dep.Nominal = hasil.GetInt64(2);
                dep.Status = hasil.GetString(3);
                dep.TglAwal = hasil.GetDateTime(4);
                dep.TglCair = hasil.GetDateTime(5);

                Tabungan tab = new Tabungan();
                tab.NoRekening = hasil.GetString(1);
                dep.Tabungan = tab;

                Employee emp1 = new Employee();
                emp1.Email = hasil.GetString(6);
                dep.VerifikatorBuka = emp1;

                Employee emp2 = new Employee();
                emp2.Email = hasil.GetString(7);
                dep.VerifikatorCair = emp2;

                Bunga bunga = new Bunga();
                bunga = Bunga.bungaByCode(hasil.GetInt32(8));
                dep.Bunga = bunga;

                dep.Aro = hasil.GetBoolean(9);
                dep.Keterangan = hasil.GetString(10);
                listDeposito.Add(dep);
            }
            return listDeposito;
        }

        public static List<Deposito> DepositoByCode(string kriteria1, bool nilaiKriteria1, string kriteria2, string nilaiKriteria2)
        {
            string sql = "SELECT id_deposito, no_rekening, nominal, " +
                         "status, tgl_awal, tgl_cair, " +
                         "IFNULL(verifikator_buka, 0) as verifikator_buka, " +
                         "IFNULL(verifikator_cair, 0) as verifikator_cair, " +
                         "idBunga, aro, keterangan FROM deposito " +
                         " WHERE " + kriteria1 + " = " + nilaiKriteria1 + " && " +
                                     kriteria2 + " LIKE '%" + nilaiKriteria2 + "%';";

            MySqlDataReader hasil = Koneksi.ambilData(sql);

            //buat list untk menampung data 
            List<Deposito> listDeposito = new List<Deposito>();

            while (hasil.Read() == true)
            {
                Deposito dep = new Deposito();
                dep.IdDeposito = hasil.GetString(0);
                dep.Nominal = hasil.GetInt64(2);
                dep.Status = hasil.GetString(3);
                dep.TglAwal = hasil.GetDateTime(4);
                dep.TglCair = hasil.GetDateTime(5);

                Tabungan tab = new Tabungan();
                tab.NoRekening = hasil.GetString(1);
                dep.Tabungan = tab;

                Employee emp1 = new Employee();
                emp1.Email = hasil.GetString(6);
                dep.VerifikatorBuka = emp1;

                Employee emp2 = new Employee();
                emp2.Email = hasil.GetString(7);
                dep.VerifikatorCair = emp2;

                Bunga bunga = new Bunga();
                bunga = Bunga.bungaByCode(hasil.GetInt32(8));
                dep.Bunga = bunga;

                dep.Aro = hasil.GetBoolean(9);
                dep.Keterangan = hasil.GetString(10);
                listDeposito.Add(dep);
            }
            return listDeposito;
        }

        public bool TambahData()
        {
            using (TransactionScope transcope = new TransactionScope())
            {
                try
                {
                    Koneksi k = new Koneksi();
                    string sql = "INSERT INTO deposito(id_deposito, no_rekening, " +
                                                       "nominal, status, tgl_awal, tgl_cair, " +
                                                       "idbunga, aro, keterangan) " +
                                 "VALUES ('" + this.IdDeposito + "', '" +
                                               this.Tabungan.NoRekening + "', " +
                                               this.Nominal + ", '" +
                                               this.Status + "', '" +
                                               this.TglAwal.ToString("yyyy-MM-dd HH-mm-ss") + "', '" +
                                               this.TglCair.ToString("yyyy-MM-dd HH-mm-ss") + "', " + 
                                               this.Bunga.IdBunga + ", " + this.Aro + ", '" + 
                                               this.Keterangan + "');";

                    Tabungan.KurangSaldo(this.Tabungan.NoRekening, (int)this.Nominal, k);

                    Tabungan tabPengguna = Tabungan.tabunganByCode(this.Tabungan.NoRekening, k);
                    Tabungan.UpdatePoin(this.Tabungan.NoRekening, nominal, k);

                    Inbox inbox = new Inbox(0, tabPengguna.Pengguna, "Poin bertambah sebesar " + (nominal * 10 / 100).ToString("C2"), DateTime.Now, "", DateTime.Now);
                    inbox.TambahData(k);

                    bool result = Koneksi.executeDML(sql, k);
                    transcope.Complete();
                    return result;
                }
                catch (Exception x)
                {
                    transcope.Dispose();
                    throw new Exception(x.Message);
                }
            }
        }

        public bool UbahStatusAktif(string emailEmployee)
        {
            string sql = "UPDATE deposito SET status = 'Aktif', verifikator_buka = '" + emailEmployee +
                         "' where id_deposito = '" + this.IdDeposito + "';";
            this.VerifikatorBuka = Employee.employeeByCode(emailEmployee);
            bool result = Koneksi.executeDML(sql);
            return result;
        }

        public bool UbahStatusWaiting()
        {
            string sql = "UPDATE deposito SET status = 'Waiting'" +
                         " where id_deposito = '" + this.IdDeposito + "';";
            
            bool result = Koneksi.executeDML(sql);
            return result;
        }

        public bool UbahStatusCompleted(string emailEmployee, double denda, double bunga)
        {
            using (TransactionScope transcope = new TransactionScope())
            {
                try
                {
                    Koneksi k = new Koneksi();
                    string sql = "UPDATE deposito SET status = 'Completed', verifikator_cair = '" + emailEmployee +
                     "' where id_deposito = '" + this.IdDeposito + "';";
                    bool result = Koneksi.executeDML(sql, k);
                    Tabungan tabPengguna = Tabungan.tabunganByCode(this.Tabungan.NoRekening,k);
                    if (bunga != 0)
                    {
                        Tabungan.TambahSaldo(tabPengguna.NoRekening, (int)(this.Nominal + bunga));
                    }
                    else if (denda != 0)
                    {
                        Tabungan.TambahSaldo(tabPengguna.NoRekening, (int)this.Nominal);
                        Tabungan.KurangSaldo(tabPengguna.NoRekening, (int)denda, k);
                    }
                    Inbox inboxPengembalian = new Inbox(0, tabPengguna.Pengguna, "Nominal deposito awal sebesar " + nominal.ToString("C2"), DateTime.Now, "", DateTime.Now);
                    inboxPengembalian.TambahData(k);
                    transcope.Complete();
                    return result;
                }
                catch (Exception x)
                {
                    transcope.Dispose();
                    throw new Exception(x.Message);
                }
            }
        }

        public bool UbahStatusAro(bool aro)
        {
            string sql = "";
            if (aro == true)
            {
                sql = "UPDATE deposito SET aro = " + false + 
                      " where id_deposito = '" + this.IdDeposito + "';";
            }
            else if(aro == false)
            {
                sql = "UPDATE deposito SET aro = " + true +
                      " where id_deposito = '" + this.IdDeposito + "';";
            }
            bool result = Koneksi.executeDML(sql);
            return result;
        }

        public static void TambahBunga(string kriteria, int bunga, string noRekening, string idDeposito)
        {
            string sql = "";
            if (kriteria == "Bunga masuk ke pokok deposito.")
            {
                sql = "UPDATE deposito SET nominal = nominal + " + bunga +
                      " where id_deposito = '" + idDeposito + "';";
            }
            else if (kriteria == "Bunga masuk ke rekening tabungan.")
            {
                sql = "UPDATE tabungan SET saldo = saldo + " + bunga +
                      " where no_rekening = '" + noRekening + "';";
            }
            Koneksi.executeDML(sql);
        }

        public static void UpdateTanggal(string idDeposito, DateTime tanggalAwal, DateTime tanggalCair)
        {
            string sql = "UPDATE deposito SET tgl_awal = '" + tanggalAwal.ToString("yyyy-MM-dd HH-mm-ss") + 
                                          "', tgl_cair = '" + tanggalCair.ToString("yyyy-MM-dd HH-mm-ss") +
                         "' where id_deposito = '" + idDeposito + "';";
            Koneksi.executeDML(sql);
        }

        public override string ToString()
        {
            return idDeposito;
        }
        #endregion
    }
}