using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Pisheyar.Application.Common.Interfaces;
using Pisheyar.Application.Accounts.Commands.Authenticate;
using Pisheyar.Domain.Entities;
using Pisheyar.Infrastructure.Identity;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using System.Threading;
using Pisheyar.Domain.Enums;

namespace Pisheyar.Infrastructure.Identity
{
    public class IdentityService : IIdentityService
    {
        private readonly IPisheyarMagContext _context;
        private readonly ISmsService _smsService;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;

        public IdentityService(IPisheyarMagContext context, ISmsService smsService, IMapper mapper, IOptions<AppSettings> appSettings)
        {
            _context = context;
            _smsService = smsService;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        public async Task<AuthenticateVm> Authenticate(string mobile, string code, bool rememberMe)
        {
            var user = await _context.TblUser.SingleOrDefaultAsync(x => x.UserMobile.Equals(mobile) && !x.UserIsDelete);

            if (user != null)
            {
                var userToken = await _context.TblUserToken.Where(x => x.UtUserId.Equals(user.UserId)).OrderBy(x => x.UtExpireDate).LastOrDefaultAsync();

                if (userToken.UtToken.ToString().Equals(code) && userToken.UtExpireDate > DateTime.Now)
                {
                    if (user.UserIsActive == false)
                    {
                        user.UserIsActive = true;
                        await _context.SaveChangesAsync(CancellationToken.None);
                    }

                    DateTime expireDate = rememberMe ? DateTime.Now.AddMonths(1) : DateTime.Now.AddDays(1);

                    var tokenHandler = new JwtSecurityTokenHandler();
                    var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                        {
                            new Claim(ClaimTypes.NameIdentifier, user.UserGuid.ToString())
                            //new Claim(ClaimTypes.Role, await _context.TblRole.Where(x => x.RoleId == user.UserRoleId).Select(x => x.RoleName).SingleOrDefaultAsync())
                        }),
                        Expires = expireDate,
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                    };
                    var token = tokenHandler.CreateToken(tokenDescriptor);
                    return new AuthenticateVm() { Message = "عملیات موفق آمیز", State = (int)AuthenticateState.Success, Token = tokenHandler.WriteToken(token), Expires = expireDate };
                }

                return new AuthenticateVm() { Message = "کد وارد شده اشتباه است", State = (int)AuthenticateState.WrongCode, Token = null, Expires = null };
            }

            return new AuthenticateVm() { Message = "کاربری یافت نشد", State = (int)AuthenticateState.UserNotFound, Token = null, Expires = null };

            //user.Token = tokenHandler.WriteToken(token);

            //return user.WithoutPassword();
        }

        public Task<string> GetUserFullNameAsync(Guid userGuid)
        {
            return _context.TblUser.Where(x => x.UserGuid == userGuid).Select(x => x.UserName + " " + x.UserFamily).SingleOrDefaultAsync(CancellationToken.None);
        }

        //public async Task<IEnumerable<TblUser>> GetAll()
        //{
        //    return await _context.TblUser
        //        .Where(x => !x.UserIsDelete)
        //        .ToListAsync();
        //}

        //public TblUser GetById(int id)
        //{
        //    var user = _users.FirstOrDefault(x => x.Id == id);
        //    return user.WithoutPassword();
        //}
    }
}
