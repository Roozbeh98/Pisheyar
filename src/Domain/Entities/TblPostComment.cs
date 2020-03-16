using System;
using System.Collections.Generic;

namespace Pisheyar.Domain.Entities
{
    public partial class TblPostComment
    {
        public int PcId { get; set; }

        public Guid PcGuid { get; set; }

        public int PcCommentId { get; set; }

        public int PcPostId { get; set; }

        public bool PcIsAccept { get; set; }


        public virtual TblComment PcComment { get; set; }

        public virtual TblPost PcPost { get; set; }
    }
}
