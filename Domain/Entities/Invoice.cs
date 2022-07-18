using Domain.common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Invoice")]
    public class Invoice : BaseEntity
    {
        public int Items { get; set; }
        public decimal Total { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Discount { get; set; }

    }
}
