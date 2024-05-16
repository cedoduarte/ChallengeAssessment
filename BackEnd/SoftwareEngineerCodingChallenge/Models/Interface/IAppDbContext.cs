using Microsoft.EntityFrameworkCore;

namespace SoftwareEngineerCodingChallenge.Models.Interface
{
    public interface IAppDbContext
    {
        DbSet<Customer> Customers { get; set; }
    }
}
