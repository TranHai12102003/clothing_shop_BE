using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Clothing_shop.Entities
{
    public class Banner
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(255)]
        public string BannerName { get; set; }

        [Required, StringLength(255)]
        public string ImageUrl { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        [StringLength(255)]
        public string LinkUrl { get; set; }

        [ForeignKey("Product")]
        public int? ProductId { get; set; }

        [ForeignKey("Category")]
        public int? CategoryId { get; set; }

        [ForeignKey("Promotion")]
        public int? PromotionId { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; } = true;
        public int DisplayOrder { get; set; } = 0;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; } = DateTime.Now;

        public virtual Product Product { get; set; }
        public virtual Category Category { get; set; }
        public virtual Promotion Promotion { get; set; }
    }
}
