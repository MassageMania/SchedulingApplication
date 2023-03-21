using System;
using MySql.Data.MySqlClient;
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
    public partial class CustomerRecordsForm : Form
    {
        DataTable customerRecords = new DataTable();
        public CustomerRecordsForm()
        {
            InitializeComponent();

            customerRecordsDGV.DataSource = GetAllCustomers();
            customerRecordsDGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            customerRecordsDGV.ReadOnly = true;
            customerRecordsDGV.MultiSelect = false;
            customerRecordsDGV.AllowUserToAddRows = false;

            // Clean up / Hide Column Headers for CustomerRecordsDGV
            customerRecordsDGV.Columns[0].HeaderText = "Customer Name"; //customerName
            customerRecordsDGV.Columns[1].HeaderText = "Customer ID"; //customerId
            customerRecordsDGV.Columns[2].HeaderText = "Address"; // address1
            customerRecordsDGV.Columns[3].Visible = false; //address2
            customerRecordsDGV.Columns[4].HeaderText = "City"; // city
            customerRecordsDGV.Columns[5].HeaderText = "Country"; // country
            customerRecordsDGV.Columns[6].HeaderText = "Postal Code"; // postalCode
            customerRecordsDGV.Columns[7].HeaderText = "Phone Number"; // phone
     

        }

       
        public DataTable GetAllCustomers()
        {
            customerRecords = new DataTable();
            string getCustomers = @"SELECT customerName, customerId, address, address2, city, country, postalCode, phone 
                                FROM customer, address, city, country 
                                WHERE customer.addressId = address.addressId 
                                AND address.cityId = city.cityId 
                                AND city.countryId = country.countryId;";
            MySqlCommand sqlCommand = new MySqlCommand(getCustomers, DBconnection.conn);

            MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(sqlCommand);
            sqlDataAdapter.Fill(customerRecords);
            return customerRecords;
        }
      
        private void customerRecordsDGV_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var dataGridView = customerRecordsDGV;
            dataGridView.AutoResizeColumns();
            dataGridView.ClearSelection();
            dataGridView.MultiSelect = false;
            dataGridView.RowHeadersVisible = false;
            dataGridView.ReadOnly = true;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public bool IsFormValid()
        {
            if (tbName.Text == null)
            {
                MessageBox.Show("Customer name is missing.");
                return false;
            }

            if (tbAddress.Text == null)
            {
                MessageBox.Show("Address line 1 is missing.");
                return false;
            }

            if (tbCity.Text == null)
            {
                MessageBox.Show("City is missing.");
                return false;
            }

            if (tbPostalCode.Text == null)
            {
                MessageBox.Show("Zip code is missing.");
                return false;
            }

            if (tbCountry.Text == null)
            {
                MessageBox.Show("Country is missing.");
                return false;
            }

            if (tbPhoneNumber.Text == null)
            {
                MessageBox.Show("Phone number is missing.");
                return false;
            }

            return true;
        }
        public void AddCustomerToDB()
        {
            var currentUser = Environment.UserName;
            string customerName = tbName.Text;
            int isActive = 1;
            DateTime customerCreateDate = DateTime.Today;
            string customerCreatedBy = currentUser;
            DateTime customerLastUpdate = DateTime.Today;
            string customerLastUpdateBy = currentUser;
            var addressLine1 = tbAddress.Text;
            int addressID = 0;

            //getting address ID from address to add to customer table 
            string getAddressID = @"SELECT addressId FROM address WHERE address = @addressLine1";


            MySqlCommand command = new MySqlCommand(getAddressID, DBconnection.conn);
            command.Parameters.AddWithValue("@addressLine1", addressLine1);

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                addressID = reader.GetInt32("addressId");
            }
            reader.Close();

            try
            {
                string insertCustomerDB = @"INSERT INTO customer VALUES(null, @customerName, @addressId, @isActive, @createDate, @createdBy, @lastUpdate, @lastUpdateBy)";
                MySqlCommand insertCommand = new MySqlCommand(insertCustomerDB, DBconnection.conn);

                insertCommand.Parameters.AddWithValue("@customerName", customerName);
                insertCommand.Parameters.AddWithValue("@addressId", addressID);
                insertCommand.Parameters.AddWithValue("@isActive", isActive);
                insertCommand.Parameters.AddWithValue("@createDate", customerCreateDate);
                insertCommand.Parameters.AddWithValue("@createdBy", customerCreatedBy);
                insertCommand.Parameters.AddWithValue("@lastUpdate", customerLastUpdate);
                insertCommand.Parameters.AddWithValue("@lastUpdateBy", customerLastUpdateBy);

                insertCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Todo Error Code Zip to prevent Letters being used.
        public void AddAddressToDB()
        {
            var currentUser = Environment.UserName;
            var addressLine1 = tbAddress.Text;
            var addressLine2 = tbAddress2.Text;
            int zipCode = int.Parse(tbPostalCode.Text);
            var phoneNumber = tbPhoneNumber.Text;
            var addressCreateDate = DateTime.Today;
            var addressCreatedBy = currentUser;
            var addressLastUpdate = DateTime.Today;
            var addressLastUpdateBy = currentUser;
            var cityName = tbCity.Text;
            int cityID = 0;

            //getting city ID from city to add to address table
            string getCityID = @"SELECT cityId FROM city WHERE city = @cityName";


            MySqlCommand command = new MySqlCommand(getCityID, DBconnection.conn);
            command.Parameters.AddWithValue("@cityName", cityName);

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                cityID = reader.GetInt32("cityId");
            }
            reader.Close();

            try
            {
                string insertAddressDB = @"INSERT INTO address VALUES(null, @address, @address2, @cityId, @postalCode, @phone, @createDate, @createdBy, @lastUpdate, @lastUpdateBy)";
                MySqlCommand insertCommand = new MySqlCommand(insertAddressDB, DBconnection.conn);

                insertCommand.Parameters.AddWithValue("@address", addressLine1);
                insertCommand.Parameters.AddWithValue("@address2", addressLine2);
                insertCommand.Parameters.AddWithValue("@cityId", cityID);
                insertCommand.Parameters.AddWithValue("@postalCode", zipCode);
                insertCommand.Parameters.AddWithValue("@phone", phoneNumber);
                insertCommand.Parameters.AddWithValue("@createDate", addressCreateDate);
                insertCommand.Parameters.AddWithValue("@createdBy", addressCreatedBy);
                insertCommand.Parameters.AddWithValue("@lastUpdate", addressLastUpdate);
                insertCommand.Parameters.AddWithValue("@lastUpdateBy", addressLastUpdateBy);

                insertCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void AddCityToDB()
        {
            var currentUser = Environment.UserName;
            var customerCity = tbCity.Text;
            var cityCreateDate = DateTime.Today;
            var cityCreatedBy = currentUser;
            var cityLastUpdate = DateTime.Today;
            var cityLastUpdateBy = currentUser;
            int countryID = 0;
            var countryName = tbCountry.Text;

            //getting country ID from country to add to city table
            string getCountryID = @"SELECT countryId FROM country WHERE country = @countryName";

            MySqlCommand command = new MySqlCommand(getCountryID, DBconnection.conn);
            command.Parameters.AddWithValue("@countryName", countryName);

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                countryID = reader.GetInt32("countryId");
            }
            reader.Close();

            try
            {
                string insertCityDB = @"INSERT INTO city VALUES(null, @city, @countryId, @createDate, @createdBy, @lastUpdate, @lastUpdateBy)";
                MySqlCommand insertCommand = new MySqlCommand(insertCityDB, DBconnection.conn);

                insertCommand.Parameters.AddWithValue("@city", customerCity);
                insertCommand.Parameters.AddWithValue("@countryId", countryID);
                insertCommand.Parameters.AddWithValue("@createDate", cityCreateDate);
                insertCommand.Parameters.AddWithValue("@createdBy", cityCreatedBy);
                insertCommand.Parameters.AddWithValue("@lastUpdate", cityLastUpdate);
                insertCommand.Parameters.AddWithValue("@lastUpdateBy", cityLastUpdateBy);

                insertCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void AddCountryToDB()
        {
            var currentUser = Environment.UserName;
            var customerCountry = tbCountry.Text;
            var countryCreateDate = DateTime.Today;
            var countryCreatedBy = currentUser;
            var countryLastUpdate = DateTime.Today;
            var countryLastUpdateBy = currentUser;

            try
            {
                string insertCountryDB = @"INSERT INTO country VALUES(null, @country, @createDate, @createdBy, @lastUpdate, @lastUpdateBy)";
                MySqlCommand insertCommand = new MySqlCommand(insertCountryDB, DBconnection.conn);

                insertCommand.Parameters.AddWithValue("@country", customerCountry);
                insertCommand.Parameters.AddWithValue("@createDate", countryCreateDate);
                insertCommand.Parameters.AddWithValue("@createdBy", countryCreatedBy);
                insertCommand.Parameters.AddWithValue("@lastUpdate", countryLastUpdate);
                insertCommand.Parameters.AddWithValue("@lastUpdateBy", countryLastUpdateBy);
                insertCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (IsFormValid())
            {
                
                DialogResult dialog = MessageBox.Show("Is this the correct information you want to add to customer Records?", "Add Customer", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes)
                {
                    AddCountryToDB();
                    AddCityToDB();
                    AddAddressToDB();
                    AddCustomerToDB();
                    customerRecordsDGV.DataSource = GetAllCustomers();
                }
                else if (dialog == DialogResult.No)
                {
                    MessageBox.Show("Add canceled.");
                }
    
            }
            else
            {
                MessageBox.Show("Form is invalid. Please verify all fields and click Save again.");
            }



        }

        private void btnDelete_Click(object sender, EventArgs e)
        { 


            DialogResult dialog = MessageBox.Show("Are you sure you want to delete customer and associated appointments?", "Delete", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                int index = customerRecordsDGV.CurrentRow.Index;
                DataTable dt = (DataTable)customerRecordsDGV.DataSource;
                int customerId = (int)dt.Rows[index]["customerId"];
                string customerName = (string)dt.Rows[index]["customerName"];

                string sqlDoTheyHaveAppts = "DELETE FROM Appointment WHERE customerId = @customerId";
                MySqlCommand sqlCommand2 = new MySqlCommand(sqlDoTheyHaveAppts, DBconnection.conn);
                sqlCommand2.Parameters.AddWithValue("@customerId", customerId);
                sqlCommand2.ExecuteNonQuery();

                string sqlDel = @"DELETE FROM Customer 
                            WHERE customerName = @customerName";
                MySqlCommand sqlCommand = new MySqlCommand(sqlDel, DBconnection.conn);
                sqlCommand.Parameters.AddWithValue("@customerName", customerName);
                sqlCommand.ExecuteNonQuery();
            }
            else if (dialog == DialogResult.No)
            {
                MessageBox.Show("Customer And Associated Appointments Delete Canceled.");
            }
            
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            string joinUpdate = @"UPDATE Customer c
                                  INNER JOIN Address a
	                                ON c.addressId = a.addressId
                                  INNER JOIN City ci
	                                ON a.cityId = ci.cityId
                                  INNER JOIN Country co
	                                ON ci.countryId = co.countryId
                                  SET customerName = @customerName, address = @address, address2 = @address2, 
                                      postalCode = @postalCode, phone = @phone, city = @city, country = @country
                                  WHERE customerId = @customerId";

            // Todo Ensure Text boxes have proper param's to enter IE - string v int v bool v datetime
           
            MySqlCommand sqlCommand = new MySqlCommand(joinUpdate, DBconnection.conn);
            sqlCommand.Parameters.AddWithValue("@customerName", tbName.Text);
            sqlCommand.Parameters.AddWithValue("@address", tbAddress.Text);
            sqlCommand.Parameters.AddWithValue("@address2", tbAddress2.Text);
            sqlCommand.Parameters.AddWithValue("@postalCode", tbPostalCode.Text);
            sqlCommand.Parameters.AddWithValue("@phone", tbPhoneNumber.Text);
            sqlCommand.Parameters.AddWithValue("@city", tbCity.Text);
            sqlCommand.Parameters.AddWithValue("@country", tbCountry.Text);
            sqlCommand.Parameters.AddWithValue("@customerId", tbId.Text);
            //sqlCommand.Parameters.AddWithValue("@lastUpdate", DateTime.Now);
            //sqlCommand.Parameters.AddWithValue("@lastUpdateBy", DBconnection.GetUserID());
            

           
            DialogResult dialog = MessageBox.Show("Are you sure you want to modify this customer?","Modify", MessageBoxButtons.YesNo);
            if(dialog == DialogResult.Yes)
            {
                sqlCommand.ExecuteNonQuery();
                customerRecordsDGV.DataSource = GetAllCustomers();
            }
            else if (dialog == DialogResult.No)
            {
                MessageBox.Show("Modify Canceled.");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            customerRecordsDGV.ClearSelection();
            tbName.Text = "";
            tbId.Text = ""; 
            tbAddress.Text = " ";
            tbAddress2.Text = " ";
            tbCity.Text = " ";
            tbCountry.Text = " ";
            tbPostalCode.Text = " ";
            tbPhoneNumber.Text = " ";

        }


        public void ModifyCustomerRecords(string customerName, int customerId, string address, string city, string country, string postalCode, string phoneNumber)
        {
            InitializeComponent();
            tbName.Text = customerName;
            tbId.Text = customerId.ToString();
            tbAddress.Text = address;
            tbCity.Text = city;
            tbCountry.Text = country;
            tbPostalCode.Text = postalCode;
            tbPhoneNumber.Text = phoneNumber;
        }

        private void customerRecordsDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int indexOfCurrentRow = customerRecordsDGV.CurrentRow.Index;
            DataTable dataTable = (DataTable)customerRecordsDGV.DataSource;
            tbName.Text = (string)dataTable.Rows[indexOfCurrentRow]["customerName"];
            tbId.Text = Convert.ToString((int)dataTable.Rows[indexOfCurrentRow]["customerId"]);
            tbAddress.Text = (string)dataTable.Rows[indexOfCurrentRow]["address"];
            tbCity.Text = (string)dataTable.Rows[indexOfCurrentRow]["city"];
            tbCountry.Text = (string)dataTable.Rows[indexOfCurrentRow]["country"];
            tbPostalCode.Text = (string)dataTable.Rows[indexOfCurrentRow]["postalCode"];
            tbPhoneNumber.Text = (string)dataTable.Rows[indexOfCurrentRow]["phone"]; 
        }

    }
}