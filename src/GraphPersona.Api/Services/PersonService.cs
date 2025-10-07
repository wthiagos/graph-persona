using GraphPersona.Api.GraphQL.Inputs;
using GraphPersona.Api.Models;
using GraphPersona.Api.Repositories;

namespace GraphPersona.Api.Services;

public class PersonService(IPersonRepository repo)
{
    private readonly IPersonRepository _repo = repo;

    public async Task<List<Person>> GetAllAsync()
        => await _repo.GetAllAsync();

    public async Task<Person?> GetByIdAsync(Guid id)
        => await _repo.GetByIdAsync(id);

    public async Task<Person> AddAsync(AddPersonInput person)
    {
        if (person.BirthDate > DateOnly.FromDateTime(DateTime.Today))
        {
            throw new GraphQLException(ErrorBuilder.New()
                .SetMessage("Birth date cannot be in the future.")
                .SetCode("INVALID_BIRTHDATE")
                .Build());
        }
        
        return await _repo.AddAsync(person.ToEntity());
    }

    public async Task<Person?> UpdateAsync(Guid id, Person updated)
    {
        var person = await _repo.GetByIdAsync(id);
        if (person is null) return null;

        person.FullName = updated.FullName;
        person.BirthDate = updated.BirthDate;
        person.AddressId = updated.AddressId;
        person.Contacts = updated.Contacts;

        return await _repo.UpdateAsync(person);
    }

    public async Task<bool> DeleteAsync(Guid id)
        => await _repo.DeleteAsync(id);
}

