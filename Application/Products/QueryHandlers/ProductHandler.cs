using Application.Common.Abstract;
using Application.Customers.Queries;
using Application.Customers.ReadModels;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Customers.QueryHandlers
{
    public class ProductHandler : IRequestHandler<ProductDetail, ProductModel>
    {
        public readonly ApplicationDbHelper _context;
        private readonly IMapper _mapper;
        public ProductHandler(ApplicationDbHelper con, IMapper mapper)
        {
            _context = con;
            _mapper = mapper;
        }
        public async Task<ProductModel> Handle(ProductDetail request, CancellationToken cancellationToken)
        {
            var result = await _context.Products.FirstOrDefaultAsync(x => x.Id == request.Id);
            var res = _mapper.Map<ProductModel>(result);
            return res;
        }
    }
}
