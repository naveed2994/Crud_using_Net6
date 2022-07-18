namespace Application.Customers.ReadModels
{
    public class ProductModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public DateTime CreatedOn { get; set; }
        //public Guid Id { get; set; }
    }
}
