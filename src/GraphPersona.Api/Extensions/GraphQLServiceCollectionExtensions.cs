using GraphPersona.Api.GraphQL.Mutations;
using GraphPersona.Api.GraphQL.Queries;
using GraphPersona.Api.GraphQL.Types;
using GraphPersona.Api.GraphQL.Types.Add;
using GraphPersona.Infrastructure.Data;

namespace GraphPersona.Api.Extensions;

public static class GraphQlServiceCollectionExtensions
{
    public static IServiceCollection AddGraphPersonaGraphQl(this IServiceCollection services)
    {
        services
            .AddGraphQLServer()
            .AddFiltering()
            .AddSorting()
            .AddProjections()
            .DisableIntrospection(false)
            .AddQueryType<PersonQuery>()
            .AddMutationType<PersonMutation>()
            .AddType<PersonType>()
            .AddType<AddressType>()
            .AddType<ContactType>()
            .AddType<AddPersonInputType>()
            .AddType<AddAddressInputType>()
            .AddType<AddContactInputType>()
            .AddType<ContactTypeEnumType>()
            .RegisterDbContextFactory<GraphPersonaDbContext>();

        return services;
    }
}
