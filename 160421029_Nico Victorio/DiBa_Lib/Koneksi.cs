using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace DiBa_Lib
{
    public class Koneksi
    {
        #region data members
        private MySqlConnection connection;
        #endregion

        #region constructors
        public Koneksi()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            ConfigurationSectionGroup confGroup = config.SectionGroups["userSettings"];
            var confSection = confGroup.Sections["_160421029_Nico_Victorio.dbSetting"] as ClientSettingsSection;
            string hostname = confSection.Settings.Get("hostname").Value.ValueXml.InnerText;
            string dbname = confSection.Settings.Get("dbname").Value.ValueXml.InnerText;
            string uid = confSection.Settings.Get("uid").Value.ValueXml.InnerText;
            string password = confSection.Settings.Get("password").Value.ValueXml.InnerText;

            String strConnection = "server=" + hostname + ";database=" + dbname + ";uid=" + uid +
                                   ";password=" + password + ";sslmode=none;Convert Zero Datetime=True";
            connection = new MySqlConnection();
            connection.ConnectionString = strConnection;

            Connect();
        }

        public Koneksi(string hostName, string dbName, string username, string password)
        {
            String strConnection = "server=" + hostName + ";database=" + dbName +
                                   ";uid=" + username + ";password=" + password + ";sslmode=none;Convert Zero Datetime=True";
            connection = new MySqlConnection();
            connection.ConnectionString = strConnection;

            Connect();
        }
        #endregion

        #region properties
        public MySqlConnection Connection { get => connection; set => connection = value; }
        #endregion

        #region methods
        public void Connect()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        public void Disconnect()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }

        public static MySqlDataReader ambilData(string sql)
        {
            MySqlDataReader result = null;
            Koneksi conn = new Koneksi();
            MySqlCommand comm = new MySqlCommand(sql, conn.connection);
            result = comm.ExecuteReader();
            return result;
        }

        public static bool executeDML(string sql)
        {
            Koneksi conn = new Koneksi();
            MySqlCommand comm = new MySqlCommand(sql, conn.connection);
            int result = comm.ExecuteNonQuery();
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool executeDML(string sql, Koneksi k)
        {
            //Koneksi k = new Koneksi();
            MySqlCommand c = new MySqlCommand(sql, k.connection);
            int result = c.ExecuteNonQuery();
            if (result > 0)
                return true;
            else
                return false;
        }
        #endregion
    }
}