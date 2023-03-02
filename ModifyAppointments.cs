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
        private bool emptyCheck()
        {
            foreach (Control customer in Controls)
            {
                if (customer is TextBox)
                {
                    TextBox textBox = customer as TextBox;
                    if (textBox.Text == string.Empty)
                    {
                        return false;
                    }
                }
                if (customer is ComboBox)
                {
                    ComboBox combo = customer as ComboBox;
                    if (combo.SelectedIndex == -1)
                    {
                        return false;
                    }
                }
            }
            return true;
        }


        public bool appointmentValidator(DateTime startTime, DateTime endTime)
        {
            DateTime appointmentDate = dtpDate.Value;
            DateTime localStart = startTime.ToLocalTime();
            DateTime localEnd = endTime.ToLocalTime();
            DateTime businessStart = DateTime.Today.AddHours(8); //8AM
            DateTime businessEnd = DateTime.Today.AddHours(17); //5PM


            bool startValid = false;

            if
            (
                localStart > localEnd
                && dtpStart.Value.TimeOfDay >= businessStart.TimeOfDay
                && dtpStart.Value.TimeOfDay < businessEnd.TimeOfDay)
            {
                startValid = true;
            }

            else if
            (
                appointmentDate.Date == DateTime.Now.Date
                && dtpStart.Value.TimeOfDay > localEnd.TimeOfDay
                && dtpStart.Value.TimeOfDay > businessStart.TimeOfDay
                && dtpStart.Value.TimeOfDay < businessEnd.TimeOfDay)
            {
                startValid = true;
            }
            return startValid;
            ////1 for outside business hours
            //if (localStart.TimeOfDay < businessStart.TimeOfDay || localEnd.TimeOfDay > businessEnd.TimeOfDay)
            //{
            //    return 1;
            //}
            //// 2 for overlapping appointments
            //if (DBconnection.overlapAppointment(startTime, endTime) != 0)
            //{
            //    return 2;
            //}
            ////3 for ending time before starting time
            //if (localStart.TimeOfDay > localEnd.TimeOfDay)
            //{
            //    return 3;
            //}
            ////4 for appointment times not on the same day
            //if (localStart.ToShortDateString() != localEnd.ToShortDateString())
            //{
            //    return 4;
            //}
            ////0 for pass
            //return 0;
        }

        private void showError(string item)
        {
            MessageBox.Show("Please enter a valid information for " + item);

        }

        //Method to validate all fields are filled out
        private bool validate()
        {
            if (emptyCheck() == true)
            {
                MessageBox.Show("Please fill out all fields.");
                return false;
            }
            if (System.Text.RegularExpressions.Regex.IsMatch(tbLocation.Text, "[^a-zA-Z]+$"))
            {
                showError(lblLocation.Text);
                return false;
            }
            if (System.Text.RegularExpressions.Regex.IsMatch(tbType.Text, "[^a-zA-Z]+$"))
            {
                showError(lblType.Text);
                return false;
            }

            return true;
        }

        //private void btnAdd_Click(object sender, EventArgs e)
        //{

        //    bool pass = validate();
        //    if (pass)
        //    {
        //        if (tbCustomerName.SelectedItem != null)
        //        {
        //            DataRowView dataRowView = tbCustomerName.SelectedItem as DataRowView;
        //            int custID = Convert.ToInt32(tbCustomerName.SelectedValue);
        //            DateTime d1 = dtpDate.Value.Date;
        //            DateTime d2 = DateTime.Now;
        //            DateTime startTime = dtpStart.Value.ToUniversalTime();
        //            DateTime endTime = dtpEnd.Value.ToUniversalTime();

        //            bool validate = appointmentValidator(startTime, endTime);


        //            if (d1 > d2
        //            && dtpStart.Value.TimeOfDay >= startTime.TimeOfDay
        //            && dtpStart.Value.TimeOfDay < endTime.TimeOfDay)
        //            {
        //                validate = true;
        //            }
        //            else if (dtpDate.Value.Date == DateTime.Now.Date
        //               && dtpStart.Value.TimeOfDay > d2.TimeOfDay
        //               && dtpStart.Value.TimeOfDay > startTime.TimeOfDay
        //               && dtpStart.Value.TimeOfDay < endTime.TimeOfDay)
        //            {
        //                validate = true;
        //            }
        //            ;
        //            //switch (validate)
        //            //{
        //            //    case 1:
        //            //        MessageBox.Show("This appointment isn't within business hours.");
        //            //        break;
        //            //    case 2:
        //            //        MessageBox.Show("This appointment conflict with another appointment.");
        //            //        break;
        //            //    case 3:
        //            //        MessageBox.Show("The appointments start time is after the end time.");
        //            //        break;
        //            //    case 4:
        //            //        MessageBox.Show("The start and end date are not on the same date.");
        //            //        break;
        //            //    default:
        //            //        DBconnection.addAppointment(custID, tbLocation.Text, tbType.Text, startTime, endTime);
        //            //        MessageBox.Show("Appointment has been added.");
        //            //        Hide();
        //            //        Appointments showAppointments = new Appointments();
        //            //        showAppointments.Closed += (s, args) => this.Close();
        //            //        showAppointments.Show();
        //            //        break;
        //            //}
        //        }
        //        else
        //        {
        //            MessageBox.Show("Please select a customer.");
        //        }
        //    }
        //}

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
