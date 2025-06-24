using CarRentalApplication.DB.Interfaces.Repositories;
using CarRentalApplication.DB.Repositories;

namespace CarRentalApplication.Configurations;

public static class RepositoryDependencyInjections
{
    public static IServiceCollection AddRepositoryDependencies(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IAuthRepository, AuthRepository>();
        services.AddScoped<ICarRepository, CarRepository>();
        services.AddScoped<IBookingRepository, BookingRepository>();

        return services;
    }
}