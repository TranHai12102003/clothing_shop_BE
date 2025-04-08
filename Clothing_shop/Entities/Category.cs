using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Clothing_shop.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(255)]
        public string CategoryName { get; set; }

        [ForeignKey("ParentCategory")]
        public int? ParentCategoryId { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; }

        public bool IsActive { get; set; } =true;
        public string? ImageUrl { get; set; }

        public virtual Category ParentCategory { get; set; }
        public virtual ICollection<Category> SubCategories { get; set; } = new List<Category>();
        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
        public virtual ICollection<Banner> Banners { get; set; } = new List<Banner>();
    }
}
