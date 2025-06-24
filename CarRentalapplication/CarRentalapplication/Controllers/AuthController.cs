using CarRentalApplication.DB.Interfaces.Services;
using CarRentalApplication.DB.Models.Authentications;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalApplication.Controllers;

public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] AuthLoginRequest request)
    {
        var token = await _authService.LoginAsync(request.Email, request.Password);
        return Ok(new { token });
    }
}