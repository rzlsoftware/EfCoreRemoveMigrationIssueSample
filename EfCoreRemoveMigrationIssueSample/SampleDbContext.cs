using Microsoft.EntityFrameworkCore;

namespace EfCoreRemoveMigrationIssueSample
{
    public class SampleDbContext : DbContext
    {
        public DbSet<Person> People { get; set; }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer("Server=localhost;Database=EfCoreRemoveMigrationIssueSample;Integrated Security=True");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>(b =>
            {
                b.HasDiscriminator<char>("Type")
                    .HasValue<Customer>('C');
            });
        }
    }
}
