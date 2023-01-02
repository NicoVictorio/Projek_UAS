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
        double nominal;
        string status;
        DateTime tglBuat;
        DateTime tglPerubahan;
        Employee verifikatorBuka;
        Employee verifikatorCair;
        Bunga bunga;
        Boolean aro;
        #endregion

        #region constructors
        public Deposito(string idDeposito, Tabungan tabungan, double nominal, string status, DateTime tglBuat, DateTime tglPerubahan, Employee verifikatorBuka, Employee verifikatorCair, Bunga bunga, Boolean aro)
        {
            IdDeposito = idDeposito;
            Tabungan = tabungan;
            Nominal = nominal;
            Status = status;
            TglBuat = tglBuat;
            TglPerubahan = tglPerubahan;
            VerifikatorBuka = verifikatorBuka;
            VerifikatorCair = verifikatorCair;
            Bunga = bunga;
            Aro = aro;
        }

        public Deposito()
        {
            this.IdDeposito = "";
            this.Tabungan = null;
            this.Nominal = 0.0;
            this.Status = "";
            this.TglBuat = DateTime.Now;
            this.TglPerubahan = DateTime.Now;
            this.VerifikatorBuka = null;
            this.VerifikatorCair = null;
            this.Bunga = null;
            this.Aro = false;
        }
        #endregion

        #region properties
        public string IdDeposito { get => idDeposito; set => idDeposito = value; }
        public Tabungan Tabungan { get => tabungan; set => tabungan = value; }
        public double Nominal { get => nominal; set => nominal = value; }
        public string Status { get => status; set => status = value; }
        public DateTime TglBuat { get => tglBuat; set => tglBuat = value; }
        public DateTime TglPerubahan { get => tglPerubahan; set => tglPerubahan = value; }
        public Employee VerifikatorBuka { get => verifikatorBuka; set => verifikatorBuka = value; }
        public Employee VerifikatorCair { get => verifikatorCair; set => verifikatorCair = value; }
        public Bunga Bunga { get => bunga; set => bunga = value; }
        public Boolean Aro { get => aro; set => aro = value; }
        #endregion

        #region methods
        public static string AmbilNoRek(string emailPengguna)
        {
            string sql = "SELECT RIGHT(no_rekening,4) as NoRek FROM tabungan WHERE " +
                          "pengguna_email = " + emailPengguna;
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
                    " Date(tgl_buat) = Date(CURRENT_DATE) order by tgl_buat DESC limit 1";
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
                         "status, tgl_buat, tgl_perubahan, " +
                         "IFNULL(verifikator_buka, 0) as verifikator_buka, " +
                         "IFNULL(verifikator_cair, 0) as verifikator_cair, " + 
                         "idBunga, aro FROM deposito ";

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
                dep.Nominal = hasil.GetDouble(2);
                dep.Status = hasil.GetString(3);
                dep.TglBuat = hasil.GetDateTime(4);
                dep.TglPerubahan = hasil.GetDateTime(5);

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
                bunga.IdBunga = hasil.GetInt32(8);
                dep.Bunga = bunga;

                dep.Aro = hasil.GetBoolean(9);
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
                                                       "nominal, status, tgl_buat, tgl_perubahan, " +
                                                       "idbunga, aro) " +
                                 "VALUES ('" + this.IdDeposito + "', '" +
                                               this.Tabungan.NoRekening + "', " +
                                               this.Nominal + ", '" +
                                               this.Status + "', '" +
                                               this.TglBuat.ToString("yyyy-MM-dd HH-mm-ss") + "', '" +
                                               this.TglPerubahan.ToString("yyyy-MM-dd HH-mm-ss") + "', " + 
                                               this.Bunga.IdBunga + ", " + this.Aro + ");";
                    Tabungan.UpdateSaldoTransaksi("pengeluaran", this.Tabungan.NoRekening, this.Nominal, k);
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

        public bool UbahData()
        {
            string sql = "UPDATE deposito SET verifikator_buka = " + this.VerifikatorBuka.Email +
                         ", verifikator_cair = '" + this.VerifikatorCair.Email + ", tgl_perubahan = " + DateTime.Now +
                         "'\nWHERE id_deposito = '" + this.idDeposito + "';";
            bool result = Koneksi.executeDML(sql);
            return result;
        }

        public bool HapusData()
        {
            string sql = "DELETE from deposito where id_deposito = '" + this.idDeposito + "';";
            bool result = Koneksi.executeDML(sql);
            return result;
        }

        public bool UbahStatusAktif(string emailEmployee)
        {
            string sql = "UPDATE deposito SET status = 'Aktif', verifikator_buka = " + emailEmployee +
                         " where id_deposito ='" + this.IdDeposito + "';";
            this.VerifikatorBuka = Employee.employeeByCode(emailEmployee);
            bool result = Koneksi.executeDML(sql);
            return result;
        }

        public bool UbahStatusWaiting()
        {
            string sql = "UPDATE deposito SET status = 'Waiting'" +
                         " where id_deposito ='" + this.IdDeposito + "';";
            
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
                    string sql = "UPDATE deposito SET status = 'Completed', verifikator_cair = " + emailEmployee +
                     " where id_deposito = '" + this.IdDeposito + "';";
                    bool result = Koneksi.executeDML(sql, k);
                    if (bunga != 0)
                    {
                        Tabungan.UpdateSaldoTransaksi("pemasukan", this.Tabungan.NoRekening, this.Nominal + bunga, k);
                    }
                    else if (denda != 0)
                    {
                        Tabungan.UpdateSaldoTransaksi("pemasukan", this.Tabungan.NoRekening, this.Nominal, k);
                        Tabungan.UpdateSaldoTransaksi("pengeluaran", this.Tabungan.NoRekening, denda, k);
                    }
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

        public override string ToString()
        {
            return idDeposito;
        }
        #endregion
    }
}