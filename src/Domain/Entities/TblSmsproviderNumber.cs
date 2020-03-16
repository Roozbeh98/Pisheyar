using System;
using System.Collections.Generic;

namespace Pisheyar.Domain.Entities
{
    public partial class TblSmsproviderNumber
    {
        public int SpnId { get; set; }

        public Guid SpnGuid { get; set; }

        public int SpnSpcid { get; set; }

        public string SpnNumber { get; set; }

        public DateTime SpnCreateDate { get; set; }

        public DateTime SpnModifyDate { get; set; }

        public bool SpnIsDelete { get; set; }


        public virtual TblSmsproviderConfiguration SpnSpc { get; set; }
    }
}
