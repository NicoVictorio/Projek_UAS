using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiBa_Lib
{
    public class Inbox
    {
        #region data members
        private int idPesan;
        private Pengguna pengguna;
        private string pesan;
        private DateTime tglKirim;
        private string status;
        private DateTime tglPerubahan;
        #endregion

        #region constructors
        public Inbox()
        {
            this.idPesan = 0;
            this.pengguna = null;
            this.pesan = "";
            this.tglKirim = DateTime.Now;
            this.status = "";
            this.tglPerubahan = DateTime.Now;
        }

        public Inbox(int idPesan, Pengguna pengguna, string pesan, DateTime tglKirim, string status, DateTime tglPerubahan)
        {
            this.idPesan = idPesan;
            this.pengguna = pengguna;
            this.pesan = pesan;
            this.tglKirim = tglKirim;
            this.status = status;
            this.tglPerubahan = tglPerubahan;
        }
        #endregion

        #region properties
        public int IdPesan { get => idPesan; set => idPesan = value; }
        public Pengguna Pengguna { get => pengguna; set => pengguna = value; }
        public string Pesan { get => pesan; set => pesan = value; }
        public DateTime TglKirim { get => tglKirim; set => tglKirim = value; }
        public string Status { get => status; set => status = value; }
        public DateTime TglPerubahan { get => tglPerubahan; set => tglPerubahan = value; }
        #endregion

        #region methods
        public static List<Inbox> BacaData(string kriteria, string nilaiKriteria)
        {
            string sql = "SELECT id_pesan, pengguna_id, pesan, tanggal_kirim, status, tgl_perubahan  " +
                         "FROM inbox ";
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
            List<Inbox> listInbox = new List<Inbox>();
            while (hasil.Read() == true)
            {
                Inbox inb = new Inbox();
                inb.IdPesan = hasil.GetInt32(0);
                inb.Pesan = hasil.GetString(2);
                inb.TglKirim = DateTime.Parse(hasil.GetString(3));
                inb.Status = hasil.GetString(4);
                inb.TglPerubahan = DateTime.Parse(hasil.GetString(5));

                Pengguna tmpPengguna = new Pengguna();
                tmpPengguna.Id = hasil.GetInt32(1);
                inb.Pengguna = tmpPengguna;

                listInbox.Add(inb);
            }
            return listInbox;
        }

        public static List<Inbox> DaftarPesan(int idPengguna, string kriteria, string nilaiKriteria)
        {
            string sql = "SELECT id_pesan, pengguna_id, pesan, tanggal_kirim, status, tgl_perubahan  " +
                         "FROM inbox WHERE pengguna_id = "+ idPengguna;

            if (kriteria == "")
            {
                sql += ";";
            }
            else
            {
                sql += " AND " + kriteria + " LIKE '%" + nilaiKriteria + "%';";
            }

            MySqlDataReader result = Koneksi.ambilData(sql);

            List<Inbox> listInbox = new List<Inbox>();

            while (result.Read())
            {
                Inbox inb = new Inbox();
                inb.IdPesan = result.GetInt32(0);
                inb.Pesan = result.GetString(2);
                inb.TglKirim = DateTime.Parse(result.GetString(3));
                inb.Status = result.GetString(4);
                inb.TglPerubahan = DateTime.Parse(result.GetString(5));

                Pengguna tmpPengguna = new Pengguna();
                tmpPengguna.Id = result.GetInt32(1);
                inb.Pengguna = tmpPengguna;

                listInbox.Add(inb);
            }
            return listInbox;
        }

        public bool TambahData()
        {
            string sql = "INSERT INTO inbox(pengguna_id, pesan, tanggal_kirim,status, tgl_perubahan)" +
                " VALUES ("+ this.Pengguna.Id + ",'"+ this.Pesan + "', '" +
                this.TglKirim.ToString("yyyy-MM-dd") + "', '" + this.Status + "', '"+ 
                this.TglPerubahan.ToString("yyyy-MM-dd")+ "');";
            bool result = Koneksi.executeDML(sql);
            return result;
        }
        public bool TambahData(Koneksi k)
        {
            string sql = "INSERT INTO inbox(pengguna_id, pesan, tanggal_kirim,status, tgl_perubahan)" +
                " VALUES (" + this.Pengguna.Id + ",'" + this.Pesan + "', '" +
                this.TglKirim.ToString("yyyy-MM-dd") + "', '" + this.Status + "', '" +
                this.TglPerubahan.ToString("yyyy-MM-dd") + "');";
            bool result = Koneksi.executeDML(sql,k);
            return result;
        }

        public bool UbahData()
        {
            string sql = "UPDATE inbox SET pesan = '" + this.Pesan + "' where id_pesan = " + this.IdPesan + ";";
            bool result = Koneksi.executeDML(sql);
            return result;
        }

        public bool HapusData()
        {
            string sql = "DELETE from inbox where id_pesan = " + this.idPesan + ";";
            bool result = Koneksi.executeDML(sql);
            return result;
        }

        public static Inbox inboxByCode(int id)
        {
            string sql = "SELECT id_pesan,pengguna_id, pesan, tanggal_kirim, status, tgl_perubahan  " +
                         "FROM inbox WHERE id_pesan=" + id;
            MySqlDataReader hasil = Koneksi.ambilData(sql);
            if (hasil.Read() == true)
            {
                Inbox emp = new Inbox();
                emp.IdPesan = hasil.GetInt32(0);
                emp.Pesan = hasil.GetString(2);
                emp.TglKirim = DateTime.Parse(hasil.GetString(3));
                emp.Status = hasil.GetString(4);
                emp.TglPerubahan = DateTime.Parse(hasil.GetString(5));

                Pengguna tmpPengguna = new Pengguna();
                tmpPengguna.Id = hasil.GetInt32(1);
                emp.Pengguna = tmpPengguna; ;
                return emp;
            }
            else
            {
                return null;
            }
        }

        public bool UbahStatus()
        {
            string sql = "UPDATE inbox SET status ='Terbuka' where pengguna_id=" + this.Pengguna.Id + " and id_pesan="+ this.IdPesan+ ";";
            bool result = Koneksi.executeDML(sql);
            return result;
        }
        #endregion
    }
}