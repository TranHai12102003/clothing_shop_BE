using System.ComponentModel.DataAnnotations;

namespace Clothing_shop.Entities
{
    public class Warehouse
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(255)]
        public string WarehouseName { get; set; }

        public string Location { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; } = DateTime.Now;

        public virtual ICollection<InventoryTransaction> InventoryTransactions { get; set; }
    }
}
