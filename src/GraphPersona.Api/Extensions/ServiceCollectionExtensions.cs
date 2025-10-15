using GraphPersona.Application.Services;
using GraphPersona.Domain.Interfaces;
using GraphPersona.Infrastructure.Repositories;

namespace GraphPersona.Api.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddGraphPersonaServices(this IServiceCollection services)
    {
        services.AddScoped<IPersonRepository, PersonRepository>();
        services.AddScoped<PersonService>();
        return services;
    }
}