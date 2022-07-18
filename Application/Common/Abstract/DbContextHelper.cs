using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Abstract
{
    public interface ApplicationDbHelper
    {
        DbSet<Customer> Customers { get; }
        DbSet<Product> Products { get; }
        DbSet<Invoice> Invoices { get; }
        DbSet<InvoiceDetail> InvoiceDetails { get; }
        public int SaveChangesAsync();
    }
}
