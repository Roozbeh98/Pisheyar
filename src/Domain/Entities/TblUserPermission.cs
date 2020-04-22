using System;
using System.Collections.Generic;

namespace Pisheyar.Domain.Entities
{
    public partial class TblUserPermission
    {
        public int UpId { get; set; }

        public Guid UpGuid { get; set; }

        public Guid UpUserGuid { get; set; }

        public int UpPermissionId { get; set; }

        public DateTime UpCreateDate { get; set; }

        public DateTime UpModifyDate { get; set; }

        public bool? UpIsActive { get; set; }

        public bool UpIsDelete { get; set; }


        public virtual TblPermission UpPermission { get; set; }

        public virtual TblUser UpUser { get; set; }
    }
}
