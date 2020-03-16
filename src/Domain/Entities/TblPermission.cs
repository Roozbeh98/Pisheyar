using System;
using System.Collections.Generic;

namespace Pisheyar.Domain.Entities
{
    public partial class TblPermission
    {
        public TblPermission()
        {
            TblRolePermission = new HashSet<TblRolePermission>();
            TblUserPermission = new HashSet<TblUserPermission>();
        }


        public int PermissionId { get; set; }

        public Guid PermissionGuid { get; set; }

        public string PermissionName { get; set; }

        public string PermissionDisplay { get; set; }

        public DateTime PermissionCreateDate { get; set; }

        public DateTime PermissionModifyDate { get; set; }

        public bool? PermissionIsActive { get; set; }

        public bool PermissionIsDelete { get; set; }


        public virtual ICollection<TblRolePermission> TblRolePermission { get; set; }

        public virtual ICollection<TblUserPermission> TblUserPermission { get; set; }
    }
}
