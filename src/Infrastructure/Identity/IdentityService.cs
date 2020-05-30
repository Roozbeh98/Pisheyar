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
using Role = Pisheyar.Domain.Entities.Role;

namespace Pisheyar.Infrastructure.Identity
{
    public class IdentityService : IIdentityService
    {
        private readonly IPisheyarContext _context;
        private readonly ISmsService _sms;
        private readonly IMapper _mapper;
        private readonly JwtSettings _jwtSettings;

        public IdentityService(IPisheyarContext context, ISmsService smsService, IMapper mapper, IOptions<JwtSettings> jwtSettings)
        {
            _context = context;
            _sms = smsService;
            _mapper = mapper;
            _jwtSettings = jwtSettings.Value;
        }

        public async Task<AuthenticateVm> Authenticate(string phoneNumber, string code, Guid roleGuid, bool rememberMe, bool isApplication = false)
        {
            bool userExistsInRole;
            int codeId = -1;

            User user = await _context.User
                .SingleOrDefaultAsync(x => x.PhoneNumber.Equals(phoneNumber) && !x.IsDelete);

            if (user == null) return new AuthenticateVm()
            {
                Message = "کاربری یافت نشد",
                State = (int)AuthenticateState.UserNotFound
            };

            switch (roleGuid.ToString())
            {
                case "46a09d81-c57f-4655-a8f5-027c66a6cfb1":
                    userExistsInRole = await _context.Admin
                        .AnyAsync(x => x.UserId == user.UserId);
                    codeId = 13;
                    break;

                case "91b3cdab-39c1-40fb-b077-a2d6e611f50a":
                    userExistsInRole = await _context.Client
                        .AnyAsync(x => x.UserId == user.UserId);
                    codeId = 14;
                    break;

                case "959b10a3-b8ed-4a9d-bdf3-17ec9b2ceb15":
                    userExistsInRole = await _context.Contractor
                        .AnyAsync(x => x.UserId == user.UserId);
                    codeId = 15;
                    break;

                default:
                    userExistsInRole = false;
                    break;
            }

            if (!userExistsInRole || codeId == -1) return new AuthenticateVm()
            {
                Message = "کاربری یافت نشد", 
                State = (int) AuthenticateState.UserNotFound
            };

            Token userToken = await _context.Token
                .Where(x => x.UserId == user.UserId && x.RoleCodeId == codeId && x.ExpireDate >= DateTime.Now)
                .OrderByDescending(x => x.ExpireDate)
                .FirstOrDefaultAsync();

            if (userToken == null) return new AuthenticateVm()
            {
                Message = "کدی یافت نشد",
                State = (int)AuthenticateState.CodeNotFound
            };

            if (!userToken.Value.ToString().Equals(code)) return new AuthenticateVm()
            {
                Message = "کد وارد شده اشتباه است",
                State = (int) AuthenticateState.WrongCode
            };

            if (!user.IsRegister)
            {
                user.IsRegister = true;
                user.IsActive = true;
                await _context.SaveChangesAsync(CancellationToken.None);
            }

            DateTime expireDate;

            if (isApplication)
            {
                expireDate = DateTime.Now.AddYears(1);
            }
            else
            {
                expireDate = rememberMe ? DateTime.Now.AddMonths(1) : DateTime.Now.AddDays(1);
            }

            return new AuthenticateVm() {
                Message = "عملیات موفق آمیز",
                State = (int)AuthenticateState.Success,
                Token = await GenerateJsonWebToken(user, expireDate, isApplication),
                Expires = expireDate.ToString("yyyy/MM/dd HH:mm:ss")
            };

            //return user.WithoutPassword();
        }

        private async Task<string> GenerateJsonWebToken(User user, DateTime expireDate, bool isApplication)
        {
            Role role = await _context.Role
                .Where(x => x.RoleId == user.RoleId)
                .SingleOrDefaultAsync();

            byte[] key = Encoding.ASCII.GetBytes(_jwtSettings.Key);
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(key);
            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            Claim[] claims = new[] {
                new Claim(ClaimTypes.NameIdentifier, user.UserGuid.ToString()),
                //new Claim(ClaimTypes.Sid, user.UserId.ToString()),
                new Claim(ClaimTypes.MobilePhone, user.PhoneNumber),
                new Claim(ClaimTypes.Role, role.DisplayName),
                //new Claim(JwtRegisteredClaimNames.Sub, userInfo.Username),
                //new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, user.UserGuid.ToString()),
                new Claim("IsApplication", isApplication.ToString()),
            };
            JwtSecurityToken token = new JwtSecurityToken(_jwtSettings.Issuer,
                _jwtSettings.Issuer,
                claims,
                expires: expireDate,
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<string> GetUserFullNameAsync(Guid userGuid)
        {
            return await _context.User
                .Where(x => x.UserGuid == userGuid)
                .Select(x => x.FirstName + " " + x.LastName)
                .SingleOrDefaultAsync();
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
