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

namespace Pisheyar.Application.Accounts.Commands.DeleteUser
{
    public class DeleteUserCommand : IRequest<DeleteUserVm>
    {
        public Guid UserGuid { get; set; }

        public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, DeleteUserVm>
        {
            private readonly IPisheyarMagContext _context;

            public DeleteUserCommandHandler(IPisheyarMagContext context)
            {
                _context = context;
            }

            public async Task<DeleteUserVm> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
            {
                var query = await _context.TblUser.SingleOrDefaultAsync(x => x.UserGuid == request.UserGuid && !x.UserIsDelete);

                if (query != null)
                {
                    query.UserIsDelete = true;
                    query.UserModifyDate = DateTime.Now;

                    await _context.SaveChangesAsync(cancellationToken);

                    return new DeleteUserVm() { Message = "عملیات موفق آمیز", State = (int)DeleteUserState.Success };
                }

                return new DeleteUserVm() { Message = "کاربر مورد نظر یافت نشد", State = (int)DeleteUserState.UserNotFound };
            }
        }
    }
}
