using System;
using System.Collections.Generic;

namespace Pisheyar.Domain.Entities
{
    public partial class TblCodeGroup
    {
        public TblCodeGroup()
        {
            TblCode = new HashSet<TblCode>();
        }


        public int CgId { get; set; }

        public Guid CgGuid { get; set; }

        public string CgName { get; set; }

        public string CgDisplay { get; set; }


        public virtual ICollection<TblCode> TblCode { get; set; }
    }
}
