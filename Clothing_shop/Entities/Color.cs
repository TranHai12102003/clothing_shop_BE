using System.ComponentModel.DataAnnotations;

namespace Clothing_shop.Entities
{
    public class Color
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string ColorName { get; set; }

        [StringLength(10)]
        public string ColorCode { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; } = DateTime.Now;

        public virtual ICollection<Variant> Variants { get; set; }
    }
}
