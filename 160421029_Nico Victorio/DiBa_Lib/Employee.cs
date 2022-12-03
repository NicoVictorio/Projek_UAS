using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DiBa_Lib
{
    public class Employee
    {
        #region data members
        private int id;
        private string namaDepan;
        private string namaKeluarga;
        private Position position;
        private string nik;
        private string email;
        private string password;
        private DateTime tglBuat;
        private DateTime tglPerubahan;
        #endregion

        #region constructors
        public Employee()
        {
            this.Id = 0;
            this.NamaDepan = "";
            this.NamaKeluarga = "";
            this.Position = null;
            this.Nik = "";
            this.Email = "";
            this.Password = "";
            this.TglBuat = DateTime.Now;
            this.TglPerubahan = DateTime.Now;
        }

        public Employee(int id, string namaDepan, string namaKeluarga, Position position, string nik, string email, string password, DateTime tglBuat, DateTime tglPerubahan)
        {
            this.Id = id;
            this.NamaDepan = namaDepan;
            this.NamaKeluarga = namaKeluarga;
            this.Position = position;
            this.Nik = nik;
            this.Email = email;
            this.Password = password;
            this.TglBuat = tglBuat;
            this.TglPerubahan = tglPerubahan;
        }
        #endregion

        #region properties
        public int Id { get => id; set => id = value; }
        public string NamaDepan { get => namaDepan; set => namaDepan = value; }
        public string NamaKeluarga { get => namaKeluarga; set => namaKeluarga = value; }
        public Position Position { get => position; set => position = value; }
        public string Nik { get => nik; set => nik = value; }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
        public DateTime TglBuat { get => tglBuat; set => tglBuat = value; }
        public DateTime TglPerubahan { get => tglPerubahan; set => tglPerubahan = value; }
        #endregion

        #region methods
        public static List<Employee> BacaData(string kriteria, string nilaiKriteria)
        {
            string sql = "SELECT e.id, e.nama_depan, e.nama_keluarga, e.position_id, e.nik, " +
                         "e.email, e.password, e.tgl_buat, e.tgl_perubahan, p.nama " +
                         "FROM employee e \nINNER JOIN position p on p.id = e.position_id ";
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
            List<Employee> listEmployee = new List<Employee>();
            while (hasil.Read() == true)
            {
                Employee emp = new Employee();
                emp.Id = hasil.GetInt32(0);
                emp.NamaDepan = hasil.GetString(1);
                emp.NamaKeluarga = hasil.GetString(2);
                emp.Nik = hasil.GetString(4);
                emp.Email = hasil.GetString(5);
                emp.Password = hasil.GetString(6);
                emp.TglBuat = DateTime.Parse(hasil.GetString(7));
                emp.tglPerubahan = DateTime.Parse(hasil.GetString(8));
                
                Position pos = new Position();
                pos.IdPosition = hasil.GetInt32(3);
                pos.NamaPosition = hasil.GetString(9);
                emp.Position = pos;
                listEmployee.Add(emp);
            }
            return listEmployee;
        }

        public bool TambahData()
        {
            string sql = "INSERT INTO employee(nama_depan, nama_keluarga, position_id, " +
                         "nik, email, password, tgl_buat, tgl_perubahan)" +
                         " VALUES ('" + this.NamaDepan + "', '" + this.NamaKeluarga  + "', " + 
                         this.Position.IdPosition + ", '" + this.Nik + "', '" + 
                         this.Email + "', '" + this.Password + "', '" + 
                         this.TglBuat.ToString("yyyy-MM-dd") + "', '" +
                         this.TglPerubahan.ToString("yyyy-MM-dd") + "') ;" ;
            bool result = Koneksi.executeDML(sql);
            return result;
        }

        public bool UbahData()
        {
            string sql = "UPDATE employee SET nama_depan ='" + this.NamaDepan + 
                         "', nama_keluarga = '" + this.NamaKeluarga + 
                         "', position_id = " + this.Position.IdPosition + 
                         ", nik = '" + this.Nik + "', email = '" + this.Email +
                         "', password = '" + this.Password + 
                         "', tgl_perubahan = '" + DateTime.Now.ToString("yyyy-MM-dd") + "'" +
                         "\nWHERE id = "+ this.Id + ";";
            bool result = Koneksi.executeDML(sql);
            return result;
        }

        public bool HapusData()
        {
            string sql = "DELETE from employee where id = '" + this.Id + "';";
            bool result = Koneksi.executeDML(sql);
            return result;
        }

        public static Employee employeeByCode(int id)
        {
            string sql = "SELECT e.id, e.nama_depan, e.nama_keluarga, e.position_id, e.nik, " +
                         "e.email, e.password, e.tgl_buat, e.tgl_perubahan, p.nama " +
                         "\nFROM employee e \nINNER JOIN position p on p.id = e.position_id " +
                         "\nWHERE e.id = " + id + ";";
            MySqlDataReader hasil = Koneksi.ambilData(sql);
            if (hasil.Read() == true)
            {
                Employee emp = new Employee();
                emp.Id = hasil.GetInt32(0);
                emp.NamaDepan = hasil.GetString(1);
                emp.NamaKeluarga = hasil.GetString(2);
                emp.Nik = hasil.GetString(4);
                emp.Email = hasil.GetString(5);
                emp.Password = hasil.GetString(6);
                emp.TglBuat = DateTime.Parse(hasil.GetString(7));
                emp.tglPerubahan = DateTime.Parse(hasil.GetString(8));

                Position pos = new Position();
                pos.IdPosition = hasil.GetInt32(3);
                pos.NamaPosition = hasil.GetString(9);
                emp.Position = pos;
                return emp;
            }
            else
            {
                return null;
            }
        }
        public static Employee Login(string username, string password)
        {
            string sql = "";


            if (username == "" || password == "")
            {
                throw new Exception("Email atau password tidak boleh kosong");
            }
            else
            {

                //sql = "select * from pengguna where (email='" + username + "' or no_telepon='" + username + "') and password='" + password + "';";
                sql = "select e.id, e.nama_depan,e.nama_keluarga, e.position_id, e.nik, e.email, e.password, e.tgl_buat, e.tgl_perubahan, ps.nama, ps.keterangan  from employee as e inner join position as ps on ps.id = e.position_id "
                + "WHERE e.email = '" + username + "' and e.password = '" + password + "';";
            }

            MySqlDataReader hasil = Koneksi.ambilData(sql);
            Employee p;
            //buat list untk menampung data 
            //List<Pengguna> listPengguna = new List<Pengguna>();
            if (hasil.Read() == true)
            {
                Position pg = new Position(hasil.GetInt32(3), hasil.GetValue(9).ToString(), hasil.GetString(10));

                p = new Employee(hasil.GetInt32(0), hasil.GetString(1), hasil.GetString(2),
                    pg, hasil.GetString(4), hasil.GetString(5), hasil.GetString(6), DateTime.Parse(hasil.GetString(7)),
                    DateTime.Parse(hasil.GetValue(8).ToString()));
                return p;
            }
            return null;
        }

        #endregion
    }
}
