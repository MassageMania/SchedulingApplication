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
    public partial class AddAppointments : Form
    {
        private Appointments PreviousApp;
        private int SelectAppointmentId = -1;

        public AddAppointments(Appointments previousApp, int appointmentId)
        {
            InitializeComponent();
            PreviousApp = previousApp;
            SelectAppointmentId = appointmentId;
        }

        private void AddAppointments_Load(object sender, EventArgs e)
        {
            //Dictionary<int, string> customerDictionary = MainMenu.ListOfCustomers.ToDictionary(list => list.CustomerId, list => list.CustomerName);
            //cbCustomerName.DataSource = new BindingSource(customerDictionary, null);
            //cbCustomerName.DisplayMember = "Value";
            //cbCustomerName.ValueMember = "Key";
            //cbCustomerName.SelectedItem = null;

            //cbType.DataSource = new[] { "Scrum", "Presentation", "Lunch", "Interview", "Consultation", "Shareholder" };
            //cbType.SelectedItem = null;

            //if (SelectAppointmentId >= 0)
            //{
            //    Appointment appointment = MainMenu.ListOfAppointments.Where(appt => appt.AppointmentId == SelectAppointmentId).Single();
            //    cbCustomerName.Text = customerDictionary[appointment.CustomerId];
            //    cbType.Text = appointment.Type;
            //    dtStart.Value = appointment.Start;
            //    dtEnd.Value = appointment.End;
            //}
            //else
            //{
            //    DateTime now = DateTime.Now;
            //    dtStart.Value = new DateTime(now.Year, now.Month, now.Day, 8, 0, 0);
            //    dtEnd.Value = new DateTime(now.Year, now.Month, now.Day, 17, 0, 0);
            //}
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime now = DateTime.Now;
                TimeSpan businessStart = new DateTime(now.Year, now.Month, now.Day, 8, 0, 0).TimeOfDay;
                TimeSpan businessEnd = new DateTime(now.Year, now.Month, now.Day, 17, 0, 0).TimeOfDay;
                int selectCustomerId = Convert.ToInt32(cbCustomerName.SelectedValue);
                string selectType = cbType.SelectedValue.ToString();
                DateTime selectStart = dtStart.Value;
                DateTime selectEnd = dtEnd.Value;
                bool overlapping = false;

                //foreach (var appt in MainMenu.ListOfAppointments)
                //{
                //    if (appt.Start <= selectStart && appt.End > selectStart && (!(SelectAppointmentId >= 0)) || SelectAppointmentId >= 0)
                //    {
                //        overlapping = true;
                //    }
                //    if (selectStart <= appt.Start && selectEnd > appt.Start && (!(SelectAppointmentId >= 0)) || SelectAppointmentId >= 0)
                //    {
                //        overlapping = true;
                //    }
                //}

                if (SelectAppointmentId < 1)
                {
                    throw new ApplicationException("A customer must be selected.");
                }
                if (selectStart > selectEnd)
                {
                    throw new ApplicationException("Start time cannot be after end.");
                }
                if ((selectStart.TimeOfDay < businessStart) || (selectStart.TimeOfDay > businessEnd) || (selectEnd.TimeOfDay < businessStart) || (selectEnd.TimeOfDay > businessEnd))
                {
                    throw new ApplicationException("Appointments cannot be scheduled outside business hours.");
                }
                if (overlapping)
                {
                    throw new ApplicationException("Overlapping appopintments not acceptable.");
                }
                //if (SelectAppointmentId >= 0)
                //{
                //    Appointment appointment = MainMenu.ListOfAppointments.Where(appt => appt.AppointmentId == SelectAppointmentId).Single();
                //    DBconnection.updateAppointment(appointment, selectCustomerId, selectType, selectStart, selectEnd);
                //}
                //else
                //{
                //    DBconnection.addAppointment(selectCustomerId, selectType, selectStart, selectEnd);
                //}
                Close();
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("An appointment type must be selected.", "Instructions", MessageBoxButtons.OK);
            }
            catch (ApplicationException err)
            {
                MessageBox.Show(err.Message, "Instructions", MessageBoxButtons.OK);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK);
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddAppointments_FormClosed(object sender, FormClosedEventArgs e)
        {
            PreviousApp.Show();
        }

        private void cbCustomerName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cbType_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}