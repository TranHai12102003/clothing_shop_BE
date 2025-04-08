using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Clothing_shop.Entities
{
    public class OrderDetail
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Order")]
        public int OrderId { get; set; }

        [ForeignKey("Variant")]
        public int VariantId { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal UnitPrice { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public virtual Order Order { get; set; }
        public virtual Variant Variant { get; set; }
    }
}
