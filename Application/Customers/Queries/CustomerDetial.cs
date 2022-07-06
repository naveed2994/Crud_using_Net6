using Application.Customers.ReadModels;
using MediatR;

namespace Application.Customers.Queries
{
    public class GetCustomerDetail : IRequest<CustomersModel>
    {
        public GetCustomerDetail(Guid Id)
        {
            this.Id = Id;
        }

        public Guid Id { get; private set; }
    }
}
