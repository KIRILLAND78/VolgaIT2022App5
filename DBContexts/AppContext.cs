using Microsoft.EntityFrameworkCore;
using VolgaIT2022App5.Models;

namespace VolgaIT2022App5.DBContexts
{
    public class AppsContext : DbContext
    {
        public DbSet<App> Apps { get; set; }
        public AppsContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(Config.Configuration.GetConnectionString("AppsDBConnection"));
        }
    }
}
