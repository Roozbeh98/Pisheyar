using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pisheyar.Domain.Entities
{
    public partial class RolePermission
    {
        [Key]
        [Column("RolePermissionID")]
        public int RolePermissionId { get; set; }
        [Column("RolePermissionGUID")]
        public Guid RolePermissionGuid { get; set; }
        [Column("PermissionID")]
        public int PermissionId { get; set; }
        [Column("RoleID")]
        public int RoleId { get; set; }
        [Required]
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public DateTime ModifiedDate { get; set; }

        [ForeignKey(nameof(PermissionId))]
        [InverseProperty("RolePermission")]
        public virtual Permission Permission { get; set; }
        [ForeignKey(nameof(RoleId))]
        [InverseProperty("RolePermission")]
        public virtual Role Role { get; set; }
    }
}
