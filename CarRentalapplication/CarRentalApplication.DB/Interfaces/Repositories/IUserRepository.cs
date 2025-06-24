using CarRentalApplication.DB.Models;
using CarRentalApplication.DB.Models.Users;

namespace CarRentalApplication.DB.Interfaces.Repositories;

public interface IUserRepository
{
    Task<User?> GetByIdAsync(int id);
    Task<IEnumerable<User>> GetAllAsync();
    Task<IEnumerable<User>> GetFilteredAsync(UserFilteringQueryParameters query);
    Task<User?> AddAsync(User user);
    Task<bool> UpdateAsync(User user);
    Task<bool> DeleteAsync(int id);
}