﻿using System.ComponentModel.DataAnnotations;

namespace Clothing_shop.Entities
{
    public class Role
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string RoleName { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
