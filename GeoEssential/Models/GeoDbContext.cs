using GeoEssential.SeedingService;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Country>().HasData(SeedService.GetCountries());
            //modelBuilder.Entity<State>().HasData(SeedService.GetStates());
            //modelBuilder.Entity<City>().HasData(SeedService.Getcities());
        }

   

}
}
