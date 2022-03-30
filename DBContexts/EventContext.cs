using Microsoft.EntityFrameworkCore;
using VolgaIT2022App5.Models;

namespace VolgaIT2022App5.DBContexts
{
    public class EventContext : DbContext
    {
        public DbSet<Event> Events { get; set; }
        public EventContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(Config.EventsBDConnection);
        }
    }
}
