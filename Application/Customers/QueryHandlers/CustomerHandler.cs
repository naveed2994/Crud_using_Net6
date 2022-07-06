using Application.Common.Abstract;
using Application.Customers.Queries;
using Application.Customers.ReadModels;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Customers.QueryHandlers
{
    public class CustomerDetailHandler : IRequestHandler<GetCustomerDetail, CustomersModel>
    {
        public readonly ApplicationDbHelper _context;
        private readonly IMapper _mapper;
        public CustomerDetailHandler(ApplicationDbHelper con, IMapper mapper)
        {
            _context = con;
            _mapper = mapper;
        }
        public async Task<CustomersModel> Handle(GetCustomerDetail request, CancellationToken cancellationToken)
        {
            var result = await  _context.Customers.FirstOrDefaultAsync(x => x.Id == request.Id);
            var res = _mapper.Map<CustomersModel>(result);
            return res;
        }
    }
}
