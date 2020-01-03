using Microsoft.EntityFrameworkCore;

namespace GeoEssential.Models
{
    public class GeoDbContext : DbContext
    {
        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }
        public GeoDbContext(DbContextOptions<GeoDbContext> options)
            : base(options)
        { }
    }
}
