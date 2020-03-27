using System;
using System.Collections.Generic;

namespace Pisheyar.Domain.Entities
{
    public partial class TblCategoryTag
    {
        public int CtId { get; set; }

        public Guid CtGuid { get; set; }

        public Guid CtCategoryGuid { get; set; }

        public int CtTagId { get; set; }


        public virtual TblCategory CtCategoryGu { get; set; }

        public virtual TblTag CtTag { get; set; }
    }
}
