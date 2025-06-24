using CarRentalApplication.DB.Models;
using CarRentalApplication.DB.Models.Cars;

namespace CarRentalApplication.DB.Interfaces.Repositories;

public interface ICarRepository
{
    Task<Car?> GetByIdAsync(int id);
    Task<IEnumerable<Car>> GetAllAsync();
    Task<IEnumerable<Car>> GetFilteredAsync(CarFilteringQueryParameters query);
    Task<Car?> AddAsync(Car car);
    Task<bool> UpdateAsync(Car car);
    Task<bool> DeleteAsync(int id);
}