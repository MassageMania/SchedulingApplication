using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scheduling_Appointment
{
    public partial class AddModAppointments : Form
    {
        
        public AddModAppointments()
        {
            InitializeComponent();
            LoadUser();
            LoadCustomer();
            LoadAppointmentTypes();

        }

        //Loads Combo Box for Types
        private void LoadAppointmentTypes()
        {
            List<string> appointmentTypes = new List<string>
            {
                "",
                "Scrum",
                "Presentation",
                "Orientation - New Hire",
                "Lunch",
                "Customer - New Contract",
                "Customer - Exisitng Contract"
            };

            //lambda expression to simplify loaded type cb dropdown
            appointmentTypes = appointmentTypes.OrderBy(type => type).ToList();
            cbType.DataSource = appointmentTypes;
        }

        void LoadUser()
        {
            string fillUser = @"SELECT userName 
                                FROM user";

            DataSet ds = new DataSet();
            MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(fillUser, DBconnection.conn);

            try
            {
                sqlDataAdapter.Fill(ds);
            }
            catch(MySqlException sqlEx)
            {
                MessageBox.Show("An Error occured while connecting to database" + sqlEx.ToString());
            }
            cbUser.DataSource = ds.Tables[0];
            cbUser.DisplayMember = ds.Tables[0].Columns[0].ToString();
        }

        void LoadCustomer()
        {
            string fillUser = @"SELECT customerName 
                                FROM customer";
            DataSet ds = new DataSet();
            MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(fillUser, DBconnection.conn);

            try
            {
                sqlDataAdapter.Fill(ds);
            }
            catch (MySqlException sqlEx)
            {
                MessageBox.Show("An Error occured while connecting to database" + sqlEx.ToString());
            }
            cbCustomerName.DataSource = ds.Tables[0];
            cbCustomerName.DisplayMember = ds.Tables[0].Columns[0].ToString();
        }

        public bool IsFormValid()
        {
            if (cbCustomerName.Text == null)
            {
                MessageBox.Show("Appointment customer is missing.");
                return false;
            }

            if (tbLocation.Text == null)
            {
                MessageBox.Show("Appointment location is missing.");
                return false;
            }

            if (cbType.Text == null)
            {
                MessageBox.Show("Appointment type is missing.");
                return false;
            }

            if (tbDescription.Text == null)
            {
                MessageBox.Show("Appointment description is missing.");
                return false;
            }
                       
            if (tbContact.Text == null)
            {
                MessageBox.Show("Appointment contact is missing.");
                return false;
            }
            if (dtpStart.Value == null)
            {
                MessageBox.Show("Appointment start date is missing.");
                return false;
            }
            else if (dtpStart.Value > dtpEnd.Value)
            {
                MessageBox.Show("Appointment start date cannot be after the appoinment end time.");
                return false;
            }
            else if (IsOutsideBusinessHours())
            {
                return false;
            }


            if (dtpEnd.Value == null)
            {
                MessageBox.Show("Appointment end date is missing.");
                return false;
            }
            else if (dtpEnd.Value < dtpStart.Value)
            {
                MessageBox.Show("Appointment end date cannot be before the appoinment start time.");
                return false;
            }
            else if (IsOutsideBusinessHours())
            {
                return false;
            }

            if (IsOverlapAppointment())
            {
                return false;
            }

            return true;
        
        }

        

        //function for checking if there's appointment overlap
        bool IsOverlapAppointment()
        {
            bool result = false;
            try
            {
                DateTime start = dtpStart.Value.ToUniversalTime();
                DateTime end = dtpEnd.Value.ToUniversalTime();

                string query =@"SELECT COUNT(*) 
                              FROM appointment 
                              WHERE start 
                              BETWEEN @start
                              AND @end
                              AND userId=@userId 
                              OR end 
                              BETWEEN @start 
                              AND @end 
                              AND userId=@userId";
                var mySqlCommand = new MySqlCommand(query, DBconnection.conn);
                mySqlCommand.Parameters.AddWithValue("@start", start);
                mySqlCommand.Parameters.AddWithValue("@end", end);
                mySqlCommand.Parameters.AddWithValue("@userId", DBconnection.GetUserID());

                int overlapIndex = Convert.ToInt32(mySqlCommand.ExecuteScalar());

                if (overlapIndex != 0)
                {
                    result = false;
                }
                else
                {
                    result = true;
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error!" + ex);
            }
            return result;
        }



        private bool IsOutsideBusinessHours()
        {
            var start = dtpStart.Value.TimeOfDay;
            var end = dtpEnd.Value.TimeOfDay;

            TimeSpan businessStartTime, businessEndTime;
            businessStartTime = new TimeSpan(08, 00, 00);
            businessEndTime = new TimeSpan(17, 30, 00);

            if (start < businessStartTime || end > businessEndTime)
            {
                //lambda seemed viable here
                Action<string> businessMessage = x => MessageBox.Show(x);
                businessMessage("Appointment is outside business hours. Please update time and resubmit.");

                return true;
            }

            return false;
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            var currentUser = Environment.UserName;

            string appointmentTitle = tbTitle.Text;
            string appointmentDescription = tbDescription.Text;
            string appointmentContact = tbContact.Text;
            string appointmentType = cbType.Text;
            string appointmentLocation = tbLocation.Text;
            string customerName = cbCustomerName.Text;
            string userName = cbUser.Text;
            int customerID = 0;
            var userID = 0;
            DateTime appointmentStart = dtpStart.Value.ToUniversalTime();
            DateTime appointmentEnd = dtpEnd.Value.ToUniversalTime();
            DateTime appointmentCreateDate = DateTime.Today;
            string appointmentCreatedBy = currentUser;
            DateTime appointmentLastUpdate = DateTime.Today;
            string appointmentLastUpdateBy = currentUser;

            //getting customer ID from customer to add to appointment table 
            string getCustomerID = @"SELECT customerId FROM customer WHERE customerName = @customerName";

            
            MySqlCommand command = new MySqlCommand(getCustomerID, DBconnection.conn);
            command.Parameters.AddWithValue("@customerName", customerName);

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                customerID = reader.GetInt32("customerId");
            }
            reader.Close();

            string getUserID = @"SELECT userId FROM user WHERE userName = @userName";

            MySqlCommand commandUser = new MySqlCommand(getUserID, DBconnection.conn);
            commandUser.Parameters.AddWithValue("@userName", userName);

            MySqlDataReader readerUser = commandUser.ExecuteReader();

            while (readerUser.Read())
            {
                userID = readerUser.GetInt32("userId");
            }
            readerUser.Close();
            string insertAppointment = @"INSERT INTO appointment VALUES(null, @customerId, @userId, @title, 
                                         @description, @location, @contact, @type, @url, @start, @end,
                                        @createDate, @createdBy, @lastUpdate, @lastUpdateBy)";
            // 
            //, @createDate, @createdBy, @lastUpdate, @lastUpdateBy

            MySqlCommand insertCommand = new MySqlCommand(insertAppointment, DBconnection.conn);

            insertCommand.Parameters.AddWithValue("@customerId", customerID);
            insertCommand.Parameters.AddWithValue("@userId", userID);
            insertCommand.Parameters.AddWithValue("@title", appointmentTitle);
            insertCommand.Parameters.AddWithValue("@description", appointmentDescription);
            insertCommand.Parameters.AddWithValue("@location", appointmentLocation);
            insertCommand.Parameters.AddWithValue("@contact", appointmentContact);
            insertCommand.Parameters.AddWithValue("@type", appointmentType);
            insertCommand.Parameters.AddWithValue("@url", customerName);
            insertCommand.Parameters.AddWithValue("@start", appointmentStart);
            insertCommand.Parameters.AddWithValue("@end", appointmentEnd);
            insertCommand.Parameters.AddWithValue("@createDate", appointmentCreateDate);
            insertCommand.Parameters.AddWithValue("@createdBy", appointmentCreatedBy);
            insertCommand.Parameters.AddWithValue("@lastUpdate", appointmentLastUpdate);
            insertCommand.Parameters.AddWithValue("@lastUpdateBy", appointmentLastUpdateBy);

            insertCommand.ExecuteNonQuery();

            //Appointments.appointmentsDGV.DataSource = Appointments.GetAllAppointmenets();

            MessageBox.Show("Appointment Has been added.");
            this.Close();
            Appointments appointment = new Appointments();
            appointment.Show();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            Appointments appointment = new Appointments();
            appointment.Show();
        }

        
    }
}