using CarRentalApplication.DB.Exceptions;
using CarRentalApplication.DB.Interfaces.Repositories;
using CarRentalApplication.DB.Interfaces.Services;
using CarRentalApplication.DB.Models;
using CarRentalApplication.DB.Models.Bookings;

namespace CarRentalApplication.DB.Services;

public class BookingService : IBookingService
{
    private readonly IBookingRepository _bookingRepository;

    public BookingService(IBookingRepository bookingRepository)
    {
        _bookingRepository = bookingRepository;
    }

    public async Task<Booking> GetByIdAsync(int id)
    {
        var booking = await _bookingRepository.GetByIdAsync(id);

        if (booking is null)
        {
            throw new NotFoundException<Booking>($"{id}");
        }

        return booking;
    }

    public async Task<IEnumerable<Booking>> GetAllAsync()
    {
        return await _bookingRepository.GetAllAsync();
    }

    public async Task<IEnumerable<Booking>> GetFilteredAsync(BookingFilteringQueryParameters query)
    {
        return await _bookingRepository.GetFilteredAsync(query);
    }

    public async Task<Booking> AddAsync(Booking booking)
    {
        var AddedBooking = await _bookingRepository.AddAsync(booking);

        if (AddedBooking is null)
        {
            throw new Exception("the booking have not been added");
        }

        return AddedBooking;
    }

    public async Task UpdateAsync(Booking booking)
    {
        var state = await _bookingRepository.UpdateAsync(booking);

        if (state is false)
        {
            throw new NotFoundException<Booking>($"{booking.Id}");
        }
    }
    public async Task DeleteAsync(int id)
    {
        var state = await _bookingRepository.DeleteAsync(id);

        if (state is false)
        {
            throw new NotFoundException<Booking>($"{id}");
        }
    }
}