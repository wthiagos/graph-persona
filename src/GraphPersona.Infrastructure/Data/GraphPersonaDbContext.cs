using GraphPersona.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GraphPersona.Infrastructure.Data;

public class GraphPersonaDbContext(DbContextOptions<GraphPersonaDbContext> options) : DbContext(options)
{
    public DbSet<Person> People => Set<Person>();
    public DbSet<Contact> Contacts => Set<Contact>();
    public DbSet<Address> Addresses => Set<Address>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(p => p.Id); 

            entity.Property(p => p.Id)
                .ValueGeneratedOnAdd(); 
            
            entity.Property(p => p.FullName)
                .HasMaxLength(100)
                .IsRequired();
            
            entity.HasIndex(p => p.AddressId).IsUnique();
            
            entity.HasOne(p => p.Address)
                .WithOne(a => a.Person)
                .HasForeignKey<Person>(p => p.AddressId)
                .IsRequired(false);

            entity.HasMany(p => p.Contacts)
                .WithOne(c => c.Person)
                .HasForeignKey(c => c.PersonId);
        });
        
        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(p => p.Id); 

            entity.Property(p => p.Id)
                .ValueGeneratedOnAdd(); 
        
            entity.Property(p => p.State)
                .HasMaxLength(100)
                .IsRequired();
        
            entity.Property(p => p.Street)
                .HasMaxLength(100)
                .IsRequired();
        
            entity.Property(p => p.ZipCode)
                .HasMaxLength(100)
                .IsRequired();
        
            entity.Property(p => p.City)
                .HasMaxLength(100)
                .IsRequired();
        
            entity.Property(p => p.Country)
                .HasMaxLength(100)
                .IsRequired();
        });
        
        modelBuilder.Entity<Contact>(entity =>
        {
            entity.HasKey(p => p.Id); 

            entity.Property(p => p.Id)
                .ValueGeneratedOnAdd(); 
        
            entity.Property(p => p.Info)
                .HasMaxLength(100)
                .IsRequired();
        
            entity.Property(p => p.PersonId)
                .IsRequired();

            entity
                .Property(c => c.Channel)
                .IsRequired()
                .HasConversion<string>();
        });

        base.OnModelCreating(modelBuilder);
    }
}
