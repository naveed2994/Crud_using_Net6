using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Abstract
{
    public interface ApplicationDbHelper
    {
        DbSet<Customer> Customers { get;  }
        public int SaveChangesAsync();
    }
}
