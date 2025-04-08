using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Clothing_shop.Entities
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }

        [Required]
        public string CommentText { get; set; }

        public DateTime CommentDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; } = DateTime.Now;

        public virtual User User { get; set; }
        public virtual Product Product { get; set; }
    }
}
