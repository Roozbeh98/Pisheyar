using System;
using System.Collections.Generic;

namespace Pisheyar.Domain.Entities
{
    public partial class TblPostTag
    {
        public Guid PtGuid { get; set; }

        public Guid PtPostGuid { get; set; }

        public Guid PtTagGuid { get; set; }


        public virtual TblPost PtPost { get; set; }

        public virtual TblTag PtTag { get; set; }
    }
}
