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
    public partial class Reports : Form
    {
        public Reports()
        {
            InitializeComponent();
            LoadAppointmentTypeData();
            LoadConsultantData();
            LoadCustomerData();
        }

        private void LoadAppointmentTypeData()
        {

            string selectQuery = @"SELECT DISTINCT type FROM appointment";
            MySqlCommand command = new MySqlCommand(selectQuery, DBconnection.conn);

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                cbAppointmentType.Items.Add(reader.GetString("type"));
            }

            reader.Close();
        }

        private void LoadConsultantData()
        {

            string selectQuery = @"SELECT userName FROM user";
            MySqlCommand command = new MySqlCommand(selectQuery, DBconnection.conn);

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                cbConsultant.Items.Add(reader.GetString("userName"));
            }
            reader.Close();
        }

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

        private void btnRunAppTypReport_Click(object sender, EventArgs e)
        {

            DateTime dtNow = DateTime.Now;
            DateTime dt30Days = DateTime.Now.AddDays(30);
            string type = cbAppointmentType.Text;

            string getAppointmentType = @"SELECT * FROM appointment WHERE type = @type and start BETWEEN @dtNow and @dt30Days";

            DataTable dataTable = new DataTable();

            MySqlCommand command = new MySqlCommand(getAppointmentType, DBconnection.conn);
            command.Parameters.AddWithValue("@type", type);
            command.Parameters.AddWithValue("@dtNow", dtNow);
            command.Parameters.AddWithValue("@dt30Days", dt30Days);
            
            int adapter = new MySqlDataAdapter(command).Fill(dataTable);

            for (int idx = 0; idx < dataTable.Rows.Count; idx++)
            {
                dataTable.Rows[idx]["start"] = TimeZoneInfo.ConvertTimeFromUtc((DateTime)dataTable.Rows[idx]["start"], TimeZoneInfo.Local).ToString();
            }

            for (int idx = 0; idx < dataTable.Rows.Count; idx++)
            {
                dataTable.Rows[idx]["end"] = TimeZoneInfo.ConvertTimeFromUtc((DateTime)dataTable.Rows[idx]["end"], TimeZoneInfo.Local).ToString();
            }
            if (dataTable.Rows.Count > 0)
            {
                dgvReport.DataSource = dataTable;
                dgvReport.Columns[0].HeaderText = "Appointment ID";
                dgvReport.Columns[1].Visible = false;
                dgvReport.Columns[2].Visible = false;
                dgvReport.Columns[3].HeaderText = "Title";
                dgvReport.Columns[4].HeaderText = "Description";
                dgvReport.Columns[5].HeaderText = "Location";
                dgvReport.Columns[6].HeaderText = "Contact";
                dgvReport.Columns[7].HeaderText = "Type";
                dgvReport.Columns[8].HeaderText = "Customer";
                dgvReport.Columns[9].HeaderText = "Start";
                dgvReport.Columns[10].HeaderText = "End";
                dgvReport.Columns[11].Visible = false;
                dgvReport.Columns[12].Visible = false;
                dgvReport.Columns[13].Visible = false;
                dgvReport.Columns[14].Visible = false;
            }
        }

        private void btnConsultantReport_Click(object sender, EventArgs e)
        {
            string userName = cbConsultant.Text;
            int userID = 0;

            string getUserID = @"SELECT userId FROM user WHERE userName = @userName";

            MySqlCommand commandUser = new MySqlCommand(getUserID, DBconnection.conn);
            commandUser.Parameters.AddWithValue("@userName", userName);

            MySqlDataReader readerUser = commandUser.ExecuteReader();

            while (readerUser.Read())
            {
                userID = readerUser.GetInt32("userId");
            }
            readerUser.Close();

            string getUserType = @"SELECT * FROM appointment WHERE userId = @userID";

            DataTable dataTable = new DataTable();

            MySqlCommand command = new MySqlCommand(getUserType, DBconnection.conn);
            command.Parameters.AddWithValue("@userID", userID);
            

            int adapter = new MySqlDataAdapter(command).Fill(dataTable);
            for (int idx = 0; idx < dataTable.Rows.Count; idx++)
            {
                dataTable.Rows[idx]["start"] = TimeZoneInfo.ConvertTimeFromUtc((DateTime)dataTable.Rows[idx]["start"], TimeZoneInfo.Local).ToString();
            }

            for (int idx = 0; idx < dataTable.Rows.Count; idx++)
            {
                dataTable.Rows[idx]["end"] = TimeZoneInfo.ConvertTimeFromUtc((DateTime)dataTable.Rows[idx]["end"], TimeZoneInfo.Local).ToString();
            }

            if (dataTable.Rows.Count > 0)
            {
                dgvReport.DataSource = dataTable;
                dgvReport.Columns[0].HeaderText = "Appointment ID";
                dgvReport.Columns[1].Visible = false;
                dgvReport.Columns[2].Visible = false;
                dgvReport.Columns[3].HeaderText = "Title";
                dgvReport.Columns[4].HeaderText = "Description";
                dgvReport.Columns[5].HeaderText = "Location";
                dgvReport.Columns[6].HeaderText = "Contact";
                dgvReport.Columns[7].HeaderText = "Type";
                dgvReport.Columns[8].HeaderText = "Customer";
                dgvReport.Columns[9].HeaderText = "Start";
                dgvReport.Columns[10].HeaderText = "End";
                dgvReport.Columns[11].Visible = false;
                dgvReport.Columns[12].Visible = false;
                dgvReport.Columns[13].Visible = false;
                dgvReport.Columns[14].Visible = false;
            }
        }

        private void btnCustomerReport_Click(object sender, EventArgs e)
        {
            string customerName = cbCustomer.Text;
            int customerID = 0;

            //getting customerID for the appointment sql statement below 
            string getCustomerID = @"SELECT customerId FROM customer WHERE customerName = @customerName";

            MySqlCommand command = new MySqlCommand(getCustomerID, DBconnection.conn);
            command.Parameters.AddWithValue("@customerName", customerName);

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                customerID = reader.GetInt32("customerId");
            }
            reader.Close();

            string getAppointmentType = @"SELECT * FROM appointment WHERE customerId = @customerID";

            DataTable dataTable = new DataTable();

            MySqlCommand commandCustomer = new MySqlCommand(getAppointmentType, DBconnection.conn);
            commandCustomer.Parameters.AddWithValue("@customerID", customerID);
            

            int adapter = new MySqlDataAdapter(commandCustomer).Fill(dataTable);
            
            for (int idx = 0; idx < dataTable.Rows.Count; idx++)
            {
                dataTable.Rows[idx]["start"] = TimeZoneInfo.ConvertTimeFromUtc((DateTime)dataTable.Rows[idx]["start"], TimeZoneInfo.Local).ToString();
            }

            for (int idx = 0; idx < dataTable.Rows.Count; idx++)
            {
                dataTable.Rows[idx]["end"] = TimeZoneInfo.ConvertTimeFromUtc((DateTime)dataTable.Rows[idx]["end"], TimeZoneInfo.Local).ToString();
            }

            if (dataTable.Rows.Count > 0)
            {
                dgvReport.DataSource = dataTable;
                dgvReport.Columns[0].HeaderText = "Appointment ID";
                dgvReport.Columns[1].Visible = false;
                dgvReport.Columns[2].Visible = false;
                dgvReport.Columns[3].HeaderText = "Title";
                dgvReport.Columns[4].HeaderText = "Description";
                dgvReport.Columns[5].HeaderText = "Location";
                dgvReport.Columns[6].HeaderText = "Contact";
                dgvReport.Columns[7].HeaderText = "Type";
                dgvReport.Columns[8].HeaderText = "Customer";
                dgvReport.Columns[9].HeaderText = "Start";
                dgvReport.Columns[10].HeaderText = "End";
                dgvReport.Columns[11].Visible = false;
                dgvReport.Columns[12].Visible = false;
                dgvReport.Columns[13].Visible = false;
                dgvReport.Columns[14].Visible = false;
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

            
    }
}
