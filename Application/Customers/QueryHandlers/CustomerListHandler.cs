using Application.Common.Abstract;
using Application.Customers.Queries;
using Application.Customers.ReadModels;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Customers.QueryHandlers
{
    public class CustomerListHandler : IRequestHandler<CustomerList, IEnumerable<CustomersModel>>
    {
        public readonly ApplicationDbHelper _context;
        private readonly IMapper _mapper;
        public CustomerListHandler(ApplicationDbHelper con, IMapper mapper)
        {
            _context = con;
            _mapper = mapper;
        }
        public async Task<IEnumerable<CustomersModel>> Handle(CustomerList request, CancellationToken cancellationToken)
        {
            var re = _context.Customers.Count();
            var pageSize = request.PagSize == 0 ? 10 : request.PagSize;

            if (request.NameSearch != null)
            {
                var result = _context.Customers.Where(x => x.Name.Contains(request.NameSearch)).Skip((request.PageNo) * pageSize).Take(pageSize);
                var res = _mapper.Map<IEnumerable<CustomersModel>>(result);
                return res;

            }
            else if (request.FnameSearch != null)
            {
                var result = _context.Customers.Where(x => x.Fname.Contains(request.FnameSearch)).Skip((request.PageNo) * pageSize).Take(pageSize);
                var res = _mapper.Map<IEnumerable<CustomersModel>>(result);
                return res;
            }

            else if (request.Phone != null)
            {
                var result = _context.Customers.Where(x => x.Phone.Contains(request.Phone)).Skip((request.PageNo) * pageSize).Take(pageSize);
                var res = _mapper.Map<IEnumerable<CustomersModel>>(result);
                return res;
            }
            else if (request.CreatedOn != null)
            {
                var result = _context.Customers.Where(x => x.CreatedOn.Year == request.CreatedOn.Value.Year || x.CreatedOn.Month == request.CreatedOn.Value.Month || x.CreatedOn.Day == request.CreatedOn.Value.Day).Skip((request.PageNo) * pageSize).Take(pageSize);
                var res = _mapper.Map<IEnumerable<CustomersModel>>(result);
                return res;
            }
            else
            {
                var result = _context.Customers.Skip((request.PageNo) * pageSize).Take(pageSize);
                var res = _mapper.Map<IEnumerable<CustomersModel>>(result);
                return res;

            }
        }
    }
}
