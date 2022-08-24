using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchedulingApplication
{
    public class DBConnection
    {
        public static MySqlConnection conn { get; set; }

        public static void startConnection()
        {
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["LocalDB"].ConnectionString;
                conn = new MySqlConnection(constr);
                //Open connection
                conn.Open();

                MessageBox.Show("Connection is open");
            }
            catch(MySqlException ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void closeConnection()
        {
            try
            {
                //Close Connection
                if (conn != null)
                {
                    conn.Close();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            conn = null;
        }
    }
}
