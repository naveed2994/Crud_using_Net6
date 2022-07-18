using Application.Common.Abstract;
using Application.Customers.Queries;
using Application.Customers.ReadModels;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Customers.QueryHandlers
{
    public class InvoiceListHandler : IRequestHandler<InvoiceList, IEnumerable<InvoiceModel>>
    {
        public readonly ApplicationDbHelper _context;
        private readonly IMapper _mapper;
        public InvoiceListHandler(ApplicationDbHelper con, IMapper mapper)
        {
            _context = con;
            _mapper = mapper;
        }
        public async Task<IEnumerable<InvoiceModel>> Handle(InvoiceList request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _context.Invoices.Skip((request.PageNo) * request.PageSize).Take(request.PageSize);
                var res = _mapper.Map<IEnumerable<InvoiceModel>>(result);
                return res;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
