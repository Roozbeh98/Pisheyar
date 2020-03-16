using System;
using System.Collections.Generic;

namespace Pisheyar.Domain.Entities
{
    public partial class TblSmsproviderConfiguration
    {
        public TblSmsproviderConfiguration()
        {
            TblSmsproviderNumber = new HashSet<TblSmsproviderNumber>();
            TblSmssetting = new HashSet<TblSmssetting>();
        }


        public int SpcId { get; set; }

        public Guid? SpcGuid { get; set; }

        public string SpcUsername { get; set; }

        public string SpcPassword { get; set; }

        public string SpcApiKey { get; set; }

        public DateTime SpcCreateDate { get; set; }

        public DateTime SpcModifyDate { get; set; }

        public bool SpcIsDelete { get; set; }


        public virtual ICollection<TblSmsproviderNumber> TblSmsproviderNumber { get; set; }

        public virtual ICollection<TblSmssetting> TblSmssetting { get; set; }
    }
}
