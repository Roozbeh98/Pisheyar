using System;
using System.Collections.Generic;

namespace Pisheyar.Domain.Entities
{
    public partial class TblPostComment
    {
        public Guid PcGuid { get; set; }

        public Guid PcCommentGuid { get; set; }

        public Guid PcPostGuid { get; set; }

        public bool PcIsAccept { get; set; }


        public virtual TblComment PcComment { get; set; }

        public virtual TblPost PcPost { get; set; }
    }
}
