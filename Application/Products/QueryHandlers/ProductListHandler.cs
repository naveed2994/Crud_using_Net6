using Application.Common.Abstract;
using Application.Customers.Queries;
using Application.Customers.ReadModels;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Customers.QueryHandlers
{
    public class ProductListHandler : IRequestHandler<ProductList, IEnumerable<ProductModel>>
    {
        public readonly ApplicationDbHelper _context;
        private readonly IMapper _mapper;
        public ProductListHandler(ApplicationDbHelper con, IMapper mapper)
        {
            _context = con;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ProductModel>> Handle(ProductList request, CancellationToken cancellationToken)
        {
            var result = await _context.Products.ToListAsync();
            var res = _mapper.Map<IEnumerable<ProductModel>>(result);
            return res;
        }
    }
    //}
}
