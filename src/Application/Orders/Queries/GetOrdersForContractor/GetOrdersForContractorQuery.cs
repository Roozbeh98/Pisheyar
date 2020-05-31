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

namespace Pisheyar.Application.Orders.Queries.GetOrdersForContractor
{
    public class GetOrdersForContractorQuery : IRequest<GetOrdersForContractorVm>
    {
        public Guid? CategoryGuid { get; set; }

        public class OrdersListQueryHandler : IRequestHandler<GetOrdersForContractorQuery, GetOrdersForContractorVm>
        {
            private readonly IPisheyarContext _context;
            private readonly ICurrentUserService _currentUser;
            private readonly IMapper _mapper;

            public OrdersListQueryHandler(IPisheyarContext context, ICurrentUserService currentUserService, IMapper mapper)
            {
                _context = context;
                _currentUser = currentUserService;
                _mapper = mapper;
            }

            public async Task<GetOrdersForContractorVm> Handle(GetOrdersForContractorQuery request, CancellationToken cancellationToken)
            {
                User currentUser = await _context.User
                    .Where(x => x.UserGuid == Guid.Parse(_currentUser.NameIdentifier))
                    .SingleOrDefaultAsync(cancellationToken);

                if (currentUser == null)
                {
                    return new GetOrdersForContractorVm()
                    {
                        Message = "کاربر مورد نظر یافت نشد",
                        State = (int)GetOrdersForContractorState.UserNotFound
                    };
                }

                Contractor contractor = await _context.Contractor
                    .SingleOrDefaultAsync(x => x.UserId == currentUser.UserId, cancellationToken);

                if (contractor == null)
                {
                    return new GetOrdersForContractorVm()
                    {
                        Message = "سرویس دهنده مورد نظر یافت نشد",
                        State = (int)GetOrdersForContractorState.ContractorNotFound
                    };
                }

                IQueryable<Order> orders = _context.Order.AsQueryable();

                if (request.CategoryGuid == null)
                {
                    List<int> contractorCategoryIds = await _context.ContractorCategory
                        .Where(x => x.ContractorId == contractor.ContractorId)
                        .Select(x => x.CategoryId)
                        .ToListAsync(cancellationToken);

                    if (contractorCategoryIds.Count <= 0)
                    {
                        return new GetOrdersForContractorVm()
                        {
                            Message = "دسته بندی ای برای کاربر مورد نظر یافت نشد",
                            State = (int)GetOrdersForContractorState.NotAnyCategoriesFound
                        };
                    }

                    List<int> contractorOrderRequests = await _context.OrderRequest
                        .Where(x => x.ContractorId == contractor.ContractorId)
                        .Select(x => x.OrderId)
                        .ToListAsync(cancellationToken);

                    orders = orders
                        .Where(x => !contractorOrderRequests.Contains(x.OrderId) && contractorCategoryIds.Contains(x.CategoryId) && x.StateCodeId == 9);
                }
                else
                {
                    Category category = await _context.Category
                        .Where(x => x.CategoryGuid == request.CategoryGuid)
                        .SingleOrDefaultAsync(cancellationToken);

                    if (category == null) return new GetOrdersForContractorVm()
                    {
                        Message = "دسته بندی مورد نظر یافت نشد",
                        State = (int)GetOrdersForContractorState.CategoryNotFound
                    };

                    List<int> contractorOrderRequests = await _context.OrderRequest
                        .Where(x => x.ContractorId == contractor.ContractorId)
                        .Select(x => x.OrderId)
                        .ToListAsync(cancellationToken);

                    orders = orders
                        .Where(x => !contractorOrderRequests.Contains(x.OrderId) && x.CategoryId == category.CategoryId && x.StateCodeId == 9);
                }

                List<GetOrdersForContractorDto> ordersResult = await orders.ProjectTo<GetOrdersForContractorDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

                if (ordersResult.Count <= 0)
                {
                    return new GetOrdersForContractorVm()
                    {
                        Message = "سفارشی برای کاربر مورد نظر یافت نشد",
                        State = (int)GetOrdersForContractorState.NotAnyOrdersFound
                    };
                }

                return new GetOrdersForContractorVm()
                {
                    Message = "عملیات موفق آمیز",
                    State = (int)GetOrdersForContractorState.Success,
                    Orders = ordersResult
                };
            }
        }
    }
}
