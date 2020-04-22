using System;
using System.Collections.Generic;

namespace Pisheyar.Domain.Entities
{
    public partial class TblUser
    {
        public TblUser()
        {
            TblComment = new HashSet<TblComment>();
            TblPost = new HashSet<TblPost>();
            TblChatRoom = new HashSet<TblChatRoom>();
            TblSmsresponse = new HashSet<TblSmsresponse>();
            TblUserPermission = new HashSet<TblUserPermission>();
            TblUserToken = new HashSet<TblUserToken>();
        }


        public Guid UserGuid { get; set; }

        public int UserRoleId { get; set; }

        public string UserName { get; set; }

        public string UserFamily { get; set; }

        public string UserEmail { get; set; }

        public string UserMobile { get; set; }

        public DateTime UserCreateDate { get; set; }

        public DateTime UserModifyDate { get; set; }

        public bool UserIsActive { get; set; }

        public bool UserIsDelete { get; set; }


        public virtual TblRole UserRole { get; set; }

        public virtual ICollection<TblComment> TblComment { get; set; }

        public virtual ICollection<TblPost> TblPost { get; set; }

        public virtual ICollection<TblChatRoom> TblChatRoom { get; set; }

        public virtual ICollection<TblSmsresponse> TblSmsresponse { get; set; }

        public virtual ICollection<TblUserPermission> TblUserPermission { get; set; }

        public virtual ICollection<TblUserToken> TblUserToken { get; set; }
    }
}
