using System;
using System.Collections.Generic;

namespace Pisheyar.Domain.Entities
{
    public partial class TblCategoryTag
    {
        public int CategoryTagId { get; set; }

        public Guid CategoryTagGuid { get; set; }

        public int CategoryTagCategoryId { get; set; }

        public int CategoryTagTagId { get; set; }


        public virtual TblCategory CategoryTagCategory { get; set; }

        public virtual TblTag CategoryTagTag { get; set; }
    }
}
