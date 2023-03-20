using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scheduling_Appointment
{
    public partial class Appointments : Form
    {
       


        public Appointments()
        {
            InitializeComponent();

            // Mark Kinkaid Sword and shield - Sword DGV
            appointmentsDGV.DataSource = GetAllAppointments();
            appointmentsDGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            appointmentsDGV.ReadOnly = true;
            appointmentsDGV.MultiSelect = false;
            appointmentsDGV.AllowUserToAddRows = false;

            // Clean up / Hide Column Headers for appointmentsDGV
            appointmentsDGV.Columns[0].HeaderText = "Appointment ID";
            appointmentsDGV.Columns[1].HeaderText = "Customer ID";
            appointmentsDGV.Columns[2].HeaderText = "User ID";
            appointmentsDGV.Columns[3].Visible = false; //title
            appointmentsDGV.Columns[4].Visible = false; // description
            appointmentsDGV.Columns[5].Visible = false; // location
            appointmentsDGV.Columns[6].Visible = false; // contact
            appointmentsDGV.Columns[7].HeaderText = "Type"; // type
            appointmentsDGV.Columns[8].Visible = false; // url
            appointmentsDGV.Columns[9].HeaderText = "Start Date"; // start
            appointmentsDGV.Columns[10].HeaderText = "End Date"; // end
            appointmentsDGV.Columns[11].Visible = false; // created
            appointmentsDGV.Columns[12].Visible = false; // createBy
            appointmentsDGV.Columns[13].HeaderText = "Last Update";
            appointmentsDGV.Columns[14].HeaderText = "Last Updated By";


        }

        public DataTable GetAllAppointments()
        {
            DataTable allAppointments = new DataTable();
            allAppointments = new DataTable();
            string getAppointments = "SELECT * from Appointment";
            MySqlCommand sqlCommand = new MySqlCommand(getAppointments, DBconnection.conn);

            MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(sqlCommand);
            sqlDataAdapter.Fill(allAppointments);
            return allAppointments;
        }

      
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (appointmentsDGV.SelectedRows.Count < 1)
                {
                    throw new ApplicationException("You must select an appointment to delete.");
                }
                            
                DialogResult confirmDelete = MessageBox.Show("Confirm deletion of appointment.", "Application Instruction", MessageBoxButtons.YesNo);
                if (confirmDelete == DialogResult.Yes)
                {
                    int index = appointmentsDGV.CurrentRow.Index;
                    DataTable dt = (DataTable)appointmentsDGV.DataSource;
                    int appointmentID = (int)dt.Rows[index]["appointmentID"];

                    string delAppointment = "DELETE FROM Appointment WHERE appointmentId = @appointmentId";
                    MySqlCommand mySqlCommand = new MySqlCommand(delAppointment, DBconnection.conn);
                    mySqlCommand.Parameters.AddWithValue("@appointmentId", appointmentID);
                    mySqlCommand.ExecuteNonQuery();
                    appointmentsDGV.DataSource = GetAllAppointments();
                    
                    
                }
            }
            catch (ApplicationException error)
            {
                MessageBox.Show(error.Message, "Instructions", MessageBoxButtons.OK);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK);
            }

        }
       
        private void btnAddModify_Click(object sender, EventArgs e)
        {


            try
            {
                if (appointmentsDGV.SelectedRows.Count < 1)
                {
                    throw new ApplicationException("You must select an appointment to edit.");
                }


                int indexOfCurrentRow = appointmentsDGV.CurrentRow.Index;
                DataTable dataTable = (DataTable)appointmentsDGV.DataSource;
                int appointmentId = (int)dataTable.Rows[indexOfCurrentRow]["appointmentId"];
                int customerId = (int)dataTable.Rows[indexOfCurrentRow]["customerId"];
                int userId = (int)dataTable.Rows[indexOfCurrentRow]["userId"];
                string location = (string)dataTable.Rows[indexOfCurrentRow]["location"];
                string type = (string)dataTable.Rows[indexOfCurrentRow]["type"];
                string title = (string)dataTable.Rows[indexOfCurrentRow]["title"];
                DateTime start = (DateTime)dataTable.Rows[indexOfCurrentRow]["start"];
                DateTime end = (DateTime)dataTable.Rows[indexOfCurrentRow]["end"];
                string description = (string)dataTable.Rows[indexOfCurrentRow]["description"];
                string contact = (string)dataTable.Rows[indexOfCurrentRow]["contact"];
                string customerName = "";


                //getting customer Name from customer table to import to Update page 
                string getCustomerName = @"SELECT customerName FROM customer WHERE customerId = @customerId";
                MySqlCommand command = new MySqlCommand(getCustomerName, DBconnection.conn);
                command.Parameters.AddWithValue("@customerId", customerId);

                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    customerName = reader.GetString("customerName");
                }
                reader.Close();

                //getting user Name from user table to import to Update page 
                string userName = "";
                string getUserName = @"SELECT userName FROM user WHERE userId = @userId";
                MySqlCommand command2 = new MySqlCommand(getUserName, DBconnection.conn);
                command2.Parameters.AddWithValue("@userId", userId);

                MySqlDataReader reader2 = command2.ExecuteReader();
                while (reader2.Read())
                {
                    userName = reader2.GetString("userName");
                }
                reader2.Close();


                var modAppointments = new ModifyAppointments(appointmentId, customerId, customerName, userId, userName, location, type, title, start, end, description, contact);
                modAppointments.Show();
                
            }
            catch (ApplicationException error)
            {
                MessageBox.Show(error.Message, "Instructions", MessageBoxButtons.OK);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK);
            }
        }

        public void appointmentsDGV_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            appointmentsDGV.ClearSelection();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnCustomerRecords_Click(object sender, EventArgs e)
        {
            var customerRecords = new CustomerRecordsForm();
            customerRecords.Show();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            var Reports = new Reports();
            Reports.Show();
        }

        public void btnAdd_Click(object sender, EventArgs e)
        {
            var addAppointments = new AddModAppointments();
            addAppointments.Show();
            //ToDo  When addAppointments closes Update DGV.
        }

        private void btnAllAppointments_Click(object sender, EventArgs e)
        {
            appointmentsDGV.DataSource = GetAllAppointments();

        }

        private void btnWeek_Click(object sender, EventArgs e)
        {
            DataTable allAppointments = new DataTable();
            var startDate = dtp.Value;
            var endDate = dtp.Value.AddDays(7);
            string getAppointments = @"SELECT * from Appointment 
                                       WHERE userId = @userId 
                                       AND start BETWEEN @startDate AND @endDate";

            MySqlCommand sqlCommand = new MySqlCommand(getAppointments, DBconnection.conn);
            sqlCommand.Parameters.AddWithValue("@userId", DBconnection.GetUserID());
            sqlCommand.Parameters.AddWithValue("@startDate", startDate);
            sqlCommand.Parameters.AddWithValue("@endDate", endDate);


            MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(sqlCommand);

            sqlDataAdapter.Fill(allAppointments);
            appointmentsDGV.DataSource = allAppointments;          

        }

        private void btnMonth_Click(object sender, EventArgs e)
        {
            DataTable allAppointments = new DataTable();
            var startDate = dtp.Value;
            var endDate = dtp.Value.AddDays(30);
            string getAppointments = @"SELECT * from Appointment 
                                       WHERE userId = @userId 
                                       AND start BETWEEN @startDate AND @endDate";

            MySqlCommand sqlCommand = new MySqlCommand(getAppointments, DBconnection.conn);
            sqlCommand.Parameters.AddWithValue("@userId", DBconnection.GetUserID());
            sqlCommand.Parameters.AddWithValue("@startDate", startDate);
            sqlCommand.Parameters.AddWithValue("@endDate", endDate);


            MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(sqlCommand);

            sqlDataAdapter.Fill(allAppointments);
            appointmentsDGV.DataSource = allAppointments;

        }

    
    }
}