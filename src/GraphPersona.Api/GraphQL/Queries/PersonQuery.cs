using GraphPersona.Application.DTOs.Person;
using GraphPersona.Application.Services;

namespace GraphPersona.Api.GraphQL.Queries;

public class PersonQuery
{
    public async Task<IEnumerable<PersonDto>> GetPeople([Service] PersonService service)
        => await service.GetAllAsync();

    public async Task<PersonDto?> GetPersonById(Guid id, [Service] PersonService service)
        => await service.GetByIdAsync(id);
}
