using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Clothing_shop.Entities
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        [ForeignKey("Variant")]
        public int VariantId { get; set; }

        public int Quantity { get; set; } = 1;
        public DateTime AddedDate { get; set; } = DateTime.Now;

        public virtual User User { get; set; }
        public virtual Variant Variant { get; set; }
    }
}
