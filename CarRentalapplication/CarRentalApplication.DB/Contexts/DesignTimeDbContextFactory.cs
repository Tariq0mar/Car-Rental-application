using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CarRentalApplication.DB.Contexts;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<CarRentalApplicationDbContext>

{
    public CarRentalApplicationDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<CarRentalApplicationDbContext>();

        optionsBuilder.UseSqlServer("Server=.;Database=CarRentalDb;Trusted_Connection=True;TrustServerCertificate=True");

        return new CarRentalApplicationDbContext(optionsBuilder.Options);
    }
}