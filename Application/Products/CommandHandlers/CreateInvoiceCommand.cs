using Application.Customers.ReadModels;
using MediatR;

namespace Application.Customers.CommandHandlers
{
    public class CreateInvoiceCommand : IRequest<Guid>
    {
        public int Items { get; set; }
        public decimal Total { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Discount { get; set; }
        public List<InvoiceModelDto> InvoiceModelDtos { get; set; }
    }
}