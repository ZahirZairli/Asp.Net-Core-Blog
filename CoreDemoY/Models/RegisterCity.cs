using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemoY.Models
{
    public class RegisterCity
    {
        public Writer Writer { get; set; }
        public int Id { get; set; }
        public string CityName { get; set; }


        public List<RegisterCity> RegisterCities()
        {
            List<RegisterCity> cities = new List<RegisterCity>();
            cities.Add(new RegisterCity { Id = 1, CityName = "Yardımlı" });
            cities.Add(new RegisterCity { Id = 5, CityName = "Bakı" });
            cities.Add(new RegisterCity { Id = 2, CityName = "Gence" });
            cities.Add(new RegisterCity { Id = 3, CityName = "Sumqayit" });
            return cities;
        }

    }
}
