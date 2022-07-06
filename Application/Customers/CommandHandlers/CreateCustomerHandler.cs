using Application.Common.Abstract;
using Domain.Entities;
using MediatR;

namespace Application.Customers.CommandHandlers
{
    public class CreateCustomersHandler : IRequestHandler<CreateCustomerCommand, Guid>
    {
        private readonly ApplicationDbHelper _con;

        public CreateCustomersHandler(ApplicationDbHelper con)
        {
            _con = con;
        }
        public async Task<Guid> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            Customer entity = new Customer();
            entity.Id = Guid.NewGuid();
            entity.Name = request.Name;
            entity.Fname = request.Fname;
            entity.Phone = request.Phone;
            entity.CreatedBy = Guid.NewGuid();
            entity.CreatedOn = DateTime.Now;

            var res = _con.Customers.Add(entity);
            var re = _con.SaveChangesAsync();
            if (re > 0)
            {
                return entity.Id;
            }
            return Guid.Empty;
        }
    }
}
