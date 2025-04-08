using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Clothing_shop.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(255)]
        public string FullName { get; set; }

        [Required, StringLength(100)]
        public string Username { get; set; }

        [Required, StringLength(255)]
        public string PasswordHash { get; set; }

        [Required, StringLength(255)]
        public string Email { get; set; }

        [StringLength(10)]
        public string Gender { get; set; }

        [StringLength(20)]
        public string PhoneNumber { get; set; }

        public DateTime? BirthDate { get; set; }
        public string Address { get; set; }

        [ForeignKey("Role")]
        public int RoleId { get; set; }

        [ForeignKey("CustomerType")]
        public int? CustomerTypeId { get; set; } = 1;

        public bool IsActive { get; set; } = false;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; } = DateTime.Now;

        public virtual Role Role { get; set; }
        public virtual CustomerType CustomerType { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }
    }
}
