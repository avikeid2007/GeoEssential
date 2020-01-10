using GeoEssential.Webapi.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Web;
namespace GeoEssential.Webapi.Services
{
    public class SqlService
    {
        public IEnumerable<Country> GetCountries()
        {
            var result = GetData("SELECT * FROM Countries");
            return result.AsEnumerable().Select(x => new Country { Id = x.Field<string>("Id"), SortName = x.Field<string>("SortName"), Name = x.Field<string>("Name") }).OrderBy(x => x.Name);
        }
        public IEnumerable<State> GetStates(string countryId)
        {
            var result = GetData("SELECT * FROM States where CountryId=" + countryId.Trim());
            return result.AsEnumerable().Select(x => new State { Id = x.Field<string>("Id"), Name = x.Field<string>("Name"), CountryId = string.Empty }).OrderBy(x => x.Name);
        }
        public IEnumerable<City> GetCities(string stateId)
        {
            var result = GetData("SELECT * FROM Cities where stateId=" + stateId.Trim());
            return result.AsEnumerable().Select(x => new City { Id = x.Field<string>("Id"), Name = x.Field<string>("Name"), stateId = string.Empty }).OrderBy(x => x.Name);
        }

        protected DataTable GetData(string command)
        {
            DataTable dt = null;
            var path = HttpContext.Current.Server.MapPath(@"~/App_Data/app.db");
            if (System.IO.File.Exists(path))
            {
                var cs = string.Format("Data Source={0};Version=3;New=False;Compress=True;", path);
                using (var con = new SQLiteConnection(cs))
                {
                    con.Open();
                    dt = new DataTable();
                    var Da = new SQLiteDataAdapter(command, con);
                    Da.Fill(dt);
                    if (dt != null && dt.Rows?.Count > 0)
                    {
                        return dt;
                    }
                }
            }
            return dt;

        }

    }
}