using GraphPersona.Api.Models;
using GraphPersona.Api.Services;

namespace GraphPersona.Api.GraphQL.Queries;

public class PersonQuery
{
    public async Task<List<Person>> GetPeople([Service] PersonService service)
        => await service.GetAllAsync();

    public async Task<Person?> GetPersonById(Guid id, [Service] PersonService service)
        => await service.GetByIdAsync(id);
}
