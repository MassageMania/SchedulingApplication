using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduling_Appointment
{
    public class City
    {
        public int CityID { get; set; }
        public string CityName { get; set; }
        public int CountryID { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastUpdated { get; set; }
        public string LastUpdateBy { get; set; }

        public static List<City> city = new List<City>();
        public static List<City> CityProperty { get { return city; } }

        public City(int cityId, string cityName, int countryId, DateTime createDate, string createdBy, DateTime lastUpdated, string lastUpdateBy)
        {
            CityID = cityId;
            CityName = cityName;
            CountryID = countryId;
            CreateDate = createDate;
            CreatedBy = createdBy;
            LastUpdated = lastUpdated;
            LastUpdateBy = lastUpdateBy;
        }
    }
}