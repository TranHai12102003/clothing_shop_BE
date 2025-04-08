using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Clothing_shop.Entities
{
    public class ProductImage
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }

        [ForeignKey("Variant")]
        public int? VariantId { get; set; }

        [Required, StringLength(255)]
        public string ImageUrl { get; set; }

        public bool IsPrimary { get; set; } = false;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; } = DateTime.Now;

        public virtual Product Product { get; set; }
        public virtual Variant Variant { get; set; }
    }
}
