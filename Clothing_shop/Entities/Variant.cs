using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Clothing_shop.Entities
{
    public class Variant
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }

        [ForeignKey("Size")]
        public int SizeId { get; set; }

        [ForeignKey("Color")]
        public int ColorId { get; set; }

        [Required]
        public decimal Price { get; set; }

        public decimal? SalePrice { get; set; }

        public int QuantityInStock { get; set; } = 0;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; } = DateTime.Now;

        public virtual Product Product { get; set; }
        public virtual Size Size { get; set; }
        public virtual Color Color { get; set; }
        public virtual ICollection<ProductImage> ProductImages { get; set; }
        public virtual ICollection<VariantPromotion> VariantPromotions { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<InventoryTransaction> InventoryTransactions { get; set; }
    }
}
