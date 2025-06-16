using CarRentalApplication.DB.Models;
using CarRentalApplication.DB.Models.Bookings;

namespace CarRentalApplication.DB.Interfaces.Repositories;

public interface IBookingRepository
{
    Task<Booking?> GetByIdAsync(int id);
    Task<IEnumerable<Booking>> GetAllAsync();
    Task<IEnumerable<Booking>> GetFilteredAsync(BookingFilteringQueryParameters query);
    Task AddAsync(Booking booking);
    Task<bool> UpdateAsync(Booking booking);
    Task<bool> DeleteAsync(int id);
}