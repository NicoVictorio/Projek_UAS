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
        private string email;
        private string namaDepan;
        private string namaKeluarga;
        private Position position;
        private string nik;
        private string password;
        private DateTime tglBuat;
        private DateTime tglPerubahan;
        #endregion

        #region constructors
        public Employee()
        {
            this.Email = "";
            this.NamaDepan = "";
            this.NamaKeluarga = "";
            this.Position = null;
            this.Nik = "";
            this.Password = "";
            this.TglBuat = DateTime.Now;
            this.TglPerubahan = DateTime.Now;
        }

        public Employee(string email, string namaDepan, string namaKeluarga, Position position, string nik, string password, DateTime tglBuat, DateTime tglPerubahan)
        {
            this.Email = email;
            this.NamaDepan = namaDepan;
            this.NamaKeluarga = namaKeluarga;
            this.Position = position;
            this.Nik = nik;
            this.Password = password;
            this.TglBuat = tglBuat;
            this.TglPerubahan = tglPerubahan;
        }
        #endregion

        #region properties
        public string Email { get => email; set => email = value; }
        public string NamaDepan { get => namaDepan; set => namaDepan = value; }
        public string NamaKeluarga { get => namaKeluarga; set => namaKeluarga = value; }
        public Position Position { get => position; set => position = value; }
        public string Nik { get => nik; set => nik = value; }
        public string Password { get => password; set => password = value; }
        public DateTime TglBuat { get => tglBuat; set => tglBuat = value; }
        public DateTime TglPerubahan { get => tglPerubahan; set => tglPerubahan = value; }
        #endregion

        #region methods
        public static List<Employee> BacaData(string kriteria, string nilaiKriteria)
        {
            string sql = "SELECT e.email, e.nama_depan, e.nama_keluarga, e.position_id, e.nik, " +
                         "e.password, e.tgl_buat, e.tgl_perubahan, p.nama " +
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
                emp.Email = hasil.GetString(0);
                emp.NamaDepan = hasil.GetString(1);
                emp.NamaKeluarga = hasil.GetString(2);
                emp.Nik = hasil.GetString(4);
                emp.Password = hasil.GetString(5);
                emp.TglBuat = DateTime.Parse(hasil.GetString(6));
                emp.tglPerubahan = DateTime.Parse(hasil.GetString(7));
                
                Position pos = new Position();
                pos.IdPosition = hasil.GetInt32(3);
                pos.NamaPosition = hasil.GetString(8);
                emp.Position = pos;
                listEmployee.Add(emp);
            }
            return listEmployee;
        }

        public bool TambahData()
        {
            string sql = "INSERT INTO employee(email, nama_depan, nama_keluarga, position_id, " +
                         "nik, password, tgl_buat, tgl_perubahan)" +
                         " VALUES ('" + this.Email + "', '" + this.NamaDepan + "', '" + 
                                        this.NamaKeluarga  + "', " + 
                                        this.Position.IdPosition + ", '" + this.Nik + "', '" + 
                                        this.Password + "', '" + 
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
                         ", nik = '" + this.Nik + "', password = '" + this.Password + 
                         "', tgl_perubahan = '" + DateTime.Now.ToString("yyyy-MM-dd") + "'" +
                         "\nWHERE email = "+ this.Email + ";";
            bool result = Koneksi.executeDML(sql);
            return result;
        }

        public bool HapusData()
        {
            string sql = "DELETE from employee where email = '" + this.Email + "';";
            bool result = Koneksi.executeDML(sql);
            return result;
        }

        public static Employee employeeByCode(string email)
        {
            string sql = "SELECT e.email, e.nama_depan, e.nama_keluarga, e.position_id, e.nik, " +
                         "e.password, e.tgl_buat, e.tgl_perubahan, p.nama " +
                         "\nFROM employee e \nINNER JOIN position p on p.id = e.position_id " +
                         "\nWHERE e.email = '" + email + "';";
            MySqlDataReader hasil = Koneksi.ambilData(sql);
            if (hasil.Read() == true)
            {
                Employee emp = new Employee();
                emp.Email = hasil.GetString(0);
                emp.NamaDepan = hasil.GetString(1);
                emp.NamaKeluarga = hasil.GetString(2);
                emp.Nik = hasil.GetString(4);
                emp.Password = hasil.GetString(5);
                emp.TglBuat = DateTime.Parse(hasil.GetString(6));
                emp.tglPerubahan = DateTime.Parse(hasil.GetString(7));

                Position pos = new Position();
                pos.IdPosition = hasil.GetInt32(3);
                pos.NamaPosition = hasil.GetString(8);
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
                sql = "select e.email, e.nama_depan, e.nama_keluarga, e.position_id, e.nik, e.password, e.tgl_buat, e.tgl_perubahan, " +
                      "ps.nama, ps.keterangan from employee e inner join position as ps on ps.id = e.position_id "
                       + " WHERE e.email = '" + username + "' and e.password = '" + password + "';";
            }

            MySqlDataReader hasil = Koneksi.ambilData(sql);
            Employee p;

            if (hasil.Read() == true)
            {
                Position pg = new Position(hasil.GetInt32(3), hasil.GetValue(8).ToString(), hasil.GetString(9));

                p = new Employee(hasil.GetString(0), hasil.GetString(1), hasil.GetString(2),
                    pg, hasil.GetString(4), hasil.GetString(5), DateTime.Parse(hasil.GetString(6)),
                    DateTime.Parse(hasil.GetValue(7).ToString()));
                return p;
            }
            return null;
        }

        public override string ToString()
        {
            return email;
        }
        #endregion
    }
}