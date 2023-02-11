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
    public partial class CustomerRecords : Form
    {
        public CustomerRecords()
        {
            InitializeComponent();
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

        private void cbCountry_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //var selectedCountryKey = Convert.ToInt32(cbCountry.SelectedValue);
            //var newCityNameDictionary = MainMenu.CityDictionary.Where(dict => dict.Value.CountryID == selectedCountryKey).ToDictionary(dict => dict.Key, dict => dict.Value.CityName);
            //cbCity.DataSource = new BindingSource(newCityNameDictionary, null);
            //cbCity.DisplayMember = "Value";
            //cbCity.ValueMember = "Key";
            //cbCity.SelectedItem = null;
        }

        private void cbCity_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbCountry.Text == "")
            {
                var selectedCityKey = cbCity.SelectedValue;
                //int selectedCountryKey = MainMenu.CityDictionary[Convert.ToInt32(selectedCityKey)].CountryID;
                //cbCountry.Text = MainMenu.CountryDictionary[selectedCountryKey].CountryName;
            }

        }

        private void cbCity_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cbCountry_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
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

        private void Name(object sender, EventArgs e)
        {

        }


    }
}