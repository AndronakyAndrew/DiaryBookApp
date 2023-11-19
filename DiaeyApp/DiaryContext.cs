using Microsoft.EntityFrameworkCore;

namespace DiaeyApp
{
    public class DiaryContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Task> Tasks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=192.168.100.16;Port=5433;Database=Diary;Username=postgres;Password=1602");
        }

    }
}
