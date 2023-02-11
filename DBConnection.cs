using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace Scheduling_Appointment
{
    public class DBconnection
    {

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
        //private void btnCustomers_Click
        //public static List<User> getAllUsers()
        //{
        //    List<User> listUsers = new List<User>();
        //    string query = "SELECT * FROM user";
        //    MySqlCommand cmd = new MySqlCommand(query, conn);
        //    MySqlDataReader dataReader = cmd.ExecuteReader();

        //    while (dataReader.Read())
        //    {
        //        int userID = Convert.ToInt32(dataReader[0]);
        //        string userName = dataReader[1].ToString();
        //        string password = dataReader[2].ToString();
        //        int active = Convert.ToInt32(dataReader[3]);
        //        DateTime createDate = Convert.ToDateTime(dataReader[4]).ToLocalTime();
        //        string createdBy = dataReader[5].ToString();
        //        DateTime lastUpdate = Convert.ToDateTime(dataReader[6]).ToLocalTime();
        //        string lastUpdateBy = dataReader[7].ToString();

        //        listUsers.Add(new User(userID, userName, password, active, createDate, createdBy, lastUpdate, lastUpdateBy));
        //    }
        //}

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

               // MainMenu.ListOfAppointments.Add(new Appointment(appointmentId, customerId, userId, type, start, end, createDate, createdBy, lastUpdate, lastUpdatedBy));
            }
        }

        public static void addAppointment(int customerId, string type, DateTime start, DateTime end)
        {
            DateTime now = DateTime.Now;
            /*var addAppointment = new Appointment(customerId, MainMenu.LoggedInUser.UserID, type, start, end, now, MainMenu.LoggedInUser.UserName, now, MainMenu.LoggedInUser.UserName);
            string query = $"INSERT INTO ' appointment' VALUES 
                $"({addAppointment.AppointmentId}, " +
                $"{customerId}, " +
                $"{MainMenu.LoggedInUser.UserID}, " +
                $"'not needed', " +
                $"'not needed', " +
                $"'not needed', " +
                $"'not needed', " +
                $"'{type}', " +
                $"'not needed', " +
                $"'{start.ToUniversalTime().ToString("yy-MM-dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo)}', " +
                $"'{end.ToUniversalTime().ToString("yy-MM-dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo)}', " +
                $"'{createDate.ToUniversalTime().ToString("yy-MM-dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo)}', " +
                $"'{MainMenu.LoggedInUser.UserName}" +
                $"'{addAppointment.LastUpdated.ToUniversalTime().ToString("yy-MM-dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo)}', " +
                $"'{MainMenu.LoggedInUser.UserName}')"; */

            string query = @"INSERT INTO appointment VALUES(NULL, @customerId, @userId, 
                            'not needed', 'not needed', 'not needed', 'not needed', @type, 'not needed',
                            @start, @end, Now(), 'user', Now(), 'user')";



            MySqlCommand cmd = new MySqlCommand(query, conn);

            cmd.Parameters.AddWithValue("customerId", customerId);
            cmd.Parameters.AddWithValue("userId", MainMenu.LoggedInUser.UserID);
            cmd.Parameters.AddWithValue("type", type);
            cmd.Parameters.AddWithValue("start", start);
            cmd.Parameters.AddWithValue("end", end);
            cmd.Parameters.AddWithValue("user", MainMenu.LoggedInUser.UserName);
            cmd.Parameters.AddWithValue("user", MainMenu.LoggedInUser.UserName);

            cmd.ExecuteNonQuery();

            //MainMenu.ListOfAppointments.Add(addAppointment);
        }

        public static void deleteAppointment(Appointment appointment)
        {
            string query = $"DELETE FROM appointment WHERE appointmentId={appointment.AppointmentId};";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            //MainMenu.ListOfAppointments.Remove(appointment);
        }

        public static void updateAppointment(Appointment appointment, int customerId, string type, DateTime start, DateTime end)
        {
            DateTime now = DateTime.Now;
            string nowString = now.ToUniversalTime().ToString("yy-MM-dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo);
            string query = $"UPDATE appointment SET customerId = {customerId}, " +
                $"userId={MainMenu.LoggedInUser.UserID}, type= '{type}', " +
                $"start'{start.ToUniversalTime().ToString("yy-MM-dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo)}', " +
                $"end='{end.ToUniversalTime().ToString("yy-MM-dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo)}, " +
                $"lastUpdated = '{nowString}', " +
                $"lastUpdateBy='{MainMenu.LoggedInUser.UserName}" +
                $"WHERE appointmentId={appointment.AppointmentId};";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.ExecuteNonQuery();

            Appointment updateAppointment = new Appointment(appointment.AppointmentId, customerId, MainMenu.LoggedInUser.UserID, type, start, end, appointment.CreateDate, appointment.CreatedBy, now, MainMenu.LoggedInUser.UserName);
            //int indexAppointmentList = MainMenu.ListOfAppointments.IndexOf(appointment);
            //MainMenu.ListOfAppointments.RemoveAt(indexAppointmentList);
            //MainMenu.ListOfAppointments.Insert(indexAppointmentList, updateAppointment);
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

               //MainMenu.ListOfCustomers.Add(new Customer(customerId, customerName, addressId, active, createDate, createdBy, lastUpdated, lastUpdatedBy));
            }
        }

        public static int addCustomer(int customerId, string customerName, int addressId, string user)
        {
            DateTime now = DateTime.Now;
           // var addedCustomer = new Customer(customerId,customerName, addressId, 1, now, user, now, user);
            //Hey Harlan
            /*string query = $"INSERT INTO 'customer' VALUES " +
                $"({addedCustomer.CustomerId}, " +
                $"'{addedCustomer.CustomerName}', " +
                $"{addedCustomer.AddressId}, " +
                $"{addedCustomer.Active}, " +
                $"'{addedCustomer.CreateDate.ToUniversalTime().ToString("yy-<<-dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo)}', " +
                $"'{addedCustomer.CreatedBy}', " +
                $"'{addedCustomer.LastUpdated.ToUniversalTime().ToString("yy-MM-dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo)}', " +
                $"'{addedCustomer.LastUpdateBy}')";
            */
            string query = @"INSERT INTO customer VALUES(NULL, @customerId, @customerName, 
                            @addressId, @active, Now(), @user, Now(), @user";



            MySqlCommand cmd = new MySqlCommand(query, conn);

            cmd.Parameters.AddWithValue("customerId", customerId);
            cmd.Parameters.AddWithValue("customerName", customerName);
            cmd.Parameters.AddWithValue("addressId", addressId);
            cmd.Parameters.AddWithValue("active", 1);
            cmd.Parameters.AddWithValue("user", MainMenu.LoggedInUser.UserName);
            cmd.Parameters.AddWithValue("user", MainMenu.LoggedInUser.UserName);

            //MainMenu.ListOfCustomers.Add(addedCustomer);
            //Todo Fix return type
            return 0;
        }

        public static void deleteCustomer(Customer customer)
        {
            string query = $"DELETE FROM customer WHERE customerId={customer.CustomerId};";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            //MainMenu.ListOfCustomers.Remove(customer);
            deleteAddress(customer.AddressId);
        }

        public static void updateCustomer(Customer customer, string customerName, string user)
        {
            DateTime now = DateTime.Now;
            string nowString = now.ToUniversalTime().ToString("yy-MM-dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo);
            string query = $"UPDATE customer SET customerName='{customerName}', lastUpdate = '{nowString}', lastUpdatedBy = '{user}' WHERE customerId = {customer.CustomerId};";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.ExecuteNonQuery();

            Customer updateCustomer = new Customer(customer.CustomerId, customerName, customer.AddressId, customer.Active, customer.CreateDate, customer.CreatedBy, now, user);
            //int indexCustomerList = MainMenu.ListOfCustomers.IndexOf(customer);
            //MainMenu.ListOfCustomers.RemoveAt(indexCustomerList);
            //MainMenu.ListOfCustomers.Insert(indexCustomerList, updateCustomer);
        }

        public static int AddAddress(string address1, string address2, int cityId, string postalCode, string phone, DateTime createDate, string createdBy, DateTime lastUpdate
            , string lastUpdateBy)
        {
            DateTime now = DateTime.Now;
            //Address addAddress = new Address(address1, address2, cityId, postalCode, phone, now, userName, now, userName);
            /*string query = $"INSERT INTO address VALUES" +
                $"({addAddress.AddressId}, " +
                $"{addAddress.Address1}, " +
                $"{addAddress.Address2}, " +
                $"{addAddress.CityId}, " +
                $"{addAddress.PostalCode}, " +
                $"{addAddress.Phone}, " +
                $"{addAddress.CreateDate.ToUniversalTime().ToString("yy-MM-dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo)}, " +
                $"{addAddress.CreatedBy}, " +
                $"{addAddress.LastUpdated.ToUniversalTime().ToString("yy-MM-dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo)}, " +
                $"{addAddress.LastUpdateBy})"; */
            string query = @"INSERT INTO address VALUES(NULL, @address1, @address2, 
                            @cityId, @postalCode, @phone, Now(), @user, Now(), @user";



            MySqlCommand cmd = new MySqlCommand(query, conn);

            cmd.Parameters.AddWithValue("address1", address1);
            cmd.Parameters.AddWithValue("address2", address2);
            cmd.Parameters.AddWithValue("cityId", cityId);
            cmd.Parameters.AddWithValue("postalCode", postalCode);
            cmd.Parameters.AddWithValue("phone", phone);
            cmd.Parameters.AddWithValue("user", MainMenu.LoggedInUser.UserName);
            cmd.Parameters.AddWithValue("user", MainMenu.LoggedInUser.UserName);

            cmd.ExecuteNonQuery();

            //MainMenu.AddressDictionary.Add(addAddress.AddressId, addAddress);
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

                //MainMenu.AddressDictionary.Add(addressId, new Address(addressId, address, address2, cityId, postalCode, phone, createDate, createdBy, lastUpdate, lastUpdatedBy));
            }
        }

       

        public static void deleteAddress(int addressId)
        {
            string query = $"DELETE FROM address WHERE addressId = {addressId};";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            //MainMenu.AddressDictionary.Remove(addressId);
        }

        public static void upDateAddress(Address address, string address1, string address2, int cityId, string postalCode, string phone, string user)
        {
            DateTime now = DateTime.Now;
            string nowString = now.ToUniversalTime().ToString("yy-MM-dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo);
            string query = $"UPDATE address SET address={address1}, address2={address2}, cityId={cityId}, postalCode={postalCode}, phone={phone}, lastUpdated={nowString}, lastUpdateBy={user} WHERE addressId={address.AddressId};";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.ExecuteNonQuery();
        }

        public static void getCity()
        {
            string query = "SELECT * FROM city";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                int cityId = Convert.ToInt32(dataReader[0]);
                string city = dataReader[1].ToString();
                int countryId = Convert.ToInt32(dataReader[2]);
                DateTime createDate = Convert.ToDateTime(dataReader[3]).ToLocalTime();
                string createdBy = dataReader[4].ToString();
                DateTime lastUpdated = Convert.ToDateTime(dataReader[5]).ToLocalTime();
                string lastUpdatedBy = dataReader[6].ToString();

               // MainMenu.CityDictionary.Add(cityId, new City(cityId, city, countryId, createDate, createdBy, lastUpdated, lastUpdatedBy));
            }
        }

        public static void getCountry()
        {
            string query = "SELECT * FROM country";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                int countryId = Convert.ToInt32(dataReader[0]);
                string country = dataReader[1].ToString();
                DateTime createDate = Convert.ToDateTime(dataReader[2]).ToLocalTime();
                string createdBy = dataReader[3].ToString();
                DateTime lastUpdated = Convert.ToDateTime(dataReader[4]).ToLocalTime();
                string lastUpdatedBy = dataReader[5].ToString();

                //MainMenu.CountryDictionary.Add(countryId, new Country(countryId, country, createDate, createdBy, lastUpdated, lastUpdatedBy));
            }
        }


    }
}