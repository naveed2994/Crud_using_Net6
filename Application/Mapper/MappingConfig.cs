using Application.Customers.ReadModels;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mapper
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Customer, CustomersModel>();
            CreateMap<Product, ProductModel>();
            //CreateMap<IEnumerable<Customer>, IEnumerable<CustomersModel>>();
            //CreateMap<IEnumerable<CustomersModel>, IEnumerable<Customer>>();

        }
    }
}
