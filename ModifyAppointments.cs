using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scheduling_Appointment
{
    public partial class ModifyAppointments : Form
    {
      
        public ModifyAppointments()
        {
            InitializeComponent();
            
        }

        public ModifyAppointments(int appointmentId, int customerId, string customerName, int userId, string userName, string location, string type, string title, DateTime start, DateTime end, string description, string contact)
        {
            InitializeComponent();
            tbAppointmentId.Text = appointmentId.ToString();
            cbCustomer.Text = customerName.ToString();
            cbUser.Text = userName.ToString();
            tbLocation.Text = location;
            cbType.Text = type;
            tbTitle.Text = title;
            dtpStart.Text = start.ToString();
            dtpEnd.Text = end.ToString();
            tbDescription.Text = description;
            tbContact.Text = contact;
            LoadAppointmentTypes();
            LoadCustomerData();
            LoadUserData();
        }


        public bool IsFormValid()
        {

            if (tbTitle.Text == null)
            {
                MessageBox.Show("Appointment title is missing.");
                return false;
            }

            if (tbDescription.Text == null)
            {
                MessageBox.Show("Appointment description is missing.");
                return false;
            }

            if (tbLocation.Text == null)
            {
                MessageBox.Show("Appointment location is missing.");
                return false;
            }

            if (cbType.SelectedItem == null)
            {
                MessageBox.Show("Appointment type is missing.");
                return false;
            }

            if (tbContact.Text == null)
            {
                MessageBox.Show("Appointment contact is missing.");
                return false;
            }

            if (cbCustomer.SelectedItem == null)
            {
                MessageBox.Show("Appointment customer is missing.");
                return false;
            }

            if (cbUser.SelectedItem == null)
            {
                MessageBox.Show("Appointment user is missing.");
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

            //Todo Overlap appointment appears to be broken.

            if (IsOverlapAppointment())
            {
                return false;
            }

            return true;
        }

        public void UpdateAppointmentDB()
        {
            var currentUser = Environment.UserName;
            string appointmentTitle = tbTitle.Text;
            string appointmentDescription = tbDescription.Text;
            string appointmentContact = tbContact.Text;
            string appointmentType = cbType.Text;
            string appointmentLocation = tbLocation.Text;
            string customerName = cbCustomer.Text;
            string userName = cbUser.Text;
            int customerID = 0;
            var userID = 0;
            DateTime appointmentStart = dtpStart.Value.ToUniversalTime();
            DateTime appointmentEnd = dtpEnd.Value.ToUniversalTime();
            DateTime appointmentCreateDate = DateTime.Today;
            string appointmentCreatedBy = currentUser;
            DateTime appointmentLastUpdate = DateTime.Today;
            string appointmentLastUpdateBy = currentUser;
            int appointmentID = int.Parse(tbAppointmentId.Text);

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

            try
            {
                string updateDBAppointment = @"UPDATE appointment SET customerId = @customerID, userId = @userID, title = @appointmentTitle,
                                             description = @appointmentDescription, location = @appointmentLocation, 
                                             contact = @appointmentContact, type = @appointmentType, url = @customerName, start = @appointmentStart, 
                                             end = @appointmentEnd, createDate = @appointmentCreateDate, 
                                             createdBy = @appointmentCreatedBy, lastUpdate = @appointmentLastUpdate, lastUpdateBy = @appointmentLastUpdateBy
                                             WHERE appointmentId = @appointmentID";

                MySqlCommand updateCommand = new MySqlCommand(updateDBAppointment, DBconnection.conn);

                updateCommand.Parameters.AddWithValue("@appointmentID", appointmentID);
                updateCommand.Parameters.AddWithValue("@customerID", customerID);
                updateCommand.Parameters.AddWithValue("@userID", userID);
                updateCommand.Parameters.AddWithValue("@appointmentTitle", appointmentTitle);
                updateCommand.Parameters.AddWithValue("@appointmentDescription", appointmentDescription);
                updateCommand.Parameters.AddWithValue("@appointmentLocation", appointmentLocation);
                updateCommand.Parameters.AddWithValue("@appointmentContact", appointmentContact);
                updateCommand.Parameters.AddWithValue("@appointmentType", appointmentType);
                updateCommand.Parameters.AddWithValue("@customerName", customerName);
                updateCommand.Parameters.AddWithValue("@appointmentStart", appointmentStart);
                updateCommand.Parameters.AddWithValue("@appointmentEnd", appointmentEnd);
                updateCommand.Parameters.AddWithValue("@appointmentCreateDate", appointmentCreateDate);
                updateCommand.Parameters.AddWithValue("@appointmentCreatedBy", appointmentCreatedBy);
                updateCommand.Parameters.AddWithValue("@appointmentLastUpdate", appointmentLastUpdate);
                updateCommand.Parameters.AddWithValue("@appointmentLastUpdateBy", appointmentLastUpdateBy);

                updateCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

     

        //Loads Combo Box for Customers
        private void LoadCustomerData()
        {
            string selectQuery = @"SELECT customerName FROM customer";
            MySqlCommand command = new MySqlCommand(selectQuery, DBconnection.conn);

            MySqlDataReader reader = command.ExecuteReader();


            while (reader.Read())
            {
                cbCustomer.Items.Add(reader.GetString("customerName"));
            }
            reader.Close();
        }


        //Loads Combo Box for Users
        private void LoadUserData()
        {
            string selectQuery = @"SELECT userName FROM user";
            MySqlCommand command = new MySqlCommand(selectQuery, DBconnection.conn);

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                cbUser.Items.Add(reader.GetString("userName"));
            }

            reader.Close();
        }

        //function for checking if there's appointment overlap
        bool IsOverlapAppointment()
        {
            DateTime start = dtpStart.Value.ToUniversalTime();
            DateTime end = dtpEnd.Value.ToUniversalTime();

                string query = @"SELECT COUNT(*) 
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

            bool result;
            if (overlapIndex != 0)
            {
                result = true;
            }
            else
            {
                result = false;
            }

            return result;
        }

        private bool IsOutsideBusinessHours()
        {
            var start = dtpStart.Value.TimeOfDay;
            var end = dtpEnd.Value.TimeOfDay;

            TimeSpan businessStartTime, businessEndTime;
            businessStartTime = new TimeSpan(08, 00, 00);
            businessEndTime = new TimeSpan(21, 00, 00);

            if (start < businessStartTime || end > businessEndTime)
            {
                //lambda expression seemed viable here.
                Action<string> businessMessage = x => MessageBox.Show(x);
                businessMessage("Appointment is outside business hours. Please update time and resubmit.");

                return true;
            }

            return false;
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


     

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsFormValid())
            {
                UpdateAppointmentDB();
                MessageBox.Show("Appointment has been updated");
                Appointments appointments = new Appointments();
                appointments.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Form is invalid. Please review and resubmit.");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            Appointments appointment = new Appointments();
            appointment.Show();
        }

       
    }
}
