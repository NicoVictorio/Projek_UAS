using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DiBa_Lib
{
    public class Position
    {
        #region data members
        private int idPosition;
        private string namaPosition;
        private string keterangan; 
        #endregion

        #region constructors
        public Position()
        {
            idPosition = 0;
            namaPosition = "";
            keterangan = "";
        }

        public Position(int idPosition, string namaPosition, string keterangan)
        {
            this.IdPosition = idPosition;
            this.NamaPosition = namaPosition;
            this.Keterangan = keterangan;
        }
        #endregion

        #region properties
        public int IdPosition { get => idPosition; set => idPosition = value; }
        public string NamaPosition { get => namaPosition; set => namaPosition = value; }
        public string Keterangan { get => keterangan; set => keterangan = value; }
        #endregion

        #region methods
        public static List<Position> BacaData(string kriteria, string nilaiKriteria)
        {
            string sql = "SELECT id, nama, keterangan " + " FROM position";
            if (kriteria == "")
            {
                sql += ";";
            }
            else
            {
                sql += " WHERE " + kriteria + " LIKE '%" + nilaiKriteria + "%';";
            }
            MySqlDataReader hasil = Koneksi.ambilData(sql);
            List<Position> listHasil = new List<Position>();
            while (hasil.Read())
            {
                Position tmp = new Position();
                tmp.IdPosition = hasil.GetInt32(0);
                tmp.NamaPosition = hasil.GetValue(1).ToString();
                tmp.Keterangan = hasil.GetValue(2).ToString();
                listHasil.Add(tmp);
            }
            return listHasil;
        }

        public static Position positionByCode(int id)
        {
            string sql = "SELECT id, nama, keterangan " + " FROM position " + " WHERE id=" + id ;
            MySqlDataReader hasil = Koneksi.ambilData(sql);
            Position tmp = new Position();
            if (hasil.Read() == true)
            {
                tmp = new Position();
                tmp.IdPosition = hasil.GetInt32("id");
                tmp.NamaPosition = hasil.GetString("nama");
                tmp.Keterangan = hasil.GetString("keterangan");
                return tmp;
            }
            else
            {
                return null;
            }
        }

        public bool TambahData()
        {
            //string sql = "INSERT INTO position( nama, keterangan)" + " VALUES ('" + this.NamaPosition + "', '" + this.Keterangan + "');";
            string sql = "INSERT INTO `position`(`nama`, `keterangan`) VALUES('" + this.NamaPosition + "', '" + this.Keterangan + "');";
            bool result = Koneksi.executeDML(sql);
            return result;
        }

        public bool UbahData()
        {
            string sql = "UPDATE position SET nama = '" + this.NamaPosition.Replace("'", "\\'") +
                         "', keterangan = '" + this.Keterangan.Replace("'", "\\'") +
                         "' WHERE id = " + this.IdPosition + ";";
            bool result = Koneksi.executeDML(sql);
            return result;
        }

        public bool HapusData()
        {
            string sql = "DELETE FROM position " +
                         " WHERE id = " + this.IdPosition + ";";
            bool result = Koneksi.executeDML(sql);
            return result;
        }

        public override string ToString()
        {
            return NamaPosition;
        }
        #endregion
    }
}