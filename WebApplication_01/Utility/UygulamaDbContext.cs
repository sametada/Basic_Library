using Microsoft.EntityFrameworkCore;
using WebApplication_01.Models;

namespace WebApplication_01.Utility
{
    public class UygulamaDbContext : DbContext
    {
        public UygulamaDbContext(DbContextOptions<UygulamaDbContext> options):base(options) {   }

        public DbSet<KitapTuru> KitapTurleri { get; set; }

    }
}
