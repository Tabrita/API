using Microsoft.EntityFrameworkCore;
using PropertyAPI.Models;

namespace PropertyAPI.Data
{
    public class PropertyDbContext : DbContext
    {
        public PropertyDbContext(DbContextOptions<PropertyDbContext> options) : base(options) { }

        public DbSet<City> Cities { get; set; }

    }
}