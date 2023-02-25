using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduling_Appointment
{
    public class Appointment
    {
        //public const int IDCODE_IDX = 0;
        public int AppointmentId { get; set; }
        public int CustomerId { get; set; }
        public int UserId { get; set; }
        public string Type { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastUpdated { get; set; }
        public string LastUpdatedBy { get; set; }

       // public static BindingList<Appointment> appointments = new BindingList<Appointment>();
        
        //See Address.cs for list DGV stuff
        public static List<Appointment> appointment = new List<Appointment>();
        public static List<Appointment> AppointmentProperty { get { return appointment; } }

        //public static BindingList<Address> = new BindingList<Address>;


        public Appointment(int appointmentId, int customerId, int userId, string type, DateTime start, DateTime end, DateTime createDate, string createdBy, DateTime lastUpdated, string lastUpdatedBy)
        {
            AppointmentId = appointmentId;
            CustomerId = customerId;
            UserId = userId;
            Type = type;
            Start = start;
            End = end;
            CreateDate = createDate;
            CreatedBy = createdBy;
            LastUpdated = lastUpdated;
            LastUpdatedBy = lastUpdatedBy;
        }
    }
}