using CarRentalApplication.DB.Contexts;
using CarRentalApplication.DB.Interfaces.Repositories;
using CarRentalApplication.DB.Models;
using CarRentalApplication.DB.Models.Bookings;
using Microsoft.EntityFrameworkCore;

namespace CarRentalApplication.DB.Repositories;

public class BookingRepository : IBookingRepository
{
    private readonly CarRentalApplicationDbContext _context;

    public BookingRepository(CarRentalApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Booking?> GetByIdAsync(int id)
    {
        return await _context.Bookings.FindAsync(id);
    }

    public async Task<IEnumerable<Booking>> GetAllAsync()
    {
        return await _context.Bookings.ToListAsync();
    }

    public async Task<IEnumerable<Booking>> GetFilteredAsync(BookingFilteringQueryParameters query)
    {
        var bookings = _context.Bookings.AsQueryable();

        if (query.UserId.HasValue)
            bookings = bookings.Where(b => b.UserId == query.UserId);

        if (query.CarId.HasValue)
            bookings = bookings.Where(b => b.CarId == query.CarId);

        if (query.StartDateFrom.HasValue)
            bookings = bookings.Where(b => b.StartDate >= query.StartDateFrom.Value);

        if (query.StartDateTo.HasValue)
            bookings = bookings.Where(b => b.StartDate <= query.StartDateTo.Value);

        if (query.EndDateFrom.HasValue)
            bookings = bookings.Where(b => b.EndDate >= query.EndDateFrom.Value);

        if (query.EndDateTo.HasValue)
            bookings = bookings.Where(b => b.EndDate <= query.EndDateTo.Value);


        var skip = (query.PageNumber - 1) * query.PageSize;
        bookings = bookings.Skip(skip).Take(query.PageSize);

        return await bookings.ToListAsync();
    }

    public async Task<Booking?> AddAsync(Booking booking)
    {
        await _context.Bookings.AddAsync(booking);
        await _context.SaveChangesAsync();

        return booking;
    }

    public async Task<bool> UpdateAsync(Booking booking)
    {
        var existingBooking = await _context.Bookings.FindAsync(booking);
        if (existingBooking is null)
            return false;

        _context.Entry(existingBooking).CurrentValues.SetValues(booking);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var booking = await _context.Bookings.FindAsync(id);
        if (booking is null)
            return false;

        _context.Bookings.Remove(booking);
        await _context.SaveChangesAsync();
        return true;
    }
}