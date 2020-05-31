using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pisheyar.Domain.Entities
{
    public partial class PermissionGroup
    {
        public PermissionGroup()
        {
            Permission = new HashSet<Permission>();
        }

        [Key]
        [Column("PermissionGroupID")]
        public int PermissionGroupId { get; set; }
        [Column("PermissionGroupGUID")]
        public Guid PermissionGroupGuid { get; set; }
        [Required]
        [StringLength(128)]
        public string Name { get; set; }
        [Required]
        [StringLength(128)]
        public string DisplayName { get; set; }
        [Required]
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public DateTime ModifiedDate { get; set; }

        [InverseProperty("PermissionGroup")]
        public virtual ICollection<Permission> Permission { get; set; }
    }
}
