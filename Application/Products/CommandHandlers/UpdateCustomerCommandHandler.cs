//using Application.Common.Abstract;
//using Domain.Entities;
//using MediatR;

//namespace Application.Customers.CommandHandlers
//{
//    public class UpdateCustomersHandler : IRequestHandler<UpdateCustomerCommand, Guid>
//    {
//        private readonly ApplicationDbHelper _con;

//        public UpdateCustomersHandler(ApplicationDbHelper con)
//        {
//            _con = con;
//        }
//        public async Task<Guid> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
//        {
//            Customer entity = new Customer();
//            entity.Id = request.Id;
//            entity.Name = request.Name;
//            entity.Fname = request.Fname;
//            entity.Phone = request.Phone;
//            entity.CreatedBy = Guid.NewGuid();
//            entity.CreatedOn = DateTime.Now;

//            var res = _con.Customers.Update(entity);
//            var re = _con.SaveChangesAsync();
//            if (re > 0)
//            {
//                return entity.Id;
//            }
//            return Guid.Empty;
//        }
//    }
//}
