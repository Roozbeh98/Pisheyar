using System;
using System.Collections.Generic;

namespace Pisheyar.Domain.Entities
{
    public partial class TblCode
    {
        public TblCode()
        {
            TblCodeGroup = new HashSet<TblCodeGroup>();
            TblDocument = new HashSet<TblDocument>();
        }


        public int CodeId { get; set; }

        public Guid CodeGuid { get; set; }

        public int CodeCgid { get; set; }

        public string CodeName { get; set; }

        public string CodeDisplay { get; set; }

        public bool? CodeIsActive { get; set; }


        public virtual ICollection<TblCodeGroup> TblCodeGroup { get; set; }

        public virtual ICollection<TblDocument> TblDocument { get; set; }
    }
}
