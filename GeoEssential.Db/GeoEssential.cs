using GeoEssential.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
namespace GeoEssential.Db
{
    public class GeoEssential : Core
    {
        public IEnumerable<Country> GetCountries()
        {
            return GetData<Country>("SELECT * FROM Countries");
        }
    }

    public abstract class Core
    {
        private string cs = @"URI=app.db";
        private DataTable dt;
        protected IEnumerable<T> GetData<T>(string command)
        {
            using (var con = new SQLiteConnection(cs))
            {
                con.Open();
                dt = new DataTable();
                var Da = new SQLiteDataAdapter(command, con);
                Da.Fill(dt);
                if (dt != null && dt.Rows?.Count > 0)
                {
                    return dt.DefaultView.AsQueryable().OfType<T>();
                }
                return null;
            }
        }

    }

}
