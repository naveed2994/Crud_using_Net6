namespace Application.Customers.ReadModels
{
    public class CustomersModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Fname { get; set; }
        public string Phone { get; set; }
        public DateTime CreatedOn { get; set; }
        //public Guid Id { get; set; }
    }
}
