using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pisheyar.Domain.Entities
{
    public partial class UserPermission
    {
        [Key]
        [Column("UserPermissionID")]
        public int UserPermissionId { get; set; }
        [Column("UserPermissionGUID")]
        public Guid UserPermissionGuid { get; set; }
        [Column("PermissionID")]
        public int PermissionId { get; set; }
        [Column("UserID")]
        public int UserId { get; set; }
        [Required]
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public DateTime ModifiedDate { get; set; }

        [ForeignKey(nameof(PermissionId))]
        [InverseProperty("UserPermission")]
        public virtual Permission Permission { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty("UserPermission")]
        public virtual User User { get; set; }
    }
}
