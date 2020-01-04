using GeoEssential.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoEssential.Models
{
    public static class GeoDbContextExtensions
    {
        public static async Task SeedAsync(this GeoDbContext context)
        {
            if (!(await context.Countries.AnyAsync()))
            {
                await context.Countries.AddRangeAsync(SeedingService.SeedService.GetCountries());
                await context.SaveChangesAsync();
            }
            if (!(await context.States.AnyAsync()))
            {
                await context.States.AddRangeAsync(SeedingService.SeedService.GetStates());
                await context.SaveChangesAsync();
            }
            if (!(await context.Cities.AnyAsync()))
            {
                await context.Cities.AddRangeAsync(SeedingService.SeedService.Getcities());
                await context.SaveChangesAsync();
            }


        }
    }
}
