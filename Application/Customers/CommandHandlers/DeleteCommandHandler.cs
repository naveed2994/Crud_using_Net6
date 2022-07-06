using Application.Common.Abstract;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Customers.CommandHandlers
{
    public class DeleteCustomersHandler : IRequestHandler<DeleteCommand, bool>
    {
        private readonly ApplicationDbHelper _con;

        public DeleteCustomersHandler(ApplicationDbHelper con)
        {
            _con = con;
        }

        public async Task<bool> Handle(DeleteCommand request, CancellationToken cancellationToken)
        {
            var entity = await _con.Customers.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (entity != null) { var res = _con.Customers.Remove(entity); }
            var i = _con.SaveChangesAsync();
            if (i > 0)
            {
                return true;
            }
            return false;
            //return Task.FromResult(Guid.NewGuid());
            //throw new NotImplementedException();
        }
    }
}
