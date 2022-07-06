using Domain.common;

namespace Domain.Entities
{
    public class Customer : BaseEntity
    {

        public string Name { get; set; }
        public string Fname { get; set; }
        public string Phone { get; set; }
    }
}
