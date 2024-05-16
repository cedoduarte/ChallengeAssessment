using Microsoft.EntityFrameworkCore;
using SoftwareEngineerCodingChallenge.Models.Interface;

namespace SoftwareEngineerCodingChallenge.Models
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(IAppDbContext).Assembly);
        }
    }
}
