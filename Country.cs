using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Scheduling_Appointment
{
    public class Country
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastUpdate { get; set; }
        public string LastUpdateBy { get; set; }

        static public List<Country> Countries = new List<Country>();
        public static List<Country> CountryProperty { get { return Countries; } }

        //static public int countryId;
        public Country(int countryId, string countryName, DateTime createDate, string createdBy, DateTime lastUpdate, string lastUpdateBy)
        {

            CountryName = countryName;
            CreateDate = createDate;
            CreatedBy = createdBy;
            LastUpdate = lastUpdate;
            LastUpdateBy = lastUpdateBy;
        }

        //public Country(string country)
        //{
        //DateTime createDate = DateTime.Now;
        //string createdBy = LogIn.tbUsername.Text;
        //DateTime lastUpdate = DateTime.Now;
        //string lastUpdateBy = LogIn.tbUsername.Text;

        //CountryName = country;
        //CreateDate = createDate;
        //CreatedBy = createdBy;
        //LastUpdate = lastUpdate;
        //LastUpdatedBy = lastUpdateBy;
        //}

        /*public void AddCountryToDataBase(Country country)
        {
            bool isPresent;
            if (i = 0; int country.Count; int++)
            {
                if (Countries[i].CountryName == country.CountryName)
                {
                    CountryId = Countries[i].CountryId;
                    isPresent = true;
                    break;
                }
                if (isPresent == false)
                { string sqlAddCountry = "INSERT INTO country (country, createDate, createdBy lastUpdate, lastUpdateBy) VALUES (?country.CountryName, ?country.CreateDate, ?country.CreatedBy, ?country.LastUpdate, ?country.LastUpdatedBy);"; }
                MySqlCommand cmd = new MySqlCommand(sqlAddCountry, conn)
                }
          */
    }
}
