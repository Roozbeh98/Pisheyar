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
        /// <summary>
        /// دریافت اطلاعات کاربر از طریق شماره موبایل
        /// </summary>
        /// <param name="mobile">شماره موبایل کاربر</param>
        /// <returns></returns>
        [HttpGet("[action]/{mobile}")]
        public async Task<ActionResult<UserByMobileVm>> GetByMobile(string mobile)
        {
            return await Mediator.Send(new GetUserByMobileQuery { Mobile = mobile });
        }

        /// <summary>
        /// دریافت اطلاعات کاربر از طریق آیدی
        /// </summary>
        /// <param name="guid">آیدی کاربر</param>
        /// <returns></returns>
        [HttpGet("[action]/{guid}")]
        public async Task<ActionResult<UserByGuidVm>> GetByGuid(Guid guid)
        {
            return await Mediator.Send(new GetUserByGuidQuery { UserGuid = guid });
        }

        /// <summary>
        /// دریافت اطلاعات تمامی کاربران
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        public async Task<ActionResult<AllUsersVm>> GetAll()
        {
            return await Mediator.Send(new GetAllUsersQuery());
        }

        /// <summary>
        /// دریافت دسترسی های کاربر از طریق آیدی
        /// </summary>
        /// <param name="guid">آیدی کاربر</param>
        /// <returns></returns>
        [HttpGet("{guid}/[action]")]
        public async Task<ActionResult<UserPermissionsVm>> GetPermissions(Guid guid)
        {
            return await Mediator.Send(new GetUserPermissionsByGuidQuery { UserGuid = guid });
        }

        /// <summary>
        /// افزودن کاربر جدید
        /// </summary>
        /// <param name="command">اطلاعات کاربر</param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("[action]")]
        public async Task<ActionResult<RegisterCommandVm>> Register(RegisterCommand command)
        {
            return await Mediator.Send(command);
        }

        /// <summary>
        /// ورود کاربر
        /// </summary>
        /// <param name="command">اطلاعات ورود</param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("[action]")]
        public async Task<ActionResult<LoginCommandVm>> Login(LoginCommand command)
        {
            return await Mediator.Send(command);
        }

        /// <summary>
        /// احراز هویت کاربر
        /// </summary>
        /// <param name="command">اطلاعات لازم</param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("[action]")]
        public async Task<ActionResult<AuthenticateVm>> Authenticate(AuthenticateCommand command)
        {
            return await Mediator.Send(command);
        }

        /// <summary>
        /// تغییر وضعیت فعالیت کاربر
        /// </summary>
        /// <param name="command">اطلاعات لازم</param>
        /// <returns></returns>
        [HttpPut("[action]")]
        public async Task<ActionResult<ChangeUserActivenessVm>> ChangeActiveness(ChangeUserActivenessCommand command)
        {
            return await Mediator.Send(command);
        }

        /// <summary>
        /// حذف کاربر
        /// </summary>
        /// <param name="command">آیدی کاربر</param>
        /// <returns></returns>
        [HttpDelete("[action]")]
        public async Task<ActionResult<DeleteUserVm>> Delete(DeleteUserCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}