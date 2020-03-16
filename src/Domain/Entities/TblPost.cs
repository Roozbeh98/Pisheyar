using System;
using System.Collections.Generic;

namespace Pisheyar.Domain.Entities
{
    public partial class TblPost
    {
        public TblPost()
        {
            TblPostCategory = new HashSet<TblPostCategory>();
            TblPostComment = new HashSet<TblPostComment>();
            TblPostTag = new HashSet<TblPostTag>();
        }


        public int PostId { get; set; }

        public Guid PostGuid { get; set; }

        public int PostUserId { get; set; }

        public int? PostDocumentId { get; set; }

        public int PostViewCount { get; set; }

        public int PostLikeCount { get; set; }

        public string PostTitle { get; set; }

        public string PostAbstract { get; set; }

        public string PostDescription { get; set; }

        public DateTime PostCreateDate { get; set; }

        public DateTime PostModifyDate { get; set; }

        public bool PostIsShow { get; set; }

        public bool PostIsDelete { get; set; }


        public virtual TblDocument PostDocument { get; set; }

        public virtual TblUser PostUser { get; set; }

        public virtual ICollection<TblPostCategory> TblPostCategory { get; set; }

        public virtual ICollection<TblPostComment> TblPostComment { get; set; }

        public virtual ICollection<TblPostTag> TblPostTag { get; set; }
    }
}
