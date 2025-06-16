namespace CarRentalApplication.DB.Models.Users;

public class UserFilteringQueryParameters
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string? City { get; set; }
    public string? Country { get; set; }
    public DateTime? MinDateOfBirth { get; set; }
    public DateTime? MaxDateOfBirth { get; set; }


    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}