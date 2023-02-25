using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduling_Appointment
{
    public class Address
    {
        public int AddressId { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public int CityId { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastUpdated { get; set; }
        public string LastUpdateBy { get; set; }

        //Mark Kinkaid Sword and Shield - Shield set up for DGV
        //private int id_;
        //private string address1_;
        //private string address2_;
        //private int cityId;
        //private string postalCode_;
        //private string phone_;
        //private DateTime createDate_;
        //private string createdBy_;
        //private DateTime lastUpdate_;
        //private string lastUpdatedBy_;

        //public int AddressId { get {return AddressId.ToString(); } }
        //public string Address1 { get { return Address1(); } }
        //public string Address2 { get { return Address2(); } }
        //public int CityId { get { return CityId.ToString(); } }
        //public string PostalCode { get { return PostalCode(); } }
        //public string Phone { get { return Phone(); } }
        //public DateTime CreateDate { get { return CreateDate.ToString(); } }
        //public string CreatedBy { get { return CreatedBy; } }
        //public DateTime LastUpdated { get { return LastUpdated.ToString(); } }
        //public string LastUpdateBy { get { return LastUpdateBy(); } }
        
        //If Needed to modify things for above set up --
        
        //public int getId() {return addressId_;}
        //public void setId(int id) {addressId = AddressId;}
        //public string getAddress1() {return address1_;}
        //public void setAddress1(string address1_) {address1 = Address1;}
        //public string getAddress2() {return address2_;}
        //public void setAddress2(string address2_) {address2 = Address2;}
        //public int getCityId() {return CityId_;}
        //public void setCityId(int id) {cityId = CityId;}
        //public string getPostalCode() {return postalCode_;}
        //public void setPostalCode(string postalCode_) {postalCode = PostalCode;}
        //public string getPhone() {return phone_;}
        //public void setPhone(string phone) {address2 = Address2;}

        //In the form class where DGV will be instantiated create attribute.
        //List - Specific
        //private BindingSource bds;
        //bds = new BindingSource {DataSource = Address.AddressProperty};
        //dgvXXX.DataSource = bds;
        //dgvXXX.SelectionMode= DataGridViewSelectionMode.FullRowSelect;
        //dgvXXX.ReadOnly = true;
        //dgvXXX.MultiSelect=false;
        //dgvXXX.AllowUserToAddRows=false;

        //private void myAddressBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
           //{dgvXXX.ClearSelection();}

      
        



        public static List<Address> address = new List<Address>();
        public static List<Address> AddressProperty { get { return address; } }

        public Address(int addressId, string address1, string address2, int cityId, string postalCode, string phone, DateTime createDate, string createdBy, DateTime lastUpdated, string lastUpdateBy)
        {
            AddressId = addressId;
            Address1 = address1;
            Address2 = address2;
            CityId = cityId;
            PostalCode = postalCode;
            Phone = phone;
            CreateDate = createDate;
            CreatedBy = createdBy;
            LastUpdated = lastUpdated;
            LastUpdateBy = lastUpdateBy;
        }

    }
}