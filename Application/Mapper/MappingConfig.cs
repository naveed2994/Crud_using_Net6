using Application.Customers.ReadModels;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapper
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Customer, CustomersModel>();
            CreateMap<Product, ProductModel>();
            CreateMap<Invoice, InvoiceModel>();
        }
    }
}
