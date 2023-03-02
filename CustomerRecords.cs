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
        }

        //private void customerrecords_load(object sender, eventargs e)
        //{
        //dictionary<int, string> countrynamedictionary = mainmenu.countrydictionary.todictionary(dict => dict.key, dict => dict.value.countryname);
        //cbcountry.datasource = new bindingsource(countrynamedictionary, null);
        //cbcountry.displaymember = "value";
        //cbcountry.valuemember = "key";
        //cbcountry.selecteditem = null;
        //dictionary<int, string> citynamedictionary = mainmenu.citydictionary.todictionary(dict => dict.key, dict => dict.value.cityname);
        //cbcountry.datasource = new bindingsource(countrynamedictionary, null);
        //cbcountry.displaymember = "value";
        //cbcountry.valuemember = "key";
        //cbcountry.selecteditem = null;

        //}

        public DataTable GetAllCustomers()
        {
            customerRecords = new DataTable();
            string getCustomers = "SELECT  * from customer";
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

        private void clearInput()
        {
            tbName.Text = "";
            //tbCustomerId = " ";
            //tbAddress = " ";

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //DBconnection.addCustomer();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //customerRecordsDGV.SelectedRows[Customer customerId]
        }

        private void btnModify_Click(object sender, EventArgs e)
        {

        }
    }
}