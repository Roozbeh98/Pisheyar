using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pisheyar.Application.Accounts.Commands.Login;
using Pisheyar.Application.Accounts.Commands.Authenticate;
using Pisheyar.Application.Accounts.Queries.GetUserByMobile;
using Pisheyar.Application.Accounts.Queries.GetUserByGuid;
using Pisheyar.Application.Accounts.Queries.GetUserPermissionsByGuid;
using Pisheyar.Application.Accounts.Queries.GetAllUsers;
using Microsoft.AspNetCore.Authorization;
using Pisheyar.Application.Accounts.Commands.ChangeUserActiveness;
using Pisheyar.Application.Accounts.Commands.DeleteUser;
using Pisheyar.Application.Accounts.Commands.RegisterClient;
using Pisheyar.Application.Accounts.Commands.RegisterContractor;
using Pisheyar.Application.Accounts.Queries.GetAllProvinces;
using Pisheyar.Application.Accounts.Queries.GetAllProvinceCities;
using Pisheyar.Application.Accounts.Queries.GetCurrentAdminUser;
using Pisheyar.Application.Accounts.Queries.GetCurrentClientUser;
using Pisheyar.Application.Accounts.Queries.GetCurrentContractorUser;
using Pisheyar.Application.Users.Commands.SetProfilePicture;

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
            return await Mediator.Send(new GetUserByGuidQuery() { UserGuid = guid });
        }

        /// <summary>
        /// دریافت اطلاعات کاربر ادمین لاگین شده
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        public async Task<ActionResult<GetCurrentAdminUserVm>> GetCurrentAdminUser()
        {
            return await Mediator.Send(new GetCurrentAdminUserQuery());
        }

        /// <summary>
        /// دریافت اطلاعات کاربر سرویس دهنده لاگین شده
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        public async Task<ActionResult<GetCurrentContractorUserVm>> GetCurrentContractorUser()
        {
            return await Mediator.Send(new GetCurrentContractorUserQuery());
        }

        /// <summary>
        /// دریافت اطلاعات کاربر سرویس گیرنده لاگین شده
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        public async Task<ActionResult<GetCurrentClientUserVm>> GetCurrentClientUser()
        {
            return await Mediator.Send(new GetCurrentClientUserQuery());
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
        /// دریافت تمامی استان ها
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet("Provinces")]
        public async Task<ActionResult<GetAllProvincesVm>> GetAllProvinces()
        {
            return await Mediator.Send(new GetAllProvincesQuery());
        }

        /// <summary>
        /// دریافت تمامی شهرهای واقع یک استان
        /// </summary>
        /// <param name="guid">آیدی استان</param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet("Provinces/{guid}/Cities")]
        public async Task<ActionResult<GetAllProvinceCitiesVm>> GetAllProvinceCities(Guid guid)
        {
            return await Mediator.Send(new GetAllProvinceCitiesQuery { ProvinceGuid = guid });
        }

        /// <summary>
        /// افزودن سرویس گیرنده جدید
        /// </summary>
        /// <param name="command">اطلاعات ادمین</param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("[action]")]
        public async Task<ActionResult<RegisterClientCommandVm>> RegisterClient(RegisterClientCommand command)
        {
            return await Mediator.Send(command);
        }

        /// <summary>
        /// افزودن سرویس دهنده جدید
        /// </summary>
        /// <param name="command">اطلاعات سرویس دهنده</param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("[action]")]
        public async Task<ActionResult<RegisterContractorVm>> RegisterContractor(RegisterContractorCommand command)
        {
            return await Mediator.Send(command);
        }

        /// <summary>
        /// تغییر تصویر پروفایل کاربر
        /// </summary>
        /// <param name="command">اطلاعات لازم</param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("[action]")]
        public async Task<ActionResult<SetProfilePictureVm>> SetProfilePicture(SetProfilePictureCommand command)
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
        [HttpPost("[action]")]
        public async Task<ActionResult<ChangeUserActivenessVm>> ChangeActiveness(ChangeUserActivenessCommand command)
        {
            return await Mediator.Send(command);
        }

        /// <summary>
        /// حذف کاربر
        /// </summary>
        /// <param name="command">آیدی کاربر</param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public async Task<ActionResult<DeleteUserVm>> Delete(DeleteUserCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}