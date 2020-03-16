using System;
using System.Collections.Generic;

namespace Pisheyar.Domain.Entities
{
    public partial class TblRole
    {
        public TblRole()
        {
            TblRolePermission = new HashSet<TblRolePermission>();
            TblUser = new HashSet<TblUser>();
        }


        public int RoleId { get; set; }

        public Guid RoleGuid { get; set; }

        public string RoleName { get; set; }

        public string RoleDisplay { get; set; }

        public DateTime RoleCreateDate { get; set; }

        public DateTime RoleModifyDate { get; set; }

        public bool RoleIsDelete { get; set; }


        public virtual ICollection<TblRolePermission> TblRolePermission { get; set; }

        public virtual ICollection<TblUser> TblUser { get; set; }
    }
}
