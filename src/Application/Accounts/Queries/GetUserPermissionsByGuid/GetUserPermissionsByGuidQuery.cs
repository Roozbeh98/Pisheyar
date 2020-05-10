using System;
using System.Collections.Generic;
using System.Text;
using Pisheyar.Application.Common.Interfaces;
using Pisheyar.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Pisheyar.Domain.Enums;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;
using AutoMapper;

namespace Pisheyar.Application.Accounts.Queries.GetUserPermissionsByGuid
{
    public class GetUserPermissionsByGuidQuery : IRequest<UserPermissionsVm>
    {
        public Guid UserGuid { get; set; }

        public class GetUserPermissionsByGuidQueryHandler : IRequestHandler<GetUserPermissionsByGuidQuery, UserPermissionsVm>
        {
            private readonly IPisheyarContext _context;

            public GetUserPermissionsByGuidQueryHandler(IPisheyarContext context)
            {
                _context = context;
            }

            public async Task<UserPermissionsVm> Handle(GetUserPermissionsByGuidQuery request, CancellationToken cancellationToken)
            {
                var user = await _context.User
                    .SingleOrDefaultAsync(x => x.UserGuid.Equals(request.UserGuid) && !x.IsDelete, cancellationToken);

                if (user != null)
                {
                    var rolePermissions = await (from rp in _context.RolePermission
                                                 where rp.RoleId == user.RoleId
                                                 join p in _context.Permission on rp.PermissionId equals p.PermissionId
                                                 select new RolePermissionDto
                                                 {
                                                     PermissionDisplay = p.DisplayName,
                                                     RpModifyDate = rp.ModifiedDate
                                                 }).ToListAsync(cancellationToken);

                    var customPermissions = await _context.UserPermission
                        .Where(x => x.UserId == user.UserId)
                        .Join(_context.Permission, up => up.PermissionId, p => p.PermissionId, (up, p) => new { up, p })
                        .Select(x => new CustomPermissionDto
                        {
                            PermissionDisplay = x.p.DisplayName,
                            UpModifyDate = x.up.ModifiedDate
                        }).ToListAsync(cancellationToken);

                    return new UserPermissionsVm()
                    {
                        Message = "عملیات موفق آمیز",
                        Result = true,
                        RolePermissions = rolePermissions,
                        CustomPermissions = customPermissions
                    };
                }

                return new UserPermissionsVm()
                {
                    Message = "کاربری یافت نشد",
                    Result = false,
                    RolePermissions = null,
                    CustomPermissions = null
                };
            }
        }
    }
}
