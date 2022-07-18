namespace Application.Customers.ReadModels
{
    public class InvoiceModel
    {
        public Guid Id { get; set; }
        public int Items { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Discount { get; set; }
        public decimal Total { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
