using System.ComponentModel.DataAnnotations;

namespace CarRentalApplication.DB.Models;

public class Booking
{
    [Key]
    public int Id { get; set; }

    public int UserId { get; set; }   
    public int CarId { get; set; }

    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public User User { get; set; }
    public Car Car { get; set; }
}