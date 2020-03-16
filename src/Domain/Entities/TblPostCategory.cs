using System;
using System.Collections.Generic;

namespace Pisheyar.Domain.Entities
{
    public partial class TblPostCategory
    {
        public int PcId { get; set; }

        public Guid PcGuid { get; set; }

        public int PcCategoryId { get; set; }

        public int PcPostId { get; set; }


        public virtual TblCategory PcCategory { get; set; }

        public virtual TblPost PcPost { get; set; }
    }
}
