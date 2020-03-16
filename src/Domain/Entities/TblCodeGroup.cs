using System;
using System.Collections.Generic;

namespace Pisheyar.Domain.Entities
{
    public partial class TblCodeGroup
    {
        public int CgId { get; set; }

        public Guid CgGuid { get; set; }

        public int CgCodeId { get; set; }

        public string CgName { get; set; }

        public string CgDisplay { get; set; }


        public virtual TblCode CgCode { get; set; }
    }
}
