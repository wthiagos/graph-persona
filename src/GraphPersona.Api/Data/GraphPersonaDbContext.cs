using GraphPersona.Api.GraphQL.Enums;
using GraphPersona.Api.Models;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace GraphPersona.Api.Data;

public class GraphPersonaDbContext(DbContextOptions<GraphPersonaDbContext> options) : DbContext(options)
{
    public DbSet<Person> People => Set<Person>();
    public DbSet<Contact> Contacts => Set<Contact>();
    public DbSet<Address> Addresses => Set<Address>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // modelBuilder.HasPostgresEnum<ContactTypeEnum>();

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(p => p.Id); 

            entity.Property(p => p.Id)
                .IsRequired()         
                .HasColumnType("uuid") 
                .ValueGeneratedOnAdd(); 
            
            entity.Property(p => p.FullName)
                .HasMaxLength(100)
                .IsRequired();
            
            entity.HasOne(p => p.Address)
                .WithOne(a => a.Person)
                .HasForeignKey<Person>(p => p.AddressId)
                .IsRequired(false);

            entity.HasMany(p => p.Contacts)
                .WithOne()
                .HasForeignKey(c => c.PersonId);
        });
        
        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(p => p.Id); 

            entity.Property(p => p.Id)
                .IsRequired()         
                .HasColumnType("uuid") 
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
                .IsRequired()         
                .HasColumnType("uuid") 
                .ValueGeneratedOnAdd(); 
        
            entity.Property(p => p.Value)
                .HasMaxLength(100)
                .IsRequired();
        
            entity.Property(p => p.PersonId)
                .IsRequired();

            entity
                .Property(c => c.Type)
                .IsRequired();
            
            entity.HasOne(c => c.Person)               
                .WithMany(p => p.Contacts)
                .HasForeignKey(c => c.PersonId);
        });

        base.OnModelCreating(modelBuilder);
    }
}
