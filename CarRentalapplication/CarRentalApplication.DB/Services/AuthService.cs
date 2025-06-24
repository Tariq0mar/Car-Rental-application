using CarRentalApplication.DB.Interfaces.Repositories;
using CarRentalApplication.DB.Interfaces.Services;

namespace CarRentalApplication.DB.Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;

    public AuthService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public Task<string> LoginAsync(string email, string password)
    {
        throw new Exception();
    }
}