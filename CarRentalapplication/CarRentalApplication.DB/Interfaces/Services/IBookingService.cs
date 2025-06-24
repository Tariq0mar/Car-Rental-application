using CarRentalApplication.DB.Models;
using CarRentalApplication.DB.Models.Bookings;

namespace CarRentalApplication.DB.Interfaces.Services;

public interface IBookingService
{
    Task<Booking> GetByIdAsync(int id);
    Task<IEnumerable<Booking>> GetAllAsync();
    Task<IEnumerable<Booking>> GetFilteredAsync(BookingFilteringQueryParameters query);
    Task<Booking> AddAsync(Booking booking);
    Task UpdateAsync(Booking booking);
    Task DeleteAsync(int id);
}