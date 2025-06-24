namespace CarRentalApplication.DB.Models.Bookings;

public class BookingBodyRequest
{ 
    public int UserId { get; init; }
    public int CarId { get; init; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}