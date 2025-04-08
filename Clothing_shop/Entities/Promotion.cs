using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Clothing_shop.Entities
{
    public class Promotion
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(255)]
        public string PromotionName { get; set; }

        public int PercentDiscount { get; set; }

        [Required]
        public decimal DiscountValue { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; } = DateTime.Now;

        public virtual ICollection<VariantPromotion> VariantPromotions { get; set; }
        public virtual ICollection<Banner> Banners { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }
    }
}
