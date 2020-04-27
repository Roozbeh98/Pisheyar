using Pisheyar.Application.Common.Mappings;
using Pisheyar.Domain.Entities;
using System;

namespace Pisheyar.Application.Accounts.Queries.GetUserByGuid
{
    public class UserByGuidDto : IMapFrom<User>
    {
        public Guid UserGuid { get; set; }

        public string UserName { get; set; }

        public string UserFamily { get; set; }

        public string UserMobile { get; set; }

        public DateTime UserCreateDate { get; set; }

        public bool UserIsActive { get; set; }

        public bool UserIsBan { get; set; }
    }
}
