using Pisheyar.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Pisheyar.Infrastructure.Identity
{
    public static class ExtensionMethods
    {
        public static IEnumerable<TblUser> WithoutPasswords(this IEnumerable<TblUser> users)
        {
            if (users == null) return null;

            return users.Select(x => x.WithoutPassword());
        }

        public static TblUser WithoutPassword(this TblUser user)
        {
            if (user == null) return null;

            //user.Password = null;
            return user;
        }
    }
}
