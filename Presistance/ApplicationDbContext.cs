using Application.Common.Abstract;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Presistance
{
    public class ApplicationDbContext : DbContext, ApplicationDbHelper
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Apply configuration
            modelBuilder.Entity<Customer>().HasKey(e => e.Id);
            modelBuilder.Entity<Customer>().Property(e => e.Name).IsRequired();
            modelBuilder.Entity<Customer>().Property(e => e.Fname).IsRequired();
            modelBuilder.Entity<Customer>().Property(e => e.Phone).IsRequired();
            modelBuilder.Entity<Customer>().Property(e => e.CreatedBy).IsRequired();
            modelBuilder.Entity<Customer>().Property(e => e.CreatedOn).IsRequired();
            modelBuilder.Entity<Customer>().Property(e => e.ModifiedOn);
            modelBuilder.Entity<Customer>().Property(e => e.ModifiedBy);
            modelBuilder.Entity<Customer>().HasData(
    new Customer { Id = Guid.NewGuid(), Name = "Ali", Fname = "Khan", Phone = "023204902843", CreatedBy = Guid.NewGuid(), CreatedOn = DateTime.UtcNow });
            modelBuilder.Entity<Customer>().HasData(
    new Customer { Id = Guid.NewGuid(), Name = "Faisal", Fname = "Mustaq", Phone = "023204902843", CreatedBy = Guid.NewGuid(), CreatedOn = DateTime.UtcNow });
            modelBuilder.Entity<Customer>().HasData(
    new Customer { Id = Guid.NewGuid(), Name = "Hanif", Fname = "Shahzad", Phone = "023204902843", CreatedBy = Guid.NewGuid(), CreatedOn = DateTime.UtcNow });
            modelBuilder.Entity<Customer>().HasData(
    new Customer { Id = Guid.NewGuid(), Name = "Saif", Fname = "Khan", Phone = "023204902843", CreatedBy = Guid.NewGuid(), CreatedOn = DateTime.UtcNow });
            modelBuilder.Entity<Customer>().HasData(
    new Customer { Id = Guid.NewGuid(), Name = "Sohail", Fname = "Khan", Phone = "023204902843", CreatedBy = Guid.NewGuid(), CreatedOn = DateTime.UtcNow });
        }

        public DbSet<Customer> Customers => Set<Customer>();
       public int SaveChangesAsync()
        {
            return SaveChanges();
        }
        
    }
}
