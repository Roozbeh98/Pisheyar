using System;
using System.Collections.Generic;

namespace Pisheyar.Domain.Entities
{
    public partial class TblPostTag
    {
        public int PtId { get; set; }

        public Guid PtGuid { get; set; }

        public int PtPostId { get; set; }

        public int PtTagId { get; set; }


        public virtual TblPost PtPost { get; set; }

        public virtual TblTag PtTag { get; set; }
    }
}
