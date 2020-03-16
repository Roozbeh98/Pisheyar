using System;
using System.Collections.Generic;

namespace Pisheyar.Domain.Entities
{
    public partial class TblRolePermission
    {
        public int RpId { get; set; }

        public Guid RpGuid { get; set; }

        public int RpRoleId { get; set; }

        public int RpPermissionId { get; set; }

        public DateTime RpCreateDate { get; set; }

        public DateTime RpModifyDate { get; set; }

        public bool? RpIsActive { get; set; }

        public bool RpIsDelete { get; set; }


        public virtual TblPermission RpPermission { get; set; }

        public virtual TblRole RpRole { get; set; }
    }
}
