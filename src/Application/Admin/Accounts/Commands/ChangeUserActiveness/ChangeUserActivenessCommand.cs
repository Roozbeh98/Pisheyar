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

namespace Pisheyar.Application.Accounts.Commands.ChangeUserActiveness
{
    public class ChangeUserActivenessCommand : IRequest<ChangeUserActivenessVm>
    {
        public Guid UserGuid { get; set; }

        public bool IsActive { get; set; }

        public class DeleteUserCommandHandler : IRequestHandler<ChangeUserActivenessCommand, ChangeUserActivenessVm>
        {
            private readonly IPisheyarMagContext _context;

            public DeleteUserCommandHandler(IPisheyarMagContext context)
            {
                _context = context;
            }

            public async Task<ChangeUserActivenessVm> Handle(ChangeUserActivenessCommand request, CancellationToken cancellationToken)
            {
                var query = await _context.TblUser.SingleOrDefaultAsync(x => x.UserGuid == request.UserGuid && !x.UserIsDelete);

                if (query != null)
                {
                    query.UserIsActive = request.IsActive;
                    query.UserModifyDate = DateTime.Now;

                    await _context.SaveChangesAsync(cancellationToken);

                    return new ChangeUserActivenessVm() { Message = "عملیات موفق آمیز", State = (int)ChangeUserActivenessState.Success };
                }

                return new ChangeUserActivenessVm() { Message = "کاربر مورد نظر یافت نشد", State = (int)ChangeUserActivenessState.UserNotFound };
            }
        }
    }
}
