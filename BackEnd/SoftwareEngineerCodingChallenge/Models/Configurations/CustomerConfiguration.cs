using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace SoftwareEngineerCodingChallenge.Models.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(a => a.FirstName).IsRequired().HasColumnType("VARCHAR(256)");
            builder.Property(a => a.LastName).IsRequired().HasColumnType("VARCHAR(256)");
            builder.Property(a => a.Email).IsRequired().HasColumnType("VARCHAR(256)");
            builder.Property(a => a.CreatedDateTime).IsRequired().HasColumnType("DATETIME");
            builder.Property(a => a.LastUpdatedDateTime).IsRequired().HasColumnType("DATETIME");            
        }
    }
}