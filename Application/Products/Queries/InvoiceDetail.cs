using Application.Customers.ReadModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Products.Queries
{
    internal class InvoiceDetail : IRequest<InvoiceModel>
    {
    }
}
