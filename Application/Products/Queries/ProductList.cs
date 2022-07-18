using Application.Customers.ReadModels;
using MediatR;

namespace Application.Customers.Queries
{
    public class ProductList : IRequest<IEnumerable<ProductModel>>
    {
        
    }
}
