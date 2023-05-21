using CityManagerApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.Extensions.Options;

namespace CityManagerApi.Data
{
    public class DataContext : DbContext
    {
      
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<City> Cities { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<CityImage> CityImages { get; set; }
    }
}
