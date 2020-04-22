using System;
using System.Collections.Generic;

namespace Pisheyar.Domain.Entities
{
    public partial class TblUserToken
    {
        public int UtId { get; set; }

        public Guid UtGuid { get; set; }

        public Guid UtUserGuid { get; set; }

        public int UtToken { get; set; }

        public DateTime UtExpireDate { get; set; }


        public virtual TblUser UtUser { get; set; }
    }
}
