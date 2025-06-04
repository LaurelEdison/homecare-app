using HomeCareApp.Application.Service.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace HomeCareApp.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<UserService>();
        services.AddScoped<BookingService>();
        services.AddScoped<CareRequestService>();
        services.AddScoped<ReviewService>();
        return services;
    }
}