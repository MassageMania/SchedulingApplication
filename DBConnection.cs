using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Data;

namespace Scheduling_Appointment
{
    public class DBconnection
    {
        public static string connectionString = "Server=localhost;Port=3306;Username=sqlUser;Password=Passw0rd!;Database=client_schedule";

        public static MySqlConnection conn { get; set; }

        public static void startConnection()
        {
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["localdb"].ConnectionString;
                conn = new MySqlConnection(constr);
                conn.Open();
                MessageBox.Show("You may proceeed");
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void closeConnection()
        {
            try
            {
                if (conn != null)
                {
                    conn.Close();
                }
                conn = null;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private static string userName;
        private static int userId;

        public static int GetUserID()
        {
            return userId;
        }

        public static string GetUserName()
        {
            return userName;
        }

        public static void SetUserId (int currentUserId)
        {
            userId = currentUserId;
        }

        public static void SetUserName(string currentUserName)
        {
            userName = currentUserName;
        }
       
        public DataTable TableReader(string s, DataTable dataTable)
        {
            using (MySqlConnection connect = new MySqlConnection(connectionString))
            {
                connect.Open();
                MySqlCommand command = new MySqlCommand(s, connect);
                MySqlDataReader reader = command.ExecuteReader();
                dataTable.Load(reader);
                connect.Close();
                return dataTable;
            }
        }
    }
}