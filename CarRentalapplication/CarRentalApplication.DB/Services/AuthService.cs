using CarRentalApplication.DB.Exceptions;
using CarRentalApplication.DB.Interfaces.Repositories;
using CarRentalApplication.DB.Interfaces.Services;
using CarRentalApplication.DB.Models;
using CarRentalApplication.DB.Models.Authentications;

namespace CarRentalApplication.DB.Services;

public class AuthService : IAuthService
{
    private readonly IAuthRepository _authRepository;
    private readonly ITokenService _tokenService;

    public AuthService(IAuthRepository authRepository,
        ITokenService tokenService)
    {
        _authRepository = authRepository;
        _tokenService = tokenService;
    }

    public async Task<string> LoginAsync(string email, string password)
    {
        var user = await _authRepository.LoginAsync(email, password);

        if (user is null)
        {
            throw new NotFoundException<User>($"{email}");
        }

        var authGenerateTokenRequest = new AuthGenerateTokenRequest
        {
            Id = user.Id,
            Email = email
        };

        var token = _tokenService.GenerateToken(authGenerateTokenRequest);

        return token;
    }
}