namespace CarRentalApplication.DB.Models.Cars;

public class CarBodyRequest
{
    public string Model { get; set; }
    public decimal PricePerDay { get; set; }
    public bool IsAvailable { get; set; }
}