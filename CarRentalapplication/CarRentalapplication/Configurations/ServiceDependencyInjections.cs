using CarRentalApplication.DB.Interfaces.Services;
using CarRentalApplication.DB.Services;

namespace CarRentalApplication.Configurations;

public static class ServiceDependencyInjections
{
    public static IServiceCollection AddRepositoryDependencies(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<ICarService, CarService>();
        services.AddScoped<IBookingService, BookingService>();

        return services;
    }
}