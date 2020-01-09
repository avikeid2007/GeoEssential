using System.Data;
using System.Data.SQLite;
using System.IO;
namespace GeoEssential.Db
{
    public class GeoEssential : Core
    {
        //public IEnumerable<Country> GetCountries()
        //{
        //    var result = GetData("SELECT * FROM Countries");
        //}
    }

    public abstract class Core
    {

        private DataTable dt;
        protected DataTable GetData(string command)
        {
            if (File.Exists(@"\App_Data\app.db"))
            {
                using (var con = new SQLiteConnection("Data Source=App_Data/app.db;Version=3;New=False;Compress=True;"))
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
