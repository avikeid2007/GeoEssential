using GeoEssential.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GeoEssential.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private GeoDbContext _context;
        public CountryController(GeoDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Country>> GetCountries()
        {
            return _context.Countries;
        }
        [HttpPost]
        public async Task<ActionResult> SaveAutoNumberAsync(Country obj)
        {
            await _context.Countries.AddAsync(obj);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}