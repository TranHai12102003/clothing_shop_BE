using System.ComponentModel.DataAnnotations;

namespace Clothing_shop.Entities
{
    public class CustomerType
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string TypeName { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        public int? MinOrderCount { get; set; }
        public decimal? MinTotalAmount { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; } = DateTime.Now;

        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Voucher> Vouchers { get; set; }
    }
}
