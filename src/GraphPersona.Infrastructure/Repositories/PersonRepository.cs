using GraphPersona.Domain.Entities;
using GraphPersona.Domain.Interfaces;
using GraphPersona.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GraphPersona.Infrastructure.Repositories;

public class PersonRepository(GraphPersonaDbContext db) : IPersonRepository
{
    public async Task<IEnumerable<Person>> GetAllAsync()
        => await db.People.Include(p => p.Address).Include(p => p.Contacts).ToListAsync();

    public async Task<Person?> GetByIdAsync(Guid id)
        => await db.People.Include(p => p.Address).Include(p => p.Contacts)
            .FirstOrDefaultAsync(p => p.Id == id);

    public async Task<Person> AddAsync(Person person)
    {
        db.People.Add(person);
        await db.SaveChangesAsync();
        return person;
    }
    
    public async Task<Person> UpdateAsync(Person person)
    {
        db.People.Update(person);
        await db.SaveChangesAsync();
        return person;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var person = await db.People.FindAsync(id);
        if (person is null) return false;

        db.People.Remove(person);
        await db.SaveChangesAsync();
        return true;
    }
}
