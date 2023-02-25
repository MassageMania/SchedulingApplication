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
        DateTime currentDate;
        private bool monthSelected = true;
        DataTable allAppointments = new DataTable();


        public Appointments()
        {
            InitializeComponent();
            currentDate = DateTime.Now;


            // Mark Kinkaid Sword and shield - Sword DGV
            appointmentsDGV.DataSource = GetAllAppointments();
            appointmentsDGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            appointmentsDGV.ReadOnly = true;
            appointmentsDGV.MultiSelect = false;
            appointmentsDGV.AllowUserToAddRows = false;
            
        }

        public DataTable GetAllAppointments()
        {
            allAppointments = new DataTable();
            string getAppointments = "SELECT * from Appointment";
            MySqlCommand sqlCommand = new MySqlCommand(getAppointments, DBconnection.conn);

            MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(sqlCommand);
            sqlDataAdapter.Fill(allAppointments);
            return allAppointments;
        }

        private void getData(string s)
        {
            using (MySqlConnection connection = new MySqlConnection(DBconnection.connectionString))
            {
                MySqlCommand command = new MySqlCommand(s, connection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                adapter.Fill(allAppointments);
            }
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
                    var selectRow = appointmentsDGV.SelectedRows[0];
                    int selectAppointmentId = Convert.ToInt32(selectRow.Cells[0].Value);
                    //Appointment selectAppointment = MainMenu.ListOfAppointments.Where(appt => appt.AppointmentId == selectAppointmentId).Single();
                    //DBconnection.deleteAppointment(selectAppointment);
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
        public static void UpdateExistingAppointment(Appointment appointment)
        {

            try

            {

                string start = appointment.ApptStartTime.ToString("yyyy-MM-dd HH:mm:00");

                string end = appointment.ApptEndTime.ToString("yyyy-MM-dd HH:mm:00");

                //DatabaseConnection.activeConn.Open();

                string cmdString = $@"UPDATE appointment SET customerId = {appointment.CustomerId}, userId = {appointment.UserId}, title = '{appointment.ApptTitle}', description = '{appointment.ApptDescription}',

                                      location = '{appointment.Location}', contact = '{appointment.Contact}', type = '{appointment.Type}', url = '{appointment.ApptURL}', start = '{start}',

                                      end = '{end}', lastUpdate = UTC_TIMESTAMP(), lastUpdateBy = '{appointment.LastUpdatedBy}'

                                      WHERE appointmentId = {appointment.AppointmentID}";



                MySqlCommand updateAppt = new MySqlCommand(cmdString, DatabaseConnection.activeConn);

                updateAppt.ExecuteNonQuery();

                //DatabaseConnection.activeConn.Close();



                // clear the datatables to prevent appended duplicates

                DBconnection.DT_ApptSchd.Clear();

                DBconnection.DT_MonthlyApptSchd.Clear();

                DBconnection.DT_WeeklyApptSchd.Clear();

                DBconnection.DT_DailyApptSchd.Clear();



                // refresh the datatables

                DBconnection.GetApptSchd();

                DBconnection.GetMonthlyApptSchd();

                DBconnection.GetWeeklyApptSchd();

                DBconnection.GetDailyApptSchd();

            }



            catch (MySqlException ex)

            {

                MessageBox.Show(ex.Message);

                //DatabaseConnection.activeConn.Close();

            }

        }
        private void btnAddModify_Click(object sender, EventArgs e)
        {


            //try
            //{
            //    if (appointmentsDGV.SelectedRows.Count < 1)
            //    {
            //        throw new ApplicationException("You must select an appointment to edit.");
            //    }
            //    var selectRow = appointmentsDGV.SelectedRows[0];
            //    int selectAppointmentId = Convert.ToInt32(selectRow.Cells[0].Value);
            //    //var editAppointment = new AddAppointments(this, selectAppointmentId);
            //    //editAppointment.Show();
            //    appointmentsDGV.ClearSelection();
            //    Hide();
            //}
            //catch (ApplicationException error)
            //{
            //    MessageBox.Show(error.Message, "Instructions", MessageBoxButtons.OK);
            //}
            //catch (Exception err)
            //{
            //    MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK);
            //}
        }

        private void appointmentsDGV_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            appointmentsDGV.ClearSelection();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            //back
        }

        private void btnCustomerRecords_Click(object sender, EventArgs e)
        {
            var customerRecords = new CustomerRecordsForm();
            customerRecords.Show();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            //var formReports = new formReports();
            //formReports.Show();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var addAppointments = new AddModAppointments();
            addAppointments.Show();
        }

        private void btnAllAppointments_Click(object sender, EventArgs e)
        {
            appointmentsDGV.DataSource = GetAllAppointments();

        }

        private void btnWeek_Click(object sender, EventArgs e)
        {            
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