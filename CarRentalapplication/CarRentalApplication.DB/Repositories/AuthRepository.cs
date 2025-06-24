using CarRentalApplication.DB.Contexts;
using CarRentalApplication.DB.Interfaces.Repositories;
using CarRentalApplication.DB.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRentalApplication.DB.Repositories;

public class AuthRepository : IAuthRepository
{
    private readonly CarRentalApplicationDbContext _context;

    public AuthRepository(CarRentalApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<User?> LoginAsync(string email, string password)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

        if (user is null)
        {
            return null;
        }

        if (user.Password == password)
        {
            return user;
        }
        else
        {
            return null;
        }
    }
}