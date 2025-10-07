using GraphPersona.Api.Data;
using GraphPersona.Api.GraphQL.Mutations;
using GraphPersona.Api.GraphQL.Queries;
using GraphPersona.Api.GraphQL.Types;

namespace GraphPersona.Api.Extensions;

public static class GraphQLServiceCollectionExtensions
{
    public static IServiceCollection AddGraphPersonaGraphQL(this IServiceCollection services)
    {
        services
            .AddGraphQLServer()
            .AddFiltering()
            .AddSorting()
            .AddProjections()
            .RegisterDbContextFactory<GraphPersonaDbContext>()
            .AddQueryType<PersonQuery>()
            .AddMutationType<PersonMutation>()
            .AddType<PersonType>()
            .AddType<AddressType>()
            .AddType<ContactType>()
            .AddType<AddPersonInputType>()
            .AddType<AddAddressInputType>()
            .AddType<AddContactInputType>()
            .AddType<ContactTypeEnumType>()
            .AddFiltering()
            .AddSorting()
            .AddProjections()
            .RegisterDbContextFactory<GraphPersonaDbContext>();

        return services;
    }
}
