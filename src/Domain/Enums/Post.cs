using System;
using System.Collections.Generic;
using System.Text;

namespace Pisheyar.Domain.Enums
{
    public enum CreatePostState
    {
        Success = 1
    }

    public enum UpdatePostState
    {
        Success = 1,
        PostNotFound = 2
    }
}
