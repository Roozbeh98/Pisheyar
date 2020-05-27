using Pisheyar.Application.Accounts.Commands.Authenticate;
using Pisheyar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pisheyar.Application.Common.Interfaces
{
    public interface IIdentityService
    {
        Task<string> GetUserFullNameAsync(Guid userGuid);

        Task<AuthenticateVm> Authenticate(string mobile, string code, Guid roleGuid, bool rememberMe, bool isApplication);

        //Task<IEnumerable<TblUser>> GetAll();
    }
}
