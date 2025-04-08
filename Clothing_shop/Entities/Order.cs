using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Clothing_shop.Entities
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.Now;

        [Required]
        public decimal TotalAmount { get; set; }

        [Required, StringLength(50)]
        public string Status { get; set; } = "Pending";

        public string ShippingAddress { get; set; }

        [ForeignKey("Payment")]
        public int? PaymentId { get; set; }

        [ForeignKey("Voucher")]
        public int? VoucherId { get; set; }

        public DateTime? UpdatedDate { get; set; } = DateTime.Now;

        public virtual User User { get; set; }
        public virtual Payment Payment { get; set; }
        public virtual Voucher Voucher { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<InventoryTransaction> InventoryTransactions { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }
    }
}
