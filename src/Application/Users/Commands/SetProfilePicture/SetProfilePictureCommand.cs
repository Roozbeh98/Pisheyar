using MediatR;
using Microsoft.EntityFrameworkCore;
using Pisheyar.Application.Common.Interfaces;
using Pisheyar.Domain.Entities;
using Pisheyar.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pisheyar.Application.Users.Commands.SetProfilePicture
{
    public class SetProfilePictureCommand : IRequest<SetProfilePictureVm>
    {
        public Guid UserGuid { get; set; }

        public string ProfileDocumentGuid { get; set; }

        public class SetProfilePictureCommandHandler : IRequestHandler<SetProfilePictureCommand, SetProfilePictureVm>
        {
            private readonly IPisheyarContext _context;

            public SetProfilePictureCommandHandler(IPisheyarContext context)
            {
                _context = context;
            }

            public async Task<SetProfilePictureVm> Handle(SetProfilePictureCommand request, CancellationToken cancellationToken)
            {
                User user = await _context.User
                    .SingleOrDefaultAsync(x => x.UserGuid == request.UserGuid, cancellationToken);

                if (user == null) return new SetProfilePictureVm
                {
                    Message = "کاربر مورد نظر یافت نشد",
                    State = (int)SetProfilePictureState.UserNotFound
                };

                Document profileDocument = await _context.Document
                    .SingleOrDefaultAsync(x => x.DocumentGuid == Guid.Parse(request.ProfileDocumentGuid), cancellationToken);

                if (profileDocument == null) return new SetProfilePictureVm()
                {
                    Message = "تصویر پروفایل کاربر مورد نظر یافت نشد",
                    State = (int)SetProfilePictureState.ProfileDocumentNotFound
                };

                user.ProfileDocumentId = profileDocument.DocumentId;
                user.ModifiedDate = DateTime.Now;

                await _context.SaveChangesAsync(cancellationToken);

                return new SetProfilePictureVm()
                {
                    Message = "عملیات موفق آمیز",
                    State = (int)SetProfilePictureState.Success
                };
            }
        }
    }
}
