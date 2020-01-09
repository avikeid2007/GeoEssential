using GeoEssential.Webapi.Models;
using GeoEssential.Webapi.Services;
using System.Collections.Generic;
using System.Web.Http;

namespace GeoEssential.Webapi.Controllers
{
    [RoutePrefix("api/Geo")]
    public class GeoController : ApiController
    {
        private SqlService sqlService;
        public GeoController()
        {
            sqlService = new SqlService();
        }
        [Route(nameof(GetCountries))]
        public IEnumerable<Country> GetCountries()
        {
            return sqlService.GetCountries();
        }
    }
}
