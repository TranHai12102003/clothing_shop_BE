using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Clothing_shop.Entities
{
    public class VariantPromotion
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Variant")]
        public int VariantId { get; set; }

        [ForeignKey("Promotion")]
        public int PromotionId { get; set; }

        [Required]
        public decimal AppliedDiscount { get; set; }

        public virtual Variant Variant { get; set; }
        public virtual Promotion Promotion { get; set; }
    }
}
