using Pisheyar.Application.Common.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Pisheyar.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace WebUI.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IPisheyarContext _context;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor,
            IPisheyarContext context)
        {
            _context = context;

            if (httpContextAccessor.HttpContext != null &&
                httpContextAccessor.HttpContext.User != null)
            {
                ClaimsPrincipal claimsPrincipal = httpContextAccessor.HttpContext.User;

                NameIdentifier = claimsPrincipal.FindFirstValue(ClaimTypes.NameIdentifier);
                MobilePhone = claimsPrincipal.FindFirstValue(ClaimTypes.MobilePhone);
                Role = claimsPrincipal.FindFirstValue(ClaimTypes.Role);
            }
        }

        public string NameIdentifier { get; }

        public string MobilePhone { get; }

        public string Role { get; }

        public async Task<User> GetInfoAsync()
        {
            if (!string.IsNullOrEmpty(NameIdentifier))
            {
                User user = Role switch
                {
                    "ادمین" => await _context.User
                        .Include(x => x.Admin)
                        .SingleOrDefaultAsync(x => x.UserGuid == Guid.Parse(NameIdentifier) &&
                            x.PhoneNumber == MobilePhone && x.Role.DisplayName == Role),

                    "سرویس دهنده" => await _context.User
                        .Include(x => x.Contractor)
                        .SingleOrDefaultAsync(x => x.UserGuid == Guid.Parse(NameIdentifier) &&
                            x.PhoneNumber == MobilePhone && x.Role.DisplayName == Role),

                    "سرویس گیرنده" => await _context.User
                        .Include(x => x.Client)
                        .SingleOrDefaultAsync(x => x.UserGuid == Guid.Parse(NameIdentifier) &&
                            x.PhoneNumber == MobilePhone && x.Role.DisplayName == Role),

                    _ => null
                };
                
                if (user != null)
                    return user;
            }

            throw new UnauthorizedAccessException();
        }
    }
}
