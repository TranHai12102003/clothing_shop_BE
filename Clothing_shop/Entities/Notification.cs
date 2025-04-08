using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Clothing_shop.Entities
{
    public class Notification
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        [Required, StringLength(255)]
        public string Title { get; set; }

        [Required]
        public string Message { get; set; }

        [ForeignKey("Order")]
        public int? OrderId { get; set; }

        [ForeignKey("Promotion")]
        public int? PromotionId { get; set; }

        public bool IsRead { get; set; } = false;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? ReadDate { get; set; }

        public virtual User User { get; set; }
        public virtual Order Order { get; set; }
        public virtual Promotion Promotion { get; set; }
    }
}
