using AutoMapper;
using Pisheyar.Application.Common;
using Pisheyar.Application.Common.Mappings;
using Pisheyar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pisheyar.Application.OrderRequests.Queries.GetContractorOrderRequests
{
    public class GetContractorOrderRequestsDto : IMapFrom<OrderRequest>
    {
        public Guid OrderRequestGuid { get; set; }

        public string Contractor { get; set; }

        public string Category { get; set; }

        public string Message { get; set; }

        public long OfferedPrice { get; set; }

        public string ModifiedDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<OrderRequest, GetContractorOrderRequestsDto>()
                .ForMember(d => d.Contractor, opt => opt.MapFrom(s => s.Contractor.User.FirstName + " " + s.Contractor.User.LastName))
                .ForMember(d => d.Category, opt => opt.MapFrom(s => s.Order.Category.DisplayName))
                .ForMember(d => d.ModifiedDate, opt => opt.MapFrom(s => PersianDateExtensionMethods.ToPeString(s.ModifiedDate, "yyyy/MM/dd HH:mm")));
        }
    }
}
