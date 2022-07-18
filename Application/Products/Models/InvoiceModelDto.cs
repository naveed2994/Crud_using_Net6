namespace Application.Customers.ReadModels
{
    public class InvoiceModelDto
    {
        public int Qty { get; set; }
        public decimal ProductPrice { get; set; }
        public Guid? InvoiceId { get; set; }
        public Guid ProductId { get; set; }
    }
}
