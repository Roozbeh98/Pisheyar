using System;
using System.Collections.Generic;
using System.Text;

namespace Pisheyar.Domain.Entities
{
    public partial class TblChatMessage
    {
        public Guid Guid { get; set; }

        public Guid ChatRoomGuid { get; set; }

        public string SenderName { get; set; }

        public string Text { get; set; }

        public bool IsSeen { get; set; }

        public bool IsModified { get; set; }

        public bool IsDelete { get; set; }

        public DateTime SentDate { get; set; }

        public DateTime ModifiedDate { get; set; }


        public virtual TblChatRoom TblChatRoom { get; set; }
    }
}
