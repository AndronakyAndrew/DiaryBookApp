using DiaryApp;
using Microsoft.EntityFrameworkCore;

namespace DiaryApp
{
    public class DiaryContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Note> Notes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=192.168.100.16;Port=5433;Database=Diary;Username=postgres;Password=1602");
        }
    }
}
