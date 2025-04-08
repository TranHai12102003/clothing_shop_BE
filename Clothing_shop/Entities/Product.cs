using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Xml.Linq;

namespace Clothing_shop.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(255)]
        public string ProductName { get; set; }

        public string Description { get; set; }

        [ForeignKey("Brand")]
        public int BrandId { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; } = DateTime.Now;

        public virtual Category Category { get; set; }
        public virtual ICollection<Variant> Variants { get; set; }
        public virtual ICollection<ProductImage> ProductImages { get; set; }
        public virtual ICollection<Banner> Banners { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
