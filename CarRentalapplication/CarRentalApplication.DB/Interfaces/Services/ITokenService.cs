using CarRentalApplication.DB.Models;
using CarRentalApplication.DB.Models.Authentications;

namespace CarRentalApplication.DB.Interfaces.Services;

public interface ITokenService
{
    string GenerateToken(AuthGenerateTokenRequest user);
}