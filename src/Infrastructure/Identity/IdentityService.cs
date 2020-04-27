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
        private readonly IPisheyarContext _context;
        private readonly ISmsService _smsService;
        private readonly IMapper _mapper;
        private readonly JwtSettings _jwtSettings;

        public IdentityService(IPisheyarContext context, ISmsService smsService, IMapper mapper, IOptions<JwtSettings> jwtSettings)
        {
            _context = context;
            _smsService = smsService;
            _mapper = mapper;
            _jwtSettings = jwtSettings.Value;
        }

        public async Task<AuthenticateVm> Authenticate(string mobile, string code, bool rememberMe)
        {
            var user = await _context.User.SingleOrDefaultAsync(x => x.PhoneNumber.Equals(mobile) && !x.IsDelete);

            if (user != null)
            {
                var userToken = await _context.Token.Where(x => x.UserId == user.UserId).OrderBy(x => x.ExpireDate).LastOrDefaultAsync();

                if (userToken.Value.ToString().Equals(code) && userToken.ExpireDate > DateTime.Now)
                {
                    if (user.IsActive == false)
                    {
                        user.IsActive = true;
                        await _context.SaveChangesAsync(CancellationToken.None);
                    }

                    DateTime expireDate = rememberMe ? DateTime.Now.AddMonths(1) : DateTime.Now.AddDays(1);

                    return new AuthenticateVm() { Message = "عملیات موفق آمیز", State = (int)AuthenticateState.Success, Token = GenerateJSONWebToken(user, expireDate), Expires = expireDate.ToString("yyyy/MM/dd HH:mm:ss") };
                }

                return new AuthenticateVm() { Message = "کد وارد شده اشتباه است", State = (int)AuthenticateState.WrongCode, Token = null, Expires = null };
            }

            return new AuthenticateVm() { Message = "کاربری یافت نشد", State = (int)AuthenticateState.UserNotFound, Token = null, Expires = null };
            //return user.WithoutPassword();
        }

        private string GenerateJSONWebToken(User user, DateTime expireDate)
        {
            var roleName = _context.Role
                .Where(x => x.RoleId == user.RoleId)
                .SingleOrDefault()
                .Name;

            var key = Encoding.ASCII.GetBytes(_jwtSettings.Key);
            var securityKey = new SymmetricSecurityKey(key);
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[] {
                new Claim(ClaimTypes.NameIdentifier, user.UserGuid.ToString()),
                //new Claim(ClaimTypes.Sid, user.UserId.ToString()),
                new Claim(ClaimTypes.MobilePhone, user.PhoneNumber),
                new Claim(ClaimTypes.Role, roleName),
                //new Claim(JwtRegisteredClaimNames.Sub, userInfo.Username),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, user.UserGuid.ToString()),
            };
            var token = new JwtSecurityToken(_jwtSettings.Issuer,
                _jwtSettings.Issuer,
                claims,
                expires: expireDate,
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public Task<string> GetUserFullNameAsync(Guid userGuid)
        {
            return _context.User.Where(x => x.UserGuid == userGuid).Select(x => x.FirstName + " " + x.LastName).SingleOrDefaultAsync(CancellationToken.None);
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
