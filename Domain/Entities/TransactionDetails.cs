using Domain.common;

namespace Domain.Entities
{
    public class TransactionDetails : BaseEntity
    {

        public int Quantity { get; set; }
        public virtual Product Product { get; set; }
        public string Phone { get; set; }
    }
}
