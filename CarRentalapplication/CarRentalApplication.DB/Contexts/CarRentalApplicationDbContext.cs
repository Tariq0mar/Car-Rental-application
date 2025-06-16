using CarRentalApplication.DB.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRentalApplication.DB.Contexts;

public class CarRentalApplicationDbContext : DbContext
{
    public DbSet<Car> Cars { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Booking> Bookings { get; set; }
}