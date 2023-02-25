using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduling_Appointment
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int AddressId { get; set; }
        public byte Active { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastUpdated { get; set; }
        public string LastUpdateBy { get; set; }
        //See Address.cs for list DGV stuff
        public static List<Customer> customer = new List<Customer>();
        public static List<Customer> CustomerProperty { get { return customer; } }

        public Customer(int customerId, string customerName, int addressId, byte active, DateTime createDate, string createdBy, DateTime lastUpdated, string lastUpdateBy)
        {
            CustomerId = customerId;
            CustomerName = customerName;
            AddressId = addressId;
            Active = active;
            CreateDate = createDate;
            CreatedBy = createdBy;
            LastUpdated = lastUpdated;
            LastUpdateBy = lastUpdateBy;
        }
    }
}