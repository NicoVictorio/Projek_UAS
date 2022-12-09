using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DiBa_Lib
{
    public class Tabungan
    {
        #region data members
        private string noRekening;
        private Pengguna pengguna;
        private double saldo;
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
            this.Status = "";
            this.Keterangan = "";
            this.Tgl_buat = DateTime.Now;
            this.Tgl_perubahan = DateTime.Now;
            this.Employee = null;
        }

        public Tabungan(string noRekening, Pengguna pengguna, double saldo, string status, string keterangan, DateTime tgl_buat, DateTime tgl_perubahan, Employee employee)
        {
            this.NoRekening = noRekening;
            this.Pengguna = pengguna;
            this.Saldo = saldo;
            this.Status = status;
            this.Keterangan = keterangan;
            this.Tgl_buat = tgl_buat;
            this.Tgl_perubahan = tgl_perubahan;
            this.Employee = employee;
        }
        #endregion

        #region properties
        public string NoRekening { get => noRekening; set => noRekening = value; }
        public double Saldo { get => saldo; set => saldo = value; }
        public string Status { get => status; set => status = value; }
        public string Keterangan { get => keterangan; set => keterangan = value; }
        public DateTime Tgl_buat { get => tgl_buat; set => tgl_buat = value; }
        public DateTime Tgl_perubahan { get => tgl_perubahan; set => tgl_perubahan = value; }
        public Employee Employee { get => employee; set => employee = value; }
        public Pengguna Pengguna { get => pengguna; set => pengguna = value; }
        #endregion

        #region methods
        public static List<Tabungan> BacaData(string kriteria, string nilaiKriteria)
        {
            string sql = "SELECT no_rekening, id_pengguna, saldo, status, keterangan, " +
                         "tgl_buat, tgl_perubahan, employee " +
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

            //buat list untk menampung data 
            while (hasil.Read() == true)
            {
                Tabungan tab = new Tabungan();
                tab.NoRekening = hasil.GetString(0);
                tab.Saldo = hasil.GetDouble(2);
                tab.Status = hasil.GetString(3);
                tab.Keterangan = hasil.GetString(4);
                tab.Tgl_buat = DateTime.Parse(hasil.GetString(5));
                tab.Tgl_perubahan = DateTime.Parse(hasil.GetString(6));

                Pengguna tmpPengguna = new Pengguna();
                tmpPengguna.Nik = hasil.GetInt32(1);
                tab.Pengguna = tmpPengguna;

                Employee tmpEmployee = new Employee();
                tmpEmployee.Id = hasil.GetInt32(7);
                tab.Pengguna = tmpPengguna;

                listTabungan.Add(tab);
            }
            return listTabungan;
        }

        public bool TambahData()
        {
            string sql = "INSERT INTO tabungan (no_rekening, id_pengguna, saldo, status, " +
                                         "keterangan, tgl_buat, tgl_perubahan, employee) " +
                         " VALUES ('" + this.NoRekening + "', " + this.Pengguna.Nik + ", " +
                         this.Saldo + ", '" + this.Status + "', '" + this.Keterangan + "', '" +
                         this.Tgl_buat.ToString("yyyy-MM-dd") + "', '" + 
                         this.Tgl_perubahan.ToString("yyyy-MM-dd") + "', " + this.Employee.Id + ");";
            bool result = Koneksi.executeDML(sql);
            return result;
        }
        public bool UbahData()
        {
            string sql = "UPDATE tabungan SET id_pengguna = " + this.Pengguna.Nik + 
                         ", saldo = " + this.Saldo + ", status = '" + this.Status + 
                         "', keterangan = '" + this.Keterangan + "', tgl_buat = '" + this.Tgl_buat + 
                         "', tgl_perubahan = '" + this.Tgl_perubahan + "', verifikator = " + 
                         this.Employee.Id + " WHERE no_rekening = " + this.NoRekening + ";";
            bool result = Koneksi.executeDML(sql);
            return result;
        }

        public bool HapusData()
        {
            string sql = "DELETE from tabungan where no_rekening = " + this.NoRekening + ";";
            bool result = Koneksi.executeDML(sql);
            return result;
        }

        //public static Inbox inboxByCode(int id)
        //{
        //    string sql = "SELECT id_pesan,id_pengguna, pesan, tanggal_kirim, status, tgl_perubahan  " +
        //                 "FROM inbox WHERE id_pesan=" + id;
        //    MySqlDataReader hasil = Koneksi.ambilData(sql);
        //    if (hasil.Read() == true)
        //    {
        //        Inbox emp = new Inbox();
        //        emp.IdPesan = hasil.GetInt32(0);
        //        emp.Pesan = hasil.GetString(2);
        //        emp.TglKirim = DateTime.Parse(hasil.GetString(3));
        //        emp.Status = hasil.GetString(4);
        //        emp.TglPerubahan = DateTime.Parse(hasil.GetString(5));

        //        Pengguna tmpPengguna = new Pengguna();
        //        tmpPengguna.Nik = hasil.GetInt32(1);
        //        emp.Pengguna = tmpPengguna; ;
        //        return emp;
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}

        //public bool UbahStatus()
        //{
        //    string sql = "UPDATE inbox SET status ='Terbuka' where id_pengguna=" + this.Pengguna.Nik + " and id_pesan=" + this.IdPesan + ";";
        //    bool result = Koneksi.executeDML(sql);
        //    return result;
        //}
        #endregion
    }
}
