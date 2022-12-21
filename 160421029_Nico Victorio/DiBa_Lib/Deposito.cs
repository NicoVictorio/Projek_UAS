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
        int idDeposito;
        Tabungan noRekening;
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
        public Deposito(int idDeposito, Tabungan noRekening, string jatuhTempo, double nominal, double bunga, string status, DateTime tglBuat, DateTime tglPerubahan, Employee verivikatorBuka, Employee verivikatorCair)
        {
            IdDeposito = idDeposito;
            NoRekening = noRekening;
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
            this.IdDeposito = 0;
            this.NoRekening = null;
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
        public int IdDeposito { get => idDeposito; set => idDeposito = value; }
        public Tabungan NoRekening { get => noRekening; set => noRekening = value; }
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
        public static List<Deposito> BacaData(string kriteria, string nilaiKriteria)
        {
            string sql = "SELECT dep.id_deposito, tab.no_rekening, dep.jatuh_tempo, dep.nominal, " +
                         "dep.bunga, dep.status, dep.tgl_buat, dep.tgl_perubahan, " +
                         "emp1.id as verivikator_buka, emp2.id as verivikator_cair " + "FROM deposito dep " +
                         "\nINNER JOIN employee emp1 on emp1.id = dep.verivikator_buka " +
                         "\nINNER JOIN employee emp2 on emp2.id = dep.verivikator_cair " +
                         "\nINNER JOIN tabungan tab on tab.no_rekening = dep.no_rekening ";

            //string sql = "SELECT id_deposito, no_rekening, jatuh_tempo, nominal, bunga, status, tgl_buat, tgl_perubahan" +
            //    ""

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
                dep.IdDeposito = hasil.GetInt32(0);
                dep.JatuhTempo = hasil.GetString(2);
                dep.Nominal = hasil.GetDouble(3);
                dep.Bunga = hasil.GetDouble(4);
                dep.Status = hasil.GetString(5);
                dep.TglBuat = hasil.GetDateTime(6);
                dep.TglPerubahan = hasil.GetDateTime(7);

                Tabungan tab = new Tabungan();
                tab.NoRekening = hasil.GetString(1);
                dep.NoRekening = tab;

                Employee emp1 = new Employee();
                emp1.Nik = hasil.GetString(8);
                dep.VerivikatorBuka = emp1;

                Employee emp2 = new Employee();
                emp2.Nik = hasil.GetString(9);
                dep.VerivikatorCair = emp2;
                listDeposito.Add(dep);
            }
            return listDeposito;
        }

        public bool TambahData()
        {
            string sql = "INSERT INTO deposito(no_rekening, jatuh_tempo, nominal , bunga, status, tgl_buat," +
                " tgl_perubahan,verivikator_buka, verivikator_cair)" +
                " VALUES ('" + this.NoRekening + "','" + this.JatuhTempo + "', " + this.nominal + "," +
                this.Bunga + ", 'Unverified', '" + this.TglBuat.ToString("yyyy-MM-dd HH-mm-ss") + "','" +
                this.TglPerubahan.ToString("yyyy-MM-dd HH-mm-ss") + "'," + this.verivikatorBuka.Id + "," +
                this.verivikatorCair.Id + ")";
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
            string sql = "UPDATE deposito SET status = 'Aktif', verifikator_buka =" + idEmployee +
                         " where id_deposito ='" + this.IdDeposito + "';";
            this.VerivikatorBuka = Employee.employeeByCode(idEmployee);
            bool result = Koneksi.executeDML(sql);
            return result;
        }
        #endregion
    }
}
