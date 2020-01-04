using GeoEssential.Models;
using GeoEssential.SeedingService.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GeoEssential.SeedingService
{
    public static class SeedService
    {
        public static IEnumerable<Country> GetCountries()
        {
            var filename = "SeedingService/countries.json";
            if (File.Exists(filename))
            {
                var res = JsonConvert.DeserializeObject<CountryFile>(File.ReadAllText(filename));
                return res.Countries.OrderBy(x => x.Id);
            }
            else
                return null;
        }
        public static IEnumerable<State> GetStates()
        {
            var filename = "SeedingService/states.json";
            if (File.Exists(filename))
            {
                var res = JsonConvert.DeserializeObject<StateFile>(File.ReadAllText(filename));
                return res.States.OrderBy(x => x.Id);
            }
            else
                return null;
        }
        public static IEnumerable<City> Getcities()
        {
            var filename = "SeedingService/cities.json";
            if (File.Exists(filename))
            {
                var res = JsonConvert.DeserializeObject<CityFile>(File.ReadAllText(filename));
                return  res.Cities.OrderBy(x => x.Id);
            }
            else
                return null;
        }
    }
}
