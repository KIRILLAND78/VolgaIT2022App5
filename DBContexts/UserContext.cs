using Microsoft.EntityFrameworkCore;
using VolgaIT2022App5.Models;

namespace VolgaIT2022App5.DBContexts
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public UserContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=127.0.0.1;Port=5432;Database=users_db;Username=postgres;Password=password;");
        }
    }
}
