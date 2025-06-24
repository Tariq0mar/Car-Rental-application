using CarRentalApplication.DB.Models;
using CarRentalApplication.DB.Models.Cars;

namespace CarRentalApplication.DB.Interfaces.Services;

public interface ICarService
{
    Task<Car> GetByIdAsync(int id);
    Task<IEnumerable<Car>> GetAllAsync();
    Task<IEnumerable<Car>> GetFilteredAsync(CarFilteringQueryParameters query);
    Task<Car> AddAsync(Car car);
    Task UpdateAsync(Car car);
    Task DeleteAsync(int id);
}