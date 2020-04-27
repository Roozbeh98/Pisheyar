using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pisheyar.Domain.Entities
{
    public partial class Role
    {
        public Role()
        {
            RolePermission = new HashSet<RolePermission>();
            User = new HashSet<User>();
        }

        [Key]
        [Column("RoleID")]
        public int RoleId { get; set; }
        [Column("RoleGUID")]
        public Guid RoleGuid { get; set; }
        [Required]
        [StringLength(128)]
        public string Name { get; set; }
        [Required]
        [StringLength(128)]
        public string DisplayName { get; set; }
        public bool IsDelete { get; set; }
        public DateTime ModifiedDate { get; set; }

        [InverseProperty("Role")]
        public virtual ICollection<RolePermission> RolePermission { get; set; }
        [InverseProperty("Role")]
        public virtual ICollection<User> User { get; set; }
    }
}
