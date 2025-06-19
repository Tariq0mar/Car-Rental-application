using CarRentalApplication.DB.Exceptions;
using CarRentalApplication.DB.Interfaces.Repositories;
using CarRentalApplication.DB.Interfaces.Services;
using CarRentalApplication.DB.Models;
using CarRentalApplication.DB.Models.Cars;

namespace CarRentalApplication.DB.Services;

public class CarService : ICarService
{
    private readonly ICarRepository _carRepository;

    public CarService(ICarRepository carRepository)
    {
        _carRepository = carRepository;
    }

    public async Task<Car?> GetByIdAsync(int id)
    {
        var car = await _carRepository.GetByIdAsync(id);

        if (car is null)
        {
            throw new NotFoundException<Car>(id);
        }

        return car;
    }

    public async Task<IEnumerable<Car>> GetAllAsync()
    {
        return await _carRepository.GetAllAsync();
    }

    public async Task<IEnumerable<Car>> GetFilteredAsync(CarFilteringQueryParameters query)
    {
        return await _carRepository.GetFilteredAsync(query);
    }

    public async Task AddAsync(Car car)
    {
        await _carRepository.AddAsync(car);
    }

    public async Task UpdateAsync(Car car)
    {
        var state = await _carRepository.UpdateAsync(car);

        if (state is false)
        {
            throw new NotFoundException<Car>(car.Id);
        }
    }
    public async Task DeleteAsync(int id)
    {
        var state = await _carRepository.DeleteAsync(id);

        if (state is false)
        {
            throw new NotFoundException<Car>(id);
        }
    }
}