using CarRentalApplication.DB.Exceptions;
using CarRentalApplication.DB.Interfaces.Repositories;
using CarRentalApplication.DB.Interfaces.Services;
using CarRentalApplication.DB.Models;
using CarRentalApplication.DB.Models.Users;

namespace CarRentalApplication.DB.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> GetByIdAsync(int id)
    {
        var user = await _userRepository.GetByIdAsync(id);

        if (user is null)
        {
            throw new NotFoundException<User>(id);
        }

        return user;
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return await _userRepository.GetAllAsync();
    }

    public async Task<IEnumerable<User>> GetFilteredAsync(UserFilteringQueryParameters query)
    {
        return await _userRepository.GetFilteredAsync(query);
    }

    public async Task<User> AddAsync(User user)
    {
        var AddedUser = await _userRepository.AddAsync(user);

        if (AddedUser is null)
        {
            throw new Exception("the user have not been added");
        }

        return AddedUser;
    }

    public async Task UpdateAsync(User user)
    {
        var state = await _userRepository.UpdateAsync(user);

        if (state is false)
        {
            throw new NotFoundException<User>(user.Id);
        }
    }
    public async Task DeleteAsync(int id)
    {
        var state = await _userRepository.DeleteAsync(id);

        if (state is false)
        {
            throw new NotFoundException<User>(id);
        }
    }
}