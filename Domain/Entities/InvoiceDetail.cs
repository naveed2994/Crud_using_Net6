using Domain.common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("InvoiceDetail")]
    public class InvoiceDetail : BaseEntity
    {
        //[ForeignKey("Inovices")]

        public int Qty { get; set; }
        public decimal ProductPrice { get; set; }
        [ForeignKey("InvoiceId")]
        public virtual Invoice Invoice { get; set; }
        public Guid InvoiceId { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
        public Guid ProductId { get; set; }
    }
}
