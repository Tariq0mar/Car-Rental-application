using CarRentalApplication.DB.Models;

namespace CarRentalApplication.DB.Interfaces.Repositories;

public interface IAuthRepository
{
    Task<User?> LoginAsync(string email, string password);
}