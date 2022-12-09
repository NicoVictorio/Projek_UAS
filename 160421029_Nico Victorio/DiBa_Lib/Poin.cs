using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DiBa_Lib
{
    class Poin
    {
        #region data members
        int idPoin;
        int saldoPoin;
        Pengguna nik;
        #endregion

        #region constructors
        public Poin(int idPoin, int saldoPoin, Pengguna nik)
        {
            IdPoin = IdPoin;
            SaldoPoin = saldoPoin;
            Nik = nik;
        }
        public Poin()
        {
            this.IdPoin = 0;
            this.SaldoPoin = 0;
            this.Nik = null;
        }
        #endregion

        #region properties
        public int IdPoin { get => idPoin; set => idPoin = value; }
        public int SaldoPoin { get => saldoPoin; set => saldoPoin = value; }
        public Pengguna Nik { get => nik; set => nik = value; }
        #endregion

        #region methods
        //public static List<Pangkat> BacaData(string kriteria, string nilaiKriteria)
        //{
        //    string sql = "SELECT kode_pangkat, jenis_pangkat " + " FROM pangkat";
        //    if (kriteria == "")
        //    {
        //        sql += ";";
        //    }
        //    else
        //    {
        //        sql += " WHERE " + kriteria + " LIKE '%" + nilaiKriteria + "%';";
        //    }
        //    MySqlDataReader hasil = Koneksi.ambilData(sql);
        //    List<Pangkat> listHasil = new List<Pangkat>();
        //    while (hasil.Read())
        //    {
        //        Pangkat tmp = new Pangkat(hasil.GetValue(0).ToString(), hasil.GetValue(1).ToString());
        //        listHasil.Add(tmp);
        //    }
        //    return listHasil;
        //}
        public override string ToString()
        {   
            return this.SaldoPoin.ToString();
        }
        #endregion
    }
}
