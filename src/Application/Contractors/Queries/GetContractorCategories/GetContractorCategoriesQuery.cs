using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pisheyar.Application.Common.Interfaces;
using Pisheyar.Domain.Entities;
using Pisheyar.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pisheyar.Application.OrderRequests.Queries.GetContractorCategories
{
    public class GetContractorCategoriesQuery : IRequest<GetContractorCategoriesVm>
    {
        public class OrdersListQueryHandler : IRequestHandler<GetContractorCategoriesQuery, GetContractorCategoriesVm>
        {
            private readonly IPisheyarContext _context;
            private readonly ICurrentUserService _currentUser;

            public OrdersListQueryHandler(IPisheyarContext context, ICurrentUserService currentUserService)
            {
                _context = context;
                _currentUser = currentUserService;
            }

            public async Task<GetContractorCategoriesVm> Handle(GetContractorCategoriesQuery request, CancellationToken cancellationToken)
            {
                User currentUser = await _context.User
                    .Where(x => x.UserGuid == Guid.Parse(_currentUser.NameIdentifier))
                    .SingleOrDefaultAsync(cancellationToken);

                if (currentUser == null)
                {
                    return new GetContractorCategoriesVm()
                    {
                        Message = "کاربر مورد نظر یافت نشد",
                        State = (int)GetContractorCategoriesState.UserNotFound
                    };
                }

                Contractor contractor = await _context.Contractor
                    .SingleOrDefaultAsync(x => x.UserId == currentUser.UserId, cancellationToken);

                if (contractor == null)
                {
                    return new GetContractorCategoriesVm()
                    {
                        Message = "سرویس دهنده مورد نظر یافت نشد",
                        State = (int)GetContractorCategoriesState.ContractorNotFound
                    };
                }

                List<GetContractorCategoriesDto> contractorCategories = await _context.ContractorCategory
                    .Where(x => x.ContractorId == contractor.ContractorId)
                    .Select(x => new GetContractorCategoriesDto
                    {
                        CategoryGuid = x.Category.CategoryGuid,
                        Name = x.Category.DisplayName
                    }).ToListAsync(cancellationToken);

                if (contractorCategories.Count <= 0)
                {
                    return new GetContractorCategoriesVm()
                    {
                        Message = "خدمتی یافت نشد",
                        State = (int)GetContractorCategoriesState.NotAnyContractorCategoriesFound
                    };
                }

                return new GetContractorCategoriesVm()
                {
                    Message = "عملیات موفق آمیز",
                    State = (int)GetContractorCategoriesState.Success,
                    ContractorCategories = contractorCategories
                };
            }
        }
    }
}
