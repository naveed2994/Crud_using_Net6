using Application.Customers.ReadModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Products.ReadModels
{
    internal class InvoiceDetailModel
    {
        public Guid Id { get; set; }
        public int Items { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Discount { get; set; }
        public decimal Total { get; set; }
        public List<InvoiceModelDto> invoiceModelDtos { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
