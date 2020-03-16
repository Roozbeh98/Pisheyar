using System;

namespace Pisheyar.Application.Accounts.Queries.GetUserPermissionsByGuid
{
    public class CustomPermissionDto
    {
        public string PermissionDisplay { get; set; }

        public DateTime UpCreateDate { get; set; }

        public DateTime UpModifyDate { get; set; }
    }
}