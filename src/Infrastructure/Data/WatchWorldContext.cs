using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.Data
{
    public class WatchWorldContext : DbContext
    {
        public WatchWorldContext(DbContextOptions<WatchWorldContext> options) : base(options)
        {

        }

        public DbSet<Brand> Brands { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            //oluşturacağımız  konfigirasyon dosyalarını implementasyonunu sağlıyor.
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }
    }
}
