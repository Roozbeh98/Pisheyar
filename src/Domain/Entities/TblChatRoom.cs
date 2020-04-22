using System;
using System.Collections.Generic;
using System.Text;

namespace Pisheyar.Domain.Entities
{
    public partial class TblChatRoom
    {
        public TblChatRoom()
        {
            TblChatMessage = new HashSet<TblChatMessage>();
        }


        public Guid Guid { get; set; }

        public Guid UserGuid { get; set; }

        public string OwnerConnectionId { get; set; }

        public string Name { get; set; }

        public bool IsDelete { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime ModifiedDate { get; set; }


        public virtual TblUser TblUser { get; set; }

        public virtual ICollection<TblChatMessage> TblChatMessage { get; set; }
    }
}
