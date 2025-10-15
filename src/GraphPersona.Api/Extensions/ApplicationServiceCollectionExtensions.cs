using FluentValidation;
using GraphPersona.Application.Validators;
using GraphPersona.Domain.Enums;
using GraphPersona.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GraphPersona.Api.Extensions;

public static class ApplicationServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services.AddDbContext<GraphPersonaDbContext>(options =>
        {
            options.UseNpgsql(
                configuration.GetConnectionString("Default"),
                o => o.MapEnum<ContactTypeEnum>("contact_type"));
        });

        services.AddGraphPersonaGraphQl();
        services.AddGraphPersonaServices();
        services.AddValidatorsFromAssemblyContaining<CreatePersonInputValidator>();

        services.AddCors(options =>
        {
            options.AddDefaultPolicy(policy =>
            {
                policy.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });
        });

        return services;
    }
}