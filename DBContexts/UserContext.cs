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
            optionsBuilder.UseNpgsql(Config.UsersBDConnection);
        }
    }
}
