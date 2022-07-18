using Domain.common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Product")]
    public class Product : BaseEntity
    {

        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Descrption { get; set; }
    }
}
