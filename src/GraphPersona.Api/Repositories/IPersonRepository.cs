using GraphPersona.Api.GraphQL.Inputs;
using GraphPersona.Api.Models;

namespace GraphPersona.Api.Repositories;

public interface IPersonRepository
{
    Task<List<Person>> GetAllAsync();
    Task<Person?> GetByIdAsync(Guid id);
    Task<Person> AddAsync(Person person);
    Task<Person> UpdateAsync(Person person);
    Task<bool> DeleteAsync(Guid id);
}
