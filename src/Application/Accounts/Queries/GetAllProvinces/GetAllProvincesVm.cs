using System;
using System.Collections.Generic;
using System.Text;

namespace Pisheyar.Application.Accounts.Queries.GetAllProvinces
{
    public class GetAllProvincesVm
    {
        public string Message { get; set; }

        public int State { get; set; }

        public IEnumerable<GetAllProvincesDto> Provinces { get; set; }
    }
}
