using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiBa_Lib;
using MySql.Data.MySqlClient;

namespace DiBa_Lib
{
    public class Pangkat
    {
        #region data members
        string kodePangkat;
        string jenisPangkat;
        #endregion

        #region constructors
        public Pangkat(string kodePangkat, string jenisPangkat)
        {
            KodePangkat = kodePangkat;
            JenisPangkat = jenisPangkat;
        }
        public Pangkat()
        {
            this.KodePangkat = "";
            this.JenisPangkat = "";
        }
        #endregion

        #region properties
        public string KodePangkat { get => kodePangkat; set => kodePangkat = value; }
        public string JenisPangkat { get => jenisPangkat; set => jenisPangkat = value; }
        #endregion

        public static List<Pangkat> BacaData(string kriteria, string nilaiKriteria)
        {
            string sql = "SELECT kode_pangkat, jenis_pangkat " + " FROM pangkat";
            if (kriteria == "")
            {
                sql += ";";
            }
            else
            {
                sql += " WHERE " + kriteria + " LIKE '%" + nilaiKriteria + "%';";
            }
            MySqlDataReader hasil = Koneksi.ambilData(sql);
            List<Pangkat> listHasil = new List<Pangkat>();
            while (hasil.Read())
            {
                Pangkat tmp = new Pangkat(hasil.GetValue(0).ToString(), hasil.GetValue(1).ToString());
                listHasil.Add(tmp);
            }
            return listHasil;
        }
    }
}