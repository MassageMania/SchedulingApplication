using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchedulingApplication
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void btnConnection_Click(object sender, EventArgs e)
        {
            //Get connected
            string constr = ConfigurationManager.ConnectionStrings["LocalDB"].ConnectionString;
            //Make Connection
            MySqlConnection conn = null;
            //Open
            try
            {
                conn = new MySqlConnection(constr);
                conn.Open();
                MessageBox.Show("The Connection has been made.");
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //Close
                if (conn != null)
                { conn.Close(); }
            }
        }
    }
}
