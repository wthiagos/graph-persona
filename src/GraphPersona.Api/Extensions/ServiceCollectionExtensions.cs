using GraphPersona.Api.Repositories;
using GraphPersona.Api.Services;

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
