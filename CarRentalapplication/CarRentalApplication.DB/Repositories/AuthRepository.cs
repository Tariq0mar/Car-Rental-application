using CarRentalApplication.DB.Contexts;
using CarRentalApplication.DB.Interfaces.Repositories;

namespace CarRentalApplication.DB.Repositories;

public class AuthRepository : IAuthRepository
{
    private readonly CarRentalApplicationDbContext _context;

    public AuthRepository(CarRentalApplicationDbContext context)
    {
        _context = context;
    }

    public Task<bool> LoginAsync(string email, string password)
    {
        throw new NotImplementedException();
    }
}