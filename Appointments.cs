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
        private DateTime SelectedDate;
        private bool monthSelected = true;

        private void Appointments_Load(object sender, EventArgs e)
        {
            //appointmentsDGV.DataSource = getAppointmentInTimePeriod(new DateTime(SelectedDate.Year, SelectedDate.Month, SelectedDate.Day), new DateTime(SelectedDate.Year, SelectedDate.Month, SelectedDate.Day + 1));
        }

        public Appointments()
        {
            InitializeComponent();
            SelectedDate = DateTime.Now;
        }

        //private BindingList<Appointment> getAppointmentInTimePeriod(DateTime beginTime, DateTime endTime)
        //{
            //Lambda used in Linq Statement to recreat List of Appointments that fall within the beginning and end time  bounds.
            //return new BindingList<Appointment>(MainMenu.ListOfAppointments.Where(appt => appt.Start >= beginTime && appt.End <= endTime).ToList());
        //}

        //private BindingList<Appointment> getAppointmentByCustomerId(int id)
        //{  //Returns Appointment List for DGV via CustomerID
           //return new BindingList<Appointment>(MainMenu.ListOfAppointments.Where(getAppointmentInTimePeriod => getAppointmentInTimePeriod.CustomerId == id).ToList());
        //}

        private DateTime findBeginningOfWeek(DateTime date)
        {
            var culture = Thread.CurrentThread.CurrentCulture;
            var difference = date.DayOfWeek - culture.DateTimeFormat.FirstDayOfWeek;
            if (difference < 0)
            {
                difference = difference + 7;
            }
            return date.AddDays(-difference).Date;
        }

        private DateTime findEndOfWeek(DateTime date)
        {
            return findBeginningOfWeek(date).AddDays(7).AddMilliseconds(-1);
        }

        private DateTime findBeginningOfMonth(DateTime date)
        {
            return new DateTime(date.Year, date.Month, 1);
        }

        private DateTime findEndOfMonth(DateTime date)
        {
            return findBeginningOfMonth(date).AddMonths(1).AddMilliseconds(-1);
        }

        //private void btnMonth_Click(object sender, EventArgs e)
        //{
        //    monthSelected = true;
        //    UpdateViewMonthlySelected();
        //}
        //private void UpdateViewMonthlySelected()
        //{
        //    DateTime beginningOfMonth = findBeginningOfMonth(SelectedDate);
        //    DateTime endOfMonth = findEndOfMonth(SelectedDate);
        //    appointmentsDGV.DataSource = getAppointmentInTimePeriod(beginningOfMonth, endOfMonth);
        //}

        //private void btnWeek_Click(object sender, EventArgs e)
        //{
        //    monthSelected = false;
        //    UpdateViewWeeklySelected();
        //}
        //private void UpdateViewWeeklySelected()
        //{
        //    DateTime beginningOfWeek = findBeginningOfWeek(SelectedDate);
        //    DateTime endOfWeek = findEndOfWeek(SelectedDate);
        //    appointmentsDGV.DataSource = getAppointmentInTimePeriod(beginningOfWeek, endOfWeek);
        //}
        //private void UpdateViewSearchId(int id)
        //{
        //    appointmentsDGV.DataSource = getAppointmentByCustomerId(id);
        //}

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

        private void btnAddModify_Click(object sender, EventArgs e)
        {
            try
            {
                if (appointmentsDGV.SelectedRows.Count < 1)
                {
                    throw new ApplicationException("You must select an appointment to edit.");
                }
                var selectRow = appointmentsDGV.SelectedRows[0];
                int selectAppointmentId = Convert.ToInt32(selectRow.Cells[0].Value);
                var editAppointment = new AddAppointments(this, selectAppointmentId);
                editAppointment.Show();
                appointmentsDGV.ClearSelection();
                Hide();
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


    }
}