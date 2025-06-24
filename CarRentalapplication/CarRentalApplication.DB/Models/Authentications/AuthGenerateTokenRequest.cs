namespace CarRentalApplication.DB.Models.Authentications;

public class AuthGenerateTokenRequest
{
    public int Id { get; init; }
    public string Email { get; set; }
}