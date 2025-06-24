using CarRentalApplication.DB.Contexts;
using CarRentalApplication.DB.Interfaces.Repositories;
using CarRentalApplication.DB.Models;
using CarRentalApplication.DB.Models.Cars;
using Microsoft.EntityFrameworkCore;

public class CarRepository : ICarRepository
{
    private readonly CarRentalApplicationDbContext _context;

    public CarRepository(CarRentalApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Car?> GetByIdAsync(int id)
    {
        return await _context.Cars.FindAsync(id);
    }
    public async Task<IEnumerable<Car>> GetAllAsync()
    {
        return await _context.Cars.ToListAsync();
    }

    public async Task<IEnumerable<Car>> GetFilteredAsync(CarFilteringQueryParameters query)
    {
        var cars = _context.Cars.AsQueryable();

        if (!string.IsNullOrWhiteSpace(query.Model))
            cars = cars.Where(c => c.Model == query.Model);

        if (query.MinPrice.HasValue)
            cars = cars.Where(c => c.PricePerDay >= query.MinPrice.Value);

        if (query.MaxPrice.HasValue)
            cars = cars.Where(c => c.PricePerDay <= query.MaxPrice.Value);

        var skip = (query.PageNumber - 1) * query.PageSize;
        cars = cars.Skip(skip).Take(query.PageSize);

        return await cars.ToListAsync();
    }
    public async Task<Car?> AddAsync(Car car)
    {
        await _context.Cars.AddAsync(car);
        await _context.SaveChangesAsync();

        return car;
    }
    public async Task<bool> UpdateAsync(Car car)
    {
        var existingCar = await _context.Cars.FindAsync(car.Id);
        if (existingCar is null)
            return false;

        _context.Entry(existingCar).CurrentValues.SetValues(car);
        await _context.SaveChangesAsync();
        return true;
    }
    public async Task<bool> DeleteAsync(int id)
    {
        var car = await _context.Cars.FindAsync(id);
        if (car is null)
            return false;

        _context.Cars.Remove(car);
        await _context.SaveChangesAsync();
        return true;
    }
}