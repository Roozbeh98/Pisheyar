using System;
using System.Collections.Generic;
using System.Text;

namespace Pisheyar.Domain.Enums
{
    public enum CreatePostState
    {
        Success = 1,
        DocumentNotFound = 2,
        UserNotFound = 3
    }

    public enum UpdatePostState
    {
        Success = 1,
        PostNotFound = 2
    }

    public enum GetPostState
    {
        Success = 1,
        PostNotFound = 2
    }
}
