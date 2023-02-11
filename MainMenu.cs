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
    public partial class MainMenu : Form
    {
        public static User LoggedInUser;
        //public static BindingList<Customer> ListOfCustomers = new BindingList<Customer>();
        //public static BindingList<Appointment> ListOfAppointments = new BindingList<Appointment>();
        //public static Dictionary<int, Address> AddressDictionary = new Dictionary<int, Address>();
        //public static Dictionary<int, City> CityDictionary = new Dictionary<int, City>();
        //public static Dictionary<int, Country> CountryDictionary = new Dictionary<int, Country>();
       


        public MainMenu()
        {
            InitializeComponent();
            //LoggedInUser = user;
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            //lblUserLog.Text = @"@userId is active.";
            DBconnection.getAddress();
            DBconnection.getAppointments();
            DBconnection.getCity();
            DBconnection.getCountry();
            DBconnection.getCustomer();
        }

        private void btnAppointments_Click(object sender, EventArgs e)
        {
            var appointments = new Appointments();
            appointments.Show();
            Hide();
        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            var customerRecords = new CustomerRecords();
            customerRecords.Show();
            Hide();
        }

        /*private void btnReports_Click(object sender, EventArgs e)
        {
            var reports = Reports();
            reports.Show();
            Hide();
        }*/

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //private void MainMenu_Shown(object sender, EventArgs e)
        //{
        //    var appointmentInFifteenMinutes = ListOfAppointments.Where(appt =>
        //    {
        //        var now = DateTime.Now;
        //        var fifteenMinutes = new TimeSpan(0, 15, 0);
        //        var timeLeft = appt.Start - now;

        //        if (timeLeft > new TimeSpan(0, 0, 0) && timeLeft <= fifteenMinutes)
        //        {
        //            return true;
        //        }
        //        return false;
        //    });
        //    if (appointmentInFifteenMinutes.Count() > 0)
        //    {
        //        var appointment = appointmentInFifteenMinutes.First();
        //        MessageBox.Show($"You have an appointment with {ListOfCustomers.Where(cust => cust.CustomerId == appointment.CustomerId).Single().CustomerName} " +
        //            $"at {appointment.Start.ToString("h:mm tt")}.", "Upcoming Appointment", MessageBoxButtons.OK);
        //    }

        }

}
