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

            modelBuilder.Entity<Product>().Property(e => e.Name).IsRequired();
            modelBuilder.Entity<Product>().Property(e => e.Price).IsRequired();
            modelBuilder.Entity<Product>().HasKey(e => e.Id);
            modelBuilder.Entity<Product>().Property(e => e.CreatedBy).IsRequired();
            modelBuilder.Entity<Product>().Property(e => e.Descrption);
            modelBuilder.Entity<Product>().Property(e => e.CreatedOn).IsRequired();
            modelBuilder.Entity<Product>().Property(e => e.ModifiedOn);
            modelBuilder.Entity<Product>().Property(e => e.ModifiedBy);

            modelBuilder.Entity<Invoice>().Property(e => e.Id);
            modelBuilder.Entity<Invoice>().Property(e => e.Items).IsRequired();
            modelBuilder.Entity<Invoice>().Property(e => e.SubTotal).IsRequired();
            modelBuilder.Entity<Invoice>().Property(e => e.Total).IsRequired();
            modelBuilder.Entity<Invoice>().Property(e => e.Discount);
            modelBuilder.Entity<Invoice>().Property(e => e.CreatedBy).IsRequired();
            modelBuilder.Entity<Invoice>().Property(e => e.CreatedOn).IsRequired();
            modelBuilder.Entity<Invoice>().Property(e => e.ModifiedOn);
            modelBuilder.Entity<Invoice>().Property(e => e.ModifiedBy);

            modelBuilder.Entity<InvoiceDetail>().HasKey(e => e.Id);
            modelBuilder.Entity<InvoiceDetail>().HasOne(e => e.Product).WithMany().HasForeignKey(e => e.ProductId).IsRequired();
            modelBuilder.Entity<InvoiceDetail>().HasOne(e => e.Invoice).WithMany().HasForeignKey(e => e.InvoiceId).IsRequired();
            modelBuilder.Entity<InvoiceDetail>().Property(e => e.Qty).IsRequired();
            modelBuilder.Entity<InvoiceDetail>().Property(e => e.ProductPrice).IsRequired();
            modelBuilder.Entity<InvoiceDetail>().Property(e => e.CreatedBy).IsRequired();
            modelBuilder.Entity<InvoiceDetail>().Property(e => e.CreatedOn).IsRequired();
            modelBuilder.Entity<InvoiceDetail>().Property(e => e.ModifiedOn);
            modelBuilder.Entity<InvoiceDetail>().Property(e => e.ModifiedBy);

            modelBuilder.Entity<Product>().HasData(
    new Product { Id = Guid.NewGuid(), Name = "Bisket", Price = 50, Descrption = "This is bisket", CreatedBy = Guid.NewGuid(), CreatedOn = DateTime.UtcNow },
            new Product { Id = Guid.NewGuid(), Name = "Botel", Price = 500, Descrption = "This is botel", CreatedBy = Guid.NewGuid(), CreatedOn = DateTime.UtcNow },
            new Product { Id = Guid.NewGuid(), Name = "Biryani", Price = 5000, Descrption = "This is Biryani", CreatedBy = Guid.NewGuid(), CreatedOn = DateTime.UtcNow });
        }
        public DbSet<Customer> Customers => Set<Customer>();
        public DbSet<Product> Products => Set<Product>();
        public DbSet<Invoice> Invoices => Set<Invoice>();
        public DbSet<InvoiceDetail> InvoiceDetails => Set<InvoiceDetail>();


        public int SaveChangesAsync()
        {
            return SaveChanges();
        }

    }
}
