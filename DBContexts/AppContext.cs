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
            optionsBuilder.UseNpgsql("Host=127.0.0.1;Port=5432;Database=apps_db;Username=postgres;Password=password;");
        }
    }
}
