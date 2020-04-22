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
            private readonly IPisheyarMagContext _context;

            public GetUserPermissionsByGuidQueryHandler(IPisheyarMagContext context)
            {
                _context = context;
            }

            public async Task<UserPermissionsVm> Handle(GetUserPermissionsByGuidQuery request, CancellationToken cancellationToken)
            {
                var user = await _context.TblUser
                    .SingleOrDefaultAsync(x => x.UserGuid.Equals(request.UserGuid) && !x.UserIsDelete, cancellationToken);

                if (user != null)
                {
                    var rolePermissions = await (from rp in _context.TblRolePermission
                                                 where rp.RpRoleId == user.UserRoleId
                                                 join p in _context.TblPermission on rp.RpPermissionId equals p.PermissionId
                                                 select new RolePermissionDto
                                                 {
                                                     PermissionDisplay = p.PermissionDisplay,
                                                     RpCreateDate = rp.RpCreateDate,
                                                     RpModifyDate = rp.RpModifyDate
                                                 }).ToListAsync(cancellationToken);

                    var customPermissions = await _context.TblUserPermission
                        .Where(x => x.UpUserGuid == user.UserGuid)
                        .Join(_context.TblPermission, up => up.UpPermissionId, p => p.PermissionId, (up, p) => new { up, p })
                        .Select(x => new CustomPermissionDto
                        {
                            PermissionDisplay = x.p.PermissionDisplay,
                            UpCreateDate = x.up.UpCreateDate,
                            UpModifyDate = x.up.UpModifyDate
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
