using AutoMapper;
using CarRentalApplication.DB.Interfaces.Services;
using CarRentalApplication.DB.Models;
using CarRentalApplication.DB.Models.Cars;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalApplication.Controllers;

[ApiController]
[Route("api/Booking")]
public class CarController : ControllerBase
{
    private readonly ICarService _carService;
    private readonly IMapper _mapper;

    public CarController(ICarService carService, IMapper mapper)
    {
        _carService = carService ?? throw new ArgumentException(nameof(carService));
        _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
    }


    [HttpGet]
    public async Task<ActionResult> GetAll()
    {
        var cars = await _carService.GetAllAsync();
        return Ok(cars);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetById(int id)
    {
        var car = await _carService.GetByIdAsync(id);
        return Ok(car);
    }

    [HttpGet("filter")]
    public async Task<ActionResult> GetFiltered([FromBody] CarFilteringQueryParameters query)
    {
        var filteredCars = await _carService.GetFilteredAsync(query);
        return Ok(filteredCars);
    }

    [HttpPost]
    public async Task<ActionResult> Create([FromBody] CarBodyRequest car)
    {
        var newCar = _mapper.Map<Car>(car);

        await _carService.AddAsync(newCar);
        return Ok(newCar);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, [FromBody] CarBodyRequest car)
    {
        var newCar = _mapper.Map<Car>(car);
        newCar.Id = id;

        await _carService.UpdateAsync(newCar);
        return Ok(newCar);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _carService.DeleteAsync(id);
        return Ok($"Car with Id: {id} has been deleted");
    }
}