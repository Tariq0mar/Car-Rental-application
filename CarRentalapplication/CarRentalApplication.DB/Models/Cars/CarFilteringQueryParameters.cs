namespace CarRentalApplication.DB.Models.Cars;

public class CarFilteringQueryParameters
{
    public string? Model { get; set; }
    public decimal? MinPrice { get; set; }
    public decimal? MaxPrice { get; set; }

    
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}