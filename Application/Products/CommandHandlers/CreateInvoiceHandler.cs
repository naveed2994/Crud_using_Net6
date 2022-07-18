using Application.Common.Abstract;
using Domain.Entities;
using MediatR;

namespace Application.Customers.CommandHandlers
{
    public class CreateInvoiceHandler : IRequestHandler<CreateInvoiceCommand, Guid>
    {
        private readonly ApplicationDbHelper _con;

        public CreateInvoiceHandler(ApplicationDbHelper con)
        {
            _con = con;
        }
        public async Task<Guid> Handle(CreateInvoiceCommand request, CancellationToken cancellationToken)
        {
            Invoice entity = new Invoice();
            entity.Id = Guid.NewGuid();
            entity.Items = request.Items;
            entity.SubTotal = request.SubTotal;
            entity.Total = request.Total;
            entity.Discount = request.Discount;
            entity.CreatedBy = Guid.NewGuid();
            entity.CreatedOn = DateTime.Now;
            var res = _con.Invoices.Add(entity);
            var re = _con.SaveChangesAsync();
            if (re > 0)
            {
                foreach (var item in request.InvoiceModelDtos)
                {
                    InvoiceDetail dt = new InvoiceDetail();
                    dt.Id = Guid.NewGuid();
                    dt.Qty = item.Qty;
                    dt.InvoiceId = entity.Id;
                    dt.ProductId = item.ProductId;
                    dt.ProductPrice = item.ProductPrice;
                    dt.CreatedBy = Guid.NewGuid();
                    dt.CreatedOn = DateTime.Now;
                    var result = await _con.InvoiceDetails.AddAsync(dt);
                    try
                    {
                        _con.SaveChangesAsync();
                    }
                    catch (Exception ex)
                    {
                    }
                }
                return entity.Id;
            }
            return Guid.Empty;
        }
    }
}
