using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Clothing_shop.Entities
{
    public class Voucher
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string VoucherCode { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        [Required, StringLength(50)]
        public string DiscountType { get; set; }

        [Required]
        public decimal DiscountValue { get; set; }

        public decimal? MinOrderAmount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int? MaxUsage { get; set; }
        public int UsedCount { get; set; } = 0;
        public bool IsActive { get; set; } = true;

        [ForeignKey("CustomerType")]
        public int? CustomerTypeId { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; } = DateTime.Now;

        public virtual CustomerType CustomerType { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
