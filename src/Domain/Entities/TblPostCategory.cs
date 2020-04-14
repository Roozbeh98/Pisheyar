using System;
using System.Collections.Generic;

namespace Pisheyar.Domain.Entities
{
    public partial class TblPostCategory
    {
        public Guid PcGuid { get; set; }

        public Guid PcCategoryGuid { get; set; }

        public Guid PcPostGuid { get; set; }


        public virtual TblCategory PcCategoryGu { get; set; }

        public virtual TblPost PcPost { get; set; }
    }
}
