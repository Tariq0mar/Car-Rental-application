namespace CarRentalApplication.DB.Models.Bookings;

public class BookingFilteringQueryParameters
{
    public int? UserId { get; init; }
    public int? CarId { get; init; }
    public DateTime? StartDateFrom { get; set; }
    public DateTime? StartDateTo { get; set; }
    public DateTime? EndDateFrom { get; set; }
    public DateTime? EndDateTo { get; set; }
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}