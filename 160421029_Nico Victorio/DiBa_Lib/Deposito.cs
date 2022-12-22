using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DiBa_Lib
{
    public class Deposito
    {
        #region data members
        string idDeposito;
        Tabungan tabungan;
        string jatuhTempo;
        double nominal;
        double bunga;
        string status;
        DateTime tglBuat;
        DateTime tglPerubahan;
        Employee verivikatorBuka;
        Employee verivikatorCair;   
        #endregion

        #region constructors
        public Deposito(string idDeposito, Tabungan tabungan, string jatuhTempo, double nominal, double bunga, string status, DateTime tglBuat, DateTime tglPerubahan, Employee verivikatorBuka, Employee verivikatorCair)
        {
            IdDeposito = idDeposito;
            Tabungan = tabungan;
            JatuhTempo = jatuhTempo;
            Nominal = nominal;
            Bunga = bunga;
            Status = status;
            TglBuat = tglBuat;
            TglPerubahan = tglPerubahan;
            VerivikatorBuka = verivikatorBuka;
            VerivikatorCair = verivikatorCair;
        }

        public Deposito()
        {
            this.IdDeposito = "";
            this.Tabungan = null;
            this.JatuhTempo = "";
            this.Nominal = 0.0;
            this.Bunga = 0.0;
            this.Status = "";
            this.TglBuat = DateTime.Now;
            this.TglPerubahan = DateTime.Now;
            this.VerivikatorBuka = null;
            this.VerivikatorCair = null;
        }
        #endregion

        #region properties
        public string IdDeposito { get => idDeposito; set => idDeposito = value; }
        public Tabungan Tabungan { get => tabungan; set => tabungan = value; }
        public string JatuhTempo { get => jatuhTempo; set => jatuhTempo = value; }
        public double Nominal { get => nominal; set => nominal = value; }
        public double Bunga { get => bunga; set => bunga = value; }
        public string Status { get => status; set => status = value; }
        public DateTime TglBuat { get => tglBuat; set => tglBuat = value; }
        public DateTime TglPerubahan { get => tglPerubahan; set => tglPerubahan = value; }
        public Employee VerivikatorBuka { get => verivikatorBuka; set => verivikatorBuka = value; }
        public Employee VerivikatorCair { get => verivikatorCair; set => verivikatorCair = value; }
        #endregion

        #region methods
        public static string AmbilNoRek(int idPengguna)
        {
            string sql = "SELECT RIGHT(no_rekening,4) as NoRek FROM tabungan WHERE " +
                          "id_pengguna = " + idPengguna;
            MySqlDataReader hasilNoRek = Koneksi.ambilData(sql);
            string noRek = "";
            if (hasilNoRek.Read())
            {
                noRek = hasilNoRek.GetString(0);
            }
            return noRek;
        }

        public static string GenerateNoDeposito(int idPengguna)
        {
            string sql = "SELECT RIGHT(id_deposito,4) as NoDep FROM deposito WHERE " +
                    " Date(tgl_buat) = Date(CURRENT_DATE) order by tgl_buat DESC limit 1";
            MySqlDataReader hasil = Koneksi.ambilData(sql);
            string hasilNoDep = "";
            string noRek = AmbilNoRek(idPengguna);
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
            string sql = "SELECT id_deposito, no_rekening, jatuh_tempo, nominal, bunga, " +
                         "status, tgl_buat, tgl_perubahan, " +
                         "IFNULL(verivikator_buka, 0) as verivikator_buka, " +
                         "IFNULL(verivikator_cair, 0) as verivikator_cair " + 
                         " FROM deposito ";

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
                dep.JatuhTempo = hasil.GetString(2);
                dep.Nominal = hasil.GetDouble(3);
                dep.Bunga = hasil.GetDouble(4);
                dep.Status = hasil.GetString(5);
                dep.TglBuat = hasil.GetDateTime(6);
                dep.TglPerubahan = hasil.GetDateTime(7);

                Tabungan tab = new Tabungan();
                tab.NoRekening = hasil.GetString(1);
                dep.Tabungan = tab;

                Employee emp1 = new Employee();
                emp1.Id = hasil.GetInt32(8);
                dep.VerivikatorBuka = emp1;

                Employee emp2 = new Employee();
                emp2.Id = hasil.GetInt32(9);
                dep.VerivikatorCair = emp2;
                listDeposito.Add(dep);
            }
            return listDeposito;
        }

        public bool TambahData()
        {
            string sql = "INSERT INTO deposito(id_deposito, no_rekening, jatuh_tempo, " +
                                               "nominal, bunga, status, tgl_buat, tgl_perubahan) " +
                         "VALUES ('" + this.IdDeposito + "', '" +
                                       this.Tabungan.NoRekening + "', '" +
                                       this.JatuhTempo + "', " +
                                       this.Nominal + ", " +
                                       this.Bunga + ", '" +
                                       this.Status + "', '" +
                                       this.TglBuat.ToString("yyyy-MM-dd HH-mm-ss") + "', '" +
                                       this.TglPerubahan.ToString("yyyy-MM-dd HH-mm-ss") + "'); ";
            bool result = Koneksi.executeDML(sql);
            return result;
        }

        public bool UbahData()
        {
            string sql = "UPDATE deposito SET verivikator_buka = " + this.VerivikatorBuka.Id +
                         ", verivikator_cair = '" + this.VerivikatorCair.Id + ", tgl_perubahan = " + DateTime.Now +
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

        //public static AddressBook addressBookByCode(Pengguna pengguna, Tabungan tabungan)
        //{
        //    string sql = "SELECT ab.keterangan, p.nik, t.no_rekening " +
        //                 "\nFROM addressbook ab " +
        //                 "\nINNER JOIN Pengguna p on p.nik = ab.id_pengguna " +
        //                 "\nINNER JOIN Tabungan t on t.no_rekening = ab.no_rekening " +
        //                 "\nWHERE ab.id_pengguna = " + pengguna.Nik +
        //                 " AND ab.no_rekening = '" + tabungan.NoRekening + "';";
        //    MySqlDataReader hasil = Koneksi.ambilData(sql);
        //    if (hasil.Read() == true)
        //    {
        //        AddressBook address = new AddressBook();
        //        address.Keterangan = hasil.GetString("keterangan");

        //        Pengguna peng = new Pengguna();
        //        peng.Nik = hasil.GetInt32("id_pengguna");
        //        address.pengguna = peng;

        //        Tabungan tab = new Tabungan();
        //        tab.NoRekening = hasil.GetString("norekening");
        //        address.tabungan = tab;
        //        return address;
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}

        public bool UbahStatus(int idEmployee)
        {
            string sql = "UPDATE deposito SET status = 'Aktif', verivikator_buka =" + idEmployee +
                         " where id_deposito ='" + this.IdDeposito + "';";
            this.VerivikatorBuka = Employee.employeeByCode(idEmployee);
            bool result = Koneksi.executeDML(sql);
            return result;
        }

        public override string ToString()
        {
            return idDeposito;
        }
        #endregion
    }
}