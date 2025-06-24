using CarRentalApplication.DB.Contexts;
using CarRentalApplication.DB.Interfaces.Repositories;
using CarRentalApplication.DB.Models;
using CarRentalApplication.DB.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace CarRentalApplication.DB.Repositories;

public class UserRepository : IUserRepository
{
    private readonly CarRentalApplicationDbContext _context;

    public UserRepository(CarRentalApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<User?> GetByIdAsync(int id)
    {
        return await _context.Users.FindAsync(id);
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<IEnumerable<User>> GetFilteredAsync(UserFilteringQueryParameters query)
    {
        var users = _context.Users.AsQueryable();

        if (!string.IsNullOrWhiteSpace(query.FirstName))
            users = users.Where(u => u.FirstName.Contains(query.FirstName));

        if (!string.IsNullOrWhiteSpace(query.LastName))
            users = users.Where(u => u.LastName.Contains(query.LastName));

        if (!string.IsNullOrWhiteSpace(query.Email))
            users = users.Where(u => u.Email.Contains(query.Email));

        if (!string.IsNullOrWhiteSpace(query.PhoneNumber))
            users = users.Where(u => u.PhoneNumber.Contains(query.PhoneNumber));

        if (!string.IsNullOrWhiteSpace(query.City))
            users = users.Where(u => u.City.Contains(query.City));

        if (!string.IsNullOrWhiteSpace(query.Country))
            users = users.Where(u => u.Country.Contains(query.Country));

        if (query.MinDateOfBirth.HasValue)
            users = users.Where(u => u.DateOfBirth >= query.MinDateOfBirth.Value);

        if (query.MaxDateOfBirth.HasValue)
            users = users.Where(u => u.DateOfBirth <= query.MaxDateOfBirth.Value);

        var skip = (query.PageNumber - 1) * query.PageSize;
        users = users.Skip(skip).Take(query.PageSize);

        return await users.ToListAsync();
    }

    public async Task<User?> AddAsync(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();

        return user;
    }

    public async Task<bool> UpdateAsync(User user)
    {
        var existingUser = await _context.Users.FindAsync(user.Id);
        if (existingUser is null)
            return false;

        _context.Entry(existingUser).CurrentValues.SetValues(user);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user is null)
            return false;

        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
        return true;
    }
}