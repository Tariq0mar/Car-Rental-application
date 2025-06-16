using CarRentalApplication.DB.Models;
using CarRentalApplication.DB.Models.Users;

namespace CarRentalApplication.DB.Interfaces.Services;

public interface IUserService
{
    Task<User?> GetByIdAsync(int id);
    Task<IEnumerable<User>> GetAllAsync();
    Task<IEnumerable<User>> GetFilteredAsync(UserFilteringQueryParameters query);
    Task AddAsync(User user);
    Task UpdateAsync(User user);
    Task DeleteAsync(int id);
    Task Login(string email, int id);
}