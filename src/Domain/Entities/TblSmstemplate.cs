using System;
using System.Collections.Generic;

namespace Pisheyar.Domain.Entities
{
    public partial class TblSmstemplate
    {
        public TblSmstemplate()
        {
            TblSmsresponse = new HashSet<TblSmsresponse>();
        }


        public int StId { get; set; }

        public Guid StGuid { get; set; }

        public int StSsid { get; set; }

        public string StName { get; set; }

        public DateTime StCreateDate { get; set; }

        public DateTime StModifyDate { get; set; }

        public bool StIsDelete { get; set; }


        public virtual TblSmssetting StSs { get; set; }

        public virtual ICollection<TblSmsresponse> TblSmsresponse { get; set; }
    }
}
