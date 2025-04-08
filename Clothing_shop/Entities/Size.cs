using System.ComponentModel.DataAnnotations;

namespace Clothing_shop.Entities
{
    public class Size
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string SizeName { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; } = DateTime.Now;

        public virtual ICollection<Variant> Variants { get; set; }
    }
}
