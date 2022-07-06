//using Domain.Entities;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace Presistance.Configurations
//{
//    public class CustomerConfig : IEntityTypeConfiguration<Customer>
//    {
//        public void Configure(EntityTypeBuilder<Customer> builder)
//        {
//            builder.HasKey(e => e.Id);
//            builder.Property(e => e.Name).IsRequired();
//            builder.Property(e => e.Fname).IsRequired();
//            builder.Property(e => e.Phone);
//            builder.Property(e => e.CreatedOn).IsRequired();
//            builder.Property(e => e.CreatedBy).IsRequired();
//            builder.Property(e => e.ModifiedBy);
//            builder.Property(e => e.ModifiedOn);
//        }
//    }
//}
