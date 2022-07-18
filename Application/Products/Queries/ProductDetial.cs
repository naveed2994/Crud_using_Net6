using Application.Customers.ReadModels;
using MediatR;

namespace Application.Customers.Queries
{
    public class ProductDetail : IRequest<ProductModel>
    {
        public ProductDetail(Guid Id)
        {
            this.Id = Id;
        }

        public Guid Id { get; private set; }
    }
}
