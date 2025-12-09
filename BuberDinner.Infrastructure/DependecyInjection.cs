
using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Infrastructure.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace BuberDinner.Infastructure;

public static class DependecyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        return services;
    }
}
