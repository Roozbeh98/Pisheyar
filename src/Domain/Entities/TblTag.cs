using System;
using System.Collections.Generic;

namespace Pisheyar.Domain.Entities
{
    public partial class TblTag
    {
        public TblTag()
        {
            TblCategoryTag = new HashSet<TblCategoryTag>();
            TblPostTag = new HashSet<TblPostTag>();
        }


        public int TagId { get; set; }

        public Guid TagGuid { get; set; }

        public string TagName { get; set; }

        public DateTime TagCreateDate { get; set; }

        public DateTime TagModifyDate { get; set; }

        public bool TagIsDelete { get; set; }


        public virtual ICollection<TblCategoryTag> TblCategoryTag { get; set; }

        public virtual ICollection<TblPostTag> TblPostTag { get; set; }
    }
}
