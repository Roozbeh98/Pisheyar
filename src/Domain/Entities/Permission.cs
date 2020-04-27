using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pisheyar.Domain.Entities
{
    public partial class Permission
    {
        public Permission()
        {
            RolePermission = new HashSet<RolePermission>();
            UserPermission = new HashSet<UserPermission>();
        }

        [Key]
        [Column("PermissionID")]
        public int PermissionId { get; set; }
        [Column("PermissionGUID")]
        public Guid PermissionGuid { get; set; }
        [Column("PermissionGroupID")]
        public int PermissionGroupId { get; set; }
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

        [ForeignKey(nameof(PermissionGroupId))]
        [InverseProperty("Permission")]
        public virtual PermissionGroup PermissionGroup { get; set; }
        [InverseProperty("Permission")]
        public virtual ICollection<RolePermission> RolePermission { get; set; }
        [InverseProperty("Permission")]
        public virtual ICollection<UserPermission> UserPermission { get; set; }
    }
}
