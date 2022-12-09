using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiBa_Lib
{
    public class Transaksi
    {
        #region data members
        Tabungan noRekeningSumber;
        string idTransaksi;
        string tglTransaksi;
        JenisTransaksi idJenisTransaksi;
        Tabungan noRekeningTujuan;
        double nominal;
        string keterangan;
        #endregion

        #region constructors
        public Transaksi(Tabungan noRekeningSumber, string idTransaksi, string tglTransaksi,
               JenisTransaksi idJenisTransaksi, Tabungan noRekeningTujuan, double nominal, string keterangan)
        {
            NoRekeningSumber = noRekeningSumber;
            IdTransaksi = idTransaksi;
            TglTransaksi = tglTransaksi;
            IdJenisTransaksi = idJenisTransaksi;
            NoRekeningTujuan = noRekeningTujuan;
            Nominal = nominal;
            Keterangan = keterangan;
        }
        public Transaksi()
        {
            this.NoRekeningSumber = null;
            this.IdTransaksi = "";
            this.TglTransaksi = "";
            this.IdJenisTransaksi = null;
            this.NoRekeningTujuan = null;
            this.Nominal = 0.0;
            this.Keterangan = "";

        }
        #endregion

        #region properties
        public Tabungan NoRekeningSumber { get => noRekeningSumber; set => noRekeningSumber = value; }
        public string IdTransaksi { get => idTransaksi; set => idTransaksi = value; }
        public string TglTransaksi { get => tglTransaksi; set => tglTransaksi = value; }
        public JenisTransaksi IdJenisTransaksi { get => idJenisTransaksi; set => idJenisTransaksi = value; }
        public Tabungan NoRekeningTujuan { get => noRekeningTujuan; set => noRekeningTujuan = value; }
        public double Nominal { get => nominal; set => nominal = value; }
        public string Keterangan { get => keterangan; set => keterangan = value; }
        #endregion

        #region methods
        public static List<Transaksi> BacaData(string kriteria, string nilaiKriteria)
        {
            string sql = "SELECT rekening_sumber, idtransaksi, tgl_transaksi, id_jenisTransaksi, rekening_tujuan, " +
                         "nominal, keterangan " +
                         "FROM transaksi ";
            if (kriteria == "")
            {
                sql += ";";
            }
            else
            {
                sql += " WHERE " + kriteria + " LIKE '%" + nilaiKriteria + "%';";
            }

            MySqlDataReader hasil = Koneksi.ambilData(sql);

            List<Transaksi> listTransaksi = new List<Transaksi>();

            //buat list untk menampung data 
            while (hasil.Read() == true)
            {
                Transaksi tra = new Transaksi();
                tra.IdTransaksi = hasil.GetString(1);
                tra.TglTransaksi = hasil.GetString(2);
                tra.Nominal = hasil.GetDouble(5);
                tra.Keterangan = hasil.GetString(6);

                Tabungan tmpTabungan = new Tabungan();
                tmpTabungan.NoRekening = hasil.GetString(0);
                tra.NoRekeningSumber = tmpTabungan;

                JenisTransaksi tmpJenisT = new JenisTransaksi();
                tmpJenisT.IdJenisTransaksi = hasil.GetInt32(3);
                tra.IdJenisTransaksi = tmpJenisT;

                Tabungan tmpTabungan2 = new Tabungan();
                tmpTabungan2.NoRekening = hasil.GetString(4);
                tra.NoRekeningSumber = tmpTabungan2;

                listTransaksi.Add(tra);
            }
            return listTransaksi;
        }
        public bool TambahData()
        {
            string sql = "INSERT INTO transaksi (rekening_sumber, idtransaksi, tgl_transaksi, id_jenisTransaksi, " +
                "rekening_tujuan, nominal, keterangan) " +
                         " VALUES ('" + this.NoRekeningSumber.NoRekening + "', " + this.IdTransaksi + ", " +
                         this.TglTransaksi + ", '" + this.NoRekeningTujuan.NoRekening + "', '" + this.Nominal + "', '" +
                         this.Keterangan + "' );";
            bool result = Koneksi.executeDML(sql);
            return result;
        }
        public bool UbahData()
        {
            string sql = "UPDATE transaksi SET rekening_sumber = " + this.NoRekeningSumber.NoRekening +
                         ", tgl_transaksi = " + this.TglTransaksi + ", id_jenisTransaksi = '" + this.IdJenisTransaksi.IdJenisTransaksi +
                         "', rekening_tujuan = '" + this.NoRekeningTujuan.NoRekening + "', nominal = '" + this.Nominal +
                         "', keterangan = '" + this.Keterangan + "' WHERE idtransaksi = '" + this.IdTransaksi + "';";
            bool result = Koneksi.executeDML(sql);
            return result;
        }
        public bool HapusData()
        {
            string sql = "DELETE from transaksi where idtransaksi = '" + this.IdTransaksi + "';";
            bool result = Koneksi.executeDML(sql);
            return result;
        }
        #endregion
    }
}
