using System;
using System.Collections.Generic;
using System.Text;

namespace Pisheyar.Application.Tags.Queries.GetAllTags
{
    public class AllTagsVm
    {
        public string Message { get; set; }

        public bool Result { get; set; }

        public List<AllTagDto> Tags { get; set; }
    }
}
