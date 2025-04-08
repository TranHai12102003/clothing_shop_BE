using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Clothing_shop.Entities
{
    public class InventoryTransaction
    {
        [Key]
        public int TransactionId { get; set; }

        [ForeignKey("Variant")]
        public int VariantId { get; set; }

        [ForeignKey("Warehouse")]
        public int WarehouseId { get; set; }

        [Required, StringLength(50)]
        public string TransactionType { get; set; }

        [Required]
        public int Quantity { get; set; }

        public DateTime TransactionDate { get; set; } = DateTime.Now;

        [StringLength(255)]
        public string Reason { get; set; }

        [ForeignKey("Order")]
        public int? OrderId { get; set; }

        public virtual Variant Variant { get; set; }
        public virtual Warehouse Warehouse { get; set; }
        public virtual Order Order { get; set; }
    }
}
