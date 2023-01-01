using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DiBa_Lib
{
    public class Bunga
    {
        #region data members
        private int idBunga;
        private string jatuhTempo;
        private string nominal;
        private int persenBunga;
        #endregion

        #region constructors
        public Bunga(int idBunga, string jatuhTempo, string nominal, int persenBunga)
        {
            this.IdBunga = idBunga;
            this.JatuhTempo = jatuhTempo;
            this.Nominal = nominal;
            this.PersenBunga = persenBunga;
        }

        public Bunga()
        {
            this.IdBunga = 0;
            this.JatuhTempo = "";
            this.Nominal = "";
            this.PersenBunga = 0;
        }
        #endregion

        #region properties
        public int IdBunga { get => idBunga; set => idBunga = value; }
        public string JatuhTempo { get => jatuhTempo; set => jatuhTempo = value; }
        public string Nominal { get => nominal; set => nominal = value; }
        public int PersenBunga { get => persenBunga; set => persenBunga = value; }
        #endregion

        #region methods
        public static List<Bunga> BacaBunga(string kriteria1, string nilaiKriteria1, string kriteria2, string nilaiKriteria2)
        {
            string sql = "SELECT idbunga, jatuhtempo, nominal, persenBunga " + " FROM bunga " +
                         "WHERE " + kriteria1 + " = '" + nilaiKriteria1 + "' && " 
                                  + kriteria2 + " = '" + nilaiKriteria2 + "'; ";
            MySqlDataReader hasil = Koneksi.ambilData(sql);
            List<Bunga> listHasil = new List<Bunga>();
            while (hasil.Read())
            {
                Bunga tmp = new Bunga();
                tmp.IdBunga = hasil.GetInt32(0);
                tmp.JatuhTempo = hasil.GetValue(1).ToString();
                tmp.Nominal = hasil.GetValue(2).ToString();
                tmp.PersenBunga = hasil.GetInt32(3);
                listHasil.Add(tmp);
            }
            return listHasil;
        }
        public static List<Bunga> BacaData(string kriteria, string nilaiKriteria)
        {
            string sql = "SELECT idbunga, jatuhtempo, nominal, persenBunga " + " FROM bunga";
            if (kriteria == "")
            {
                sql += ";";
            }
            else
            {
                sql += " WHERE " + kriteria + " LIKE '%" + nilaiKriteria + "%';";
            }
            MySqlDataReader hasil = Koneksi.ambilData(sql);
            List<Bunga> listHasil = new List<Bunga>();
            while (hasil.Read())
            {
                Bunga tmp = new Bunga();
                tmp.IdBunga = hasil.GetInt32(0);
                tmp.JatuhTempo = hasil.GetValue(1).ToString();
                tmp.Nominal = hasil.GetValue(2).ToString();
                tmp.PersenBunga = hasil.GetInt32(3);
                listHasil.Add(tmp);
            }
            return listHasil;
        }

        public static Bunga bungaByCode(int id)
        {
            string sql = "SELECT idbunga, jatuhtempo, nominal, persenbunga " + " FROM bunga " +
                         "WHERE idbunga = " + id;
            MySqlDataReader hasil = Koneksi.ambilData(sql);
            Bunga tmp = new Bunga();
            if (hasil.Read() == true)
            {
                tmp = new Bunga();
                tmp.IdBunga = hasil.GetInt32("idbunga");
                tmp.JatuhTempo = hasil.GetString("jatuhtempo");
                tmp.Nominal = hasil.GetString("nominal");
                tmp.PersenBunga = hasil.GetInt32("persenbunga");
                return tmp;
            }
            else
            {
                return null;
            }
        }

        public bool TambahData()
        {
            string sql = "INSERT INTO bunga(jatuhtempo, nominal, persenbunga)" + 
                         " VALUES ('" + this.JatuhTempo + "', '"
                                      + this.Nominal + "', '" 
                                      + this.PersenBunga + "');";
            bool result = Koneksi.executeDML(sql);
            return result;
        }

        public bool UbahData()
        {
            string sql = "UPDATE bunga SET jatuhtempo = '" + this.JatuhTempo + "', " +
                         " nominal = '" + this.Nominal + "', " +
                         " persenbunga = '" + this.PersenBunga + "', " +
                         " WHERE idbunga =" + this.IdBunga + ";";
            bool result = Koneksi.executeDML(sql);
            return result;
        }

        public bool HapusData()
        {
            string sql = "DELETE FROM bunga " +
                         " WHERE idbunga = '" + this.IdBunga + "';";
            bool result = Koneksi.executeDML(sql);
            return result;
        }

        public override string ToString()
        {
            return IdBunga.ToString();
        }
        #endregion
    }
}
