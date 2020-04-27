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
            private readonly IPisheyarContext _context;

            public DeleteUserCommandHandler(IPisheyarContext context)
            {
                _context = context;
            }

            public async Task<ChangeUserActivenessVm> Handle(ChangeUserActivenessCommand request, CancellationToken cancellationToken)
            {
                var query = await _context.User.SingleOrDefaultAsync(x => x.UserGuid == request.UserGuid && !x.IsDelete);

                if (query != null)
                {
                    query.IsActive = request.IsActive;
                    query.ModifiedDate = DateTime.Now;

                    await _context.SaveChangesAsync(cancellationToken);

                    return new ChangeUserActivenessVm() { Message = "عملیات موفق آمیز", State = (int)ChangeUserActivenessState.Success };
                }

                return new ChangeUserActivenessVm() { Message = "کاربر مورد نظر یافت نشد", State = (int)ChangeUserActivenessState.UserNotFound };
            }
        }
    }
}
