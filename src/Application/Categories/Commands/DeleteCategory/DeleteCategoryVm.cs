using System;
using System.Collections.Generic;
using System.Text;

namespace Pisheyar.Application.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryVm
    {
        public string Message { get; set; }

        public int State { get; set; }

        public int DeletedRecordsCount { get; set; } = 0;
    }
}
