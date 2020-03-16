using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pisheyar.Application.Accounts.Commands.Login;
using Pisheyar.Application.Accounts.Commands.Register;
using Pisheyar.Application.Accounts.Commands.Authenticate;
using Pisheyar.Application.Accounts.Queries.GetUserByMobile;
using Pisheyar.Application.Accounts.Queries.GetUserByGuid;
using Pisheyar.Application.Accounts.Queries.GetUserPermissionsByGuid;
using Pisheyar.Application.Accounts.Queries.GetAllUsers;
using Microsoft.AspNetCore.Authorization;
using Pisheyar.Application.Accounts.Commands.ChangeUserActiveness;
using Pisheyar.Application.Accounts.Commands.DeleteUser;

namespace WebUI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ApiController
    {
        [HttpGet("[action]/{mobile}")]
        public async Task<ActionResult<UserByMobileVm>> GetByMobile(string mobile)
        {
            return await Mediator.Send(new GetUserByMobileQuery { Mobile = mobile });
        }

        [HttpGet("[action]/{guid}")]
        public async Task<ActionResult<UserByGuidVm>> GetByGuid(Guid guid)
        {
            return await Mediator.Send(new GetUserByGuidQuery { UserGuid = guid });
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<AllUsersVm>> GetAll()
        {
            return await Mediator.Send(new GetAllUsersQuery());
        }

        [HttpGet("{guid}/[action]")]
        public async Task<ActionResult<UserPermissionsVm>> GetPermissions(Guid guid)
        {
            return await Mediator.Send(new GetUserPermissionsByGuidQuery { UserGuid = guid });
        }

        [AllowAnonymous]
        [HttpPost("[action]")]
        public async Task<ActionResult<RegisterCommandVm>> Register(RegisterCommand command)
        {
            return await Mediator.Send(command);
        }

        [AllowAnonymous]
        [HttpPost("[action]")]
        public async Task<ActionResult<LoginCommandVm>> Login(LoginCommand command)
        {
            return await Mediator.Send(command);
        }

        [AllowAnonymous]
        [HttpPost("[action]")]
        public async Task<ActionResult<AuthenticateVm>> Authenticate(AuthenticateCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("[action]")]
        public async Task<ActionResult<ChangeUserActivenessVm>> ChangeActiveness(ChangeUserActivenessCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpDelete("[action]")]
        public async Task<ActionResult<DeleteUserVm>> Delete(DeleteUserCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}