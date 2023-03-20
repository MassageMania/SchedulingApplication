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
        public static string connectionString = "Server=localhost;Port=3306;Username=sqlUser;Password=Password!;Database=client_schedule";

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
       

        public static void getAppointments()
        {
            string query = @"Select * FROM appointment";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                int appointmentId = Convert.ToInt32(dataReader[0]);
                int customerId = Convert.ToInt32(dataReader[1]);
                int userId = Convert.ToInt32(dataReader[2]);
                string type = dataReader[7].ToString();
                DateTime start = Convert.ToDateTime(dataReader[9]).ToLocalTime();
                DateTime end = Convert.ToDateTime(dataReader[10]).ToLocalTime();
                DateTime createDate = Convert.ToDateTime(dataReader[11]).ToLocalTime();
                string createdBy = dataReader[12].ToString();
                DateTime lastUpdate = Convert.ToDateTime(dataReader[13]).ToLocalTime();
                string lastUpdatedBy = dataReader[14].ToString();

            }
            dataReader.Close();
        }
        //Todo write as bool 
        public static int overlapAppointment(DateTime start, DateTime end)
        {
            //var startDateTime = ;
            //var endDateTime = ;
            var query = @"SELECT count(*) FROM appointment 
                        WHERE (('@startDateTime' > start 
                        AND '@startDateTime' < end) 
                        OR ('@endDateTime'> start 
                        AND ''@endDateTime' < end)) 
                        AND end > now() order by start limit 1;";

            MySqlCommand command = new MySqlCommand(query, conn);
            MySqlDataReader dataReader = command.ExecuteReader();

            if (dataReader.HasRows)
            {
                dataReader.Read();
                string count = dataReader[0].ToString();
                int result = count == "0" ? 0 : 1;
                return result;
            }
            dataReader.Close();
            return 0;
        }



        public static void addAppointment(int customerId, string location, string type, DateTime start, DateTime end)
        {
            DateTime now = DateTime.Now;
            string query = @"INSERT INTO appointment VALUES(NULL, @customerId, @userId, 
                            @location, 'not needed', 'not needed', 'not needed', @type, 'not needed',
                            @start, @end, Now(), 'user', Now(), 'user')";



            MySqlCommand cmd = new MySqlCommand(query, conn);

            cmd.Parameters.AddWithValue("customerId", customerId);
            cmd.Parameters.AddWithValue("userId", DBconnection.GetUserName());
            cmd.Parameters.AddWithValue("location", location);
            cmd.Parameters.AddWithValue("type", type);
            cmd.Parameters.AddWithValue("start", start);
            cmd.Parameters.AddWithValue("end", end);
            cmd.Parameters.AddWithValue("user", DBconnection.GetUserName());
            cmd.Parameters.AddWithValue("user", DBconnection.GetUserName());

            cmd.ExecuteNonQuery();

        }

        public static void deleteAppointment(Appointment appointment)
        {
            string query = $"DELETE FROM appointment WHERE appointmentId={appointment.AppointmentId};";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.ExecuteNonQuery();
        }

          public static void getCustomer()
        {
            string query = "SELECT * FROM customer";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                int customerId = Convert.ToInt32(dataReader[0]);
                string customerName = dataReader[1].ToString();
                int addressId = Convert.ToInt32(dataReader[2]);
                byte active = (byte)Convert.ToInt32(dataReader[3]);
                DateTime createDate = Convert.ToDateTime(dataReader[4]).ToLocalTime();
                string createdBy = dataReader[5].ToString();
                DateTime lastUpdated = Convert.ToDateTime(dataReader[6]).ToLocalTime();
                string lastUpdatedBy = dataReader[7].ToString();

            }dataReader.Close();
        }

        public static int addCustomer(int customerId, string customerName, int addressId, string user)
        {
            DateTime now = DateTime.Now;
           
            string query = @"INSERT INTO customer VALUES(NULL, @customerId, @customerName, 
                            @addressId, @active, Now(), @user, Now(), @user";



            MySqlCommand cmd = new MySqlCommand(query, conn);

            cmd.Parameters.AddWithValue("customerId", customerId);
            cmd.Parameters.AddWithValue("customerName", customerName);
            cmd.Parameters.AddWithValue("addressId", addressId);
            cmd.Parameters.AddWithValue("active", 1);
            cmd.Parameters.AddWithValue("user", DBconnection.GetUserName());
            cmd.Parameters.AddWithValue("user", DBconnection.GetUserName());

            //Todo Fix return type
            return 0;
        }

        public static void deleteCustomer(Customer customer)
        {
            string query = $"DELETE FROM customer WHERE customerId={customer.CustomerId};";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            deleteAddress(customer.AddressId);
        }

        public static void updateCustomer(Customer customer, string customerName, string user)
        {
            DateTime now = DateTime.Now;
            string nowString = now.ToUniversalTime().ToString("yy-MM-dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo);
            string query = $"UPDATE customer SET customerName='{customerName}', lastUpdate = '{nowString}', lastUpdatedBy = '{user}' WHERE customerId = {customer.CustomerId};";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.ExecuteNonQuery();

            //DateTime dateToUpdate = DateTime.Now;
            //string sqlFormattedDate = dateToUpdate.ToString("yyyy-MM-dd HH:mm:ss.fff");
            //string update = $"UPDATE customer AS c " +
            //    $"INNER JOIN address  AS a " +
            //    $"ON c.addressId = c.addressId " +
            //    $"SET c.customerName = '{customerName}', " +
            //    $"c.lastUpdate = '{sqlFormattedDate}', " +
            //    $"a.address = '{address}', " +
            //    $"a.phone = '{phoneNumber}', " +
            //    $"a.postalCode = '{postalCode}', " +
            //    $"a.cityId = '{cityId}' " +
            //    $"WHERE c.customerId = '{customerId}' " +
            //    $"AND a.addressId = '{addressId}'";

            Customer updateCustomer = new Customer(customer.CustomerId, customerName, customer.AddressId, customer.Active, customer.CreateDate, customer.CreatedBy, now, user);
  
        }

        public static int AddAddress(string address1, string address2, int cityId, string postalCode, string phone, DateTime createDate, string createdBy, DateTime lastUpdate, string lastUpdateBy)
        {
            DateTime now = DateTime.Now;
           
            string query = @"INSERT INTO address VALUES(NULL, @address1, @address2, 
                            @cityId, @postalCode, @phone, Now(), @user, Now(), @user";



            MySqlCommand cmd = new MySqlCommand(query, conn);

            cmd.Parameters.AddWithValue("address1", address1);
            cmd.Parameters.AddWithValue("address2", address2);
            cmd.Parameters.AddWithValue("cityId", cityId);
            cmd.Parameters.AddWithValue("postalCode", postalCode);
            cmd.Parameters.AddWithValue("phone", phone);
            cmd.Parameters.AddWithValue("user", DBconnection.GetUserName());
            cmd.Parameters.AddWithValue("user", DBconnection.GetUserName());

            cmd.ExecuteNonQuery();

            //Todo fix return type
            return 0;
        }

        public static void getAddress()
        {
            string query = "SELECT * FROM Address";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                int addressId = Convert.ToInt32(dataReader[0]);
                string address = dataReader[1].ToString();
                string address2 = dataReader[2].ToString();
                int cityId = Convert.ToInt32(dataReader[3]);
                string postalCode = dataReader[4].ToString();
                string phone = dataReader[5].ToString();
                DateTime createDate = Convert.ToDateTime(dataReader[6]).ToLocalTime();
                string createdBy = dataReader[7].ToString();
                DateTime lastUpdate = Convert.ToDateTime(dataReader[8]).ToLocalTime();
                string lastUpdatedBy = dataReader[9].ToString();

            }
            dataReader.Close();
        }

       

        public static void deleteAddress(int addressId)
        {
            string query = $"DELETE FROM address WHERE addressId = {addressId};";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.ExecuteNonQuery();
        }

        public static void upDateAddress(Address address, string address1, string address2, int cityId, string postalCode, string phone, string user)
        {

            string query = @"UPDATE address SET address = @address1, adress2 = @address2, 
                           cityId = @cityId, postalCode = @postalCode, phone = @phone, lastUpdate = Now(), lastUpdatedBy = @user";



            MySqlCommand cmd = new MySqlCommand(query, conn);

            cmd.Parameters.AddWithValue("address1", address1);
            cmd.Parameters.AddWithValue("address2", address2);
            cmd.Parameters.AddWithValue("cityId", cityId);
            cmd.Parameters.AddWithValue("postalCode", postalCode);
            cmd.Parameters.AddWithValue("phone", phone);
            cmd.Parameters.AddWithValue("user", DBconnection.GetUserName());

            cmd.ExecuteNonQuery();
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