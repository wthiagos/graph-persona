using GraphPersona.Api.GraphQL.Inputs;
using GraphPersona.Api.Models;
using GraphPersona.Api.Services;

namespace GraphPersona.Api.GraphQL.Mutations;

public class PersonMutation
{
    public async Task<Person> AddPerson(AddPersonInput input, [Service] PersonService service)
        => await service.AddAsync(input);

    public async Task<bool> DeletePerson(Guid id, [Service] PersonService service)
        => await service.DeleteAsync(id);
    
    public async Task<Person?> UpdatePerson(Guid id, Person input, [Service] PersonService service)
        => await service.UpdateAsync(id, input);
}
