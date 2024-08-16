using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) {}

        public DbSet<Group> Groups { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<GroupOutageResult> GroupOutageResults { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GroupOutageResult>()
                .HasNoKey()
                .ToView(null); 
        }
    }
}
