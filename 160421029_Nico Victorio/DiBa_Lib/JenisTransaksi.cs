using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DiBa_Lib
{
    public class JenisTransaksi
    {
        #region data members
        private int idJenisTransaksi;
        private string kodeTransaksi;
        private string namaTransaksi;
        #endregion

        #region constructors
        public JenisTransaksi(int idJenisTransaksi, string kodeTransaksi, string namaTransaksi)
        {
            this.IdJenisTransaksi = idJenisTransaksi;
            this.KodeTransaksi = kodeTransaksi;
            this.NamaTransaksi = namaTransaksi;
        }

        public JenisTransaksi()
        {
            this.IdJenisTransaksi = 0;
            this.KodeTransaksi = "";
            this.NamaTransaksi = "";
        }
        #endregion

        #region properties
        public int IdJenisTransaksi { get => idJenisTransaksi; set => idJenisTransaksi = value; }
        public string KodeTransaksi { get => kodeTransaksi; set => kodeTransaksi = value; }
        public string NamaTransaksi { get => namaTransaksi; set => namaTransaksi = value; }
        #endregion

        #region methods
        public static List<JenisTransaksi> BacaData(string kriteria, string nilaiKriteria)
        {
            string sql = "SELECT id_jenistransaksi, kode, nama " + " FROM jenisTransaksi";
            if (kriteria == "")
            {
                sql += ";";
            }
            else
            {
                sql += " WHERE " + kriteria + " LIKE '%" + nilaiKriteria + "%';";
            }
            MySqlDataReader hasil = Koneksi.ambilData(sql);
            List<JenisTransaksi> listHasil = new List<JenisTransaksi>();
            while (hasil.Read())
            {
                JenisTransaksi tmp = new JenisTransaksi();
                tmp.IdJenisTransaksi = hasil.GetInt32(0);
                tmp.KodeTransaksi = hasil.GetValue(1).ToString();
                tmp.NamaTransaksi = hasil.GetValue(2).ToString();
                listHasil.Add(tmp);
            }
            return listHasil;
        }

        public static JenisTransaksi jenisTransaksiByCode(int id)
        {
            string sql = "SELECT id_jenisTransaksi, kode, nama " + " FROM jenisTransaksi " + " WHERE id_jenisTransaksi = " + id ;
            MySqlDataReader hasil = Koneksi.ambilData(sql);
            JenisTransaksi tmp = new JenisTransaksi();
            if (hasil.Read() == true)
            {
                tmp = new JenisTransaksi();
                tmp.IdJenisTransaksi = hasil.GetInt32("id_jenisTransaksi");
                tmp.KodeTransaksi = hasil.GetString("kode");
                tmp.NamaTransaksi = hasil.GetString("nama");
                return tmp;
            }
            else
            {
                return null;
            }
        }

        public bool TambahData()
        {
            string sql = "INSERT INTO jenisTransaksi( kode, nama)" + " VALUES ('"  + this.KodeTransaksi + "', '" + this.NamaTransaksi + "');";
            bool result = Koneksi.executeDML(sql);
            return result;
        }

        public bool UbahData()
        {
            string sql = "UPDATE jenistransaksi SET kode ='" + this.KodeTransaksi + "' ,"+
                         " nama ='" + this.NamaTransaksi + "' "+
                         " WHERE id_jenisTransaksi =" + this.IdJenisTransaksi + ";";
            bool result = Koneksi.executeDML(sql);
            return result;
        }

        public bool HapusData()
        {
            string sql = "DELETE FROM jenisTransaksi " +
                         " WHERE id_jenisTransaksi = '" + this.IdJenisTransaksi + "';";
            bool result = Koneksi.executeDML(sql);
            return result;
        }
        #endregion
    }
}