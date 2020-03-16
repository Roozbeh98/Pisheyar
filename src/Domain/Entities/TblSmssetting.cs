using System;
using System.Collections.Generic;

namespace Pisheyar.Domain.Entities
{
    public partial class TblSmssetting
    {
        public TblSmssetting()
        {
            TblSmstemplate = new HashSet<TblSmstemplate>();
        }


        public int SsId { get; set; }

        public Guid SsGuid { get; set; }

        public int SsSpcid { get; set; }

        public string SsName { get; set; }

        public DateTime SsCreateDate { get; set; }

        public DateTime SsModifyDate { get; set; }

        public bool SsIsDelete { get; set; }


        public virtual TblSmsproviderConfiguration SsSpc { get; set; }

        public virtual ICollection<TblSmstemplate> TblSmstemplate { get; set; }
    }
}
