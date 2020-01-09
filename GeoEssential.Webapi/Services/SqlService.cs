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
            return result.AsEnumerable().ToList().Select(x => new Country { Id = x.Field<string>("Id"), SortName = x.Field<string>("SortName"), Name = x.Field<string>("Name") });
        }

        protected DataTable GetData(string command)
        {
            DataTable dt = null;
            var path = HttpContext.Current.Server.MapPath(@"~/App_Data/app.db");
            if (System.IO.File.Exists(path))
            {
                using (var con = new SQLiteConnection($"Data Source={path};Version=3;New=False;Compress=True;"))
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