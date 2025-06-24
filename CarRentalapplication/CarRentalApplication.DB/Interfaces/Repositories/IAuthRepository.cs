namespace CarRentalApplication.DB.Interfaces.Repositories;

public interface IAuthRepository
{
    Task<bool> LoginAsync(string email, string password);
}