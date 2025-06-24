using AutoMapper;
using CarRentalApplication.DB.Interfaces.Services;
using CarRentalApplication.DB.Models;
using CarRentalApplication.DB.Models.Bookings;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalApplication.Controllers;

[ApiController]
[Route("api/Booking")]
public class BookingController : ControllerBase
{
    private readonly IBookingService _bookingService;
    private readonly IMapper _mapper;

    public BookingController(IBookingService bookingService, IMapper mapper)
    {
        _bookingService = bookingService ?? throw new ArgumentException(nameof(bookingService));
        _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
    }


    [HttpGet]
    public async Task<ActionResult> GetAll()
    {
        var bookings = await _bookingService.GetAllAsync();
        return Ok(bookings);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetById(int id)
    {
        var booking = await _bookingService.GetByIdAsync(id);
        return Ok(booking);
    }

    [HttpGet("booking-search")]
    public async Task<ActionResult> GetFiltered([FromBody] BookingFilteringQueryParameters query)
    {
        var filteredBookings = await _bookingService.GetFilteredAsync(query);
        return Ok(filteredBookings);
    }

    [HttpPost]
    public async Task<ActionResult> Create([FromBody] BookingBodyRequest booking)
    {
        var newBooking = _mapper.Map<Booking>(booking);

        await _bookingService.AddAsync(newBooking);
        return Ok(newBooking);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, [FromBody] BookingBodyRequest booking)
    {
        var newBooking = _mapper.Map<Booking>(booking);
        newBooking.Id = id;

        await _bookingService.UpdateAsync(newBooking);
        return Ok(newBooking);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _bookingService.DeleteAsync(id);
        return Ok($"Booking with Id: {id} has been deleted");
    }
}