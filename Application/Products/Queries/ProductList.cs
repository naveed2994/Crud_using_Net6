using Application.Customers.ReadModels;
using MediatR;

namespace Application.Customers.Queries
{
    public class ProductList : IRequest<IEnumerable<ProductModel>>
    {

        public int PageSize { get; set; }
        public int PageNo { get; set; }
        public int SearchText { get; set; }
    }
}