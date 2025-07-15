using Microsoft.EntityFrameworkCore;
using FootballAcademyAPI.Models;

namespace FootballAcademyAPI.Data
{
    public class FootballAcademyDbContext(DbContextOptions<FootballAcademyDbContext> options) 
        : DbContext(options)
    {
        public DbSet<Player> Players => Set<Player>();
        public DbSet<Subscription> Subscriptions => Set<Subscription>();
        public DbSet<Employee> Employees => Set<Employee>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Subscription>()
                .Property(s => s.Amount)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Salary)
                .HasPrecision(10, 2);
        }
    }
}