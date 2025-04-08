using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Clothing_shop.Entities
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Order")]
        public int OrderId { get; set; }

        [Required, StringLength(50)]
        public string PaymentGateway { get; set; }

        [StringLength(100)]
        public string TransactionId { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required, StringLength(50)]
        public string PaymentStatus { get; set; } = "Pending";

        public DateTime PaymentDate { get; set; } = DateTime.Now;

        [StringLength(50)]
        public string PaymentMethod { get; set; }

        public DateTime? UpdatedDate { get; set; } = DateTime.Now;

        public virtual Order Order { get; set; }
    }
}
