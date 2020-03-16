using System;
using System.Collections.Generic;

namespace Pisheyar.Domain.Entities
{
    public partial class TblComment
    {
        public TblComment()
        {
            TblPostComment = new HashSet<TblPostComment>();
        }


        public int CommentId { get; set; }

        public Guid CommentGuid { get; set; }

        public int CommentUserId { get; set; }

        public string CommentText { get; set; }

        public DateTime CommentDate { get; set; }


        public virtual TblUser CommentUser { get; set; }

        public virtual ICollection<TblPostComment> TblPostComment { get; set; }
    }
}
