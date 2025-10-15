using GraphPersona.Domain.Entities;

namespace GraphPersona.Domain.Interfaces;

public interface IPersonRepository
{
    Task<IEnumerable<Person>> GetAllAsync();
    Task<Person?> GetByIdAsync(Guid id);
    Task<Person> AddAsync(Person person);
    Task<Person> UpdateAsync(Person person);
    Task<bool> DeleteAsync(Guid id);
}
