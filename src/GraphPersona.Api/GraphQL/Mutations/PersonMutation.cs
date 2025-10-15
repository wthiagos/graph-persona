using GraphPersona.Api.GraphQL.Inputs.Add;
using GraphPersona.Api.GraphQL.Inputs.Update;
using GraphPersona.Application.DTOs.Person;
using GraphPersona.Application.Services;

namespace GraphPersona.Api.GraphQL.Mutations;

public class PersonMutation
{
    public async Task<PersonDto> AddPerson(AddPersonInput input, [Service] PersonService service)
        => await service.AddAsync(input.ToDto());

    public async Task<bool> DeletePerson(Guid id, [Service] PersonService service)
        => await service.DeleteAsync(id);
    
    public async Task<PersonDto?> UpdatePerson(Guid id, UpdatePersonInput input, [Service] PersonService service)
        => await service.UpdateAsync(id, input.ToDto());
}
