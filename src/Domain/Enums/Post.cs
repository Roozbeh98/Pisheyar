using System;
using System.Collections.Generic;
using System.Text;

namespace Pisheyar.Domain.Enums
{
    public enum CreatePostState
    {
        Success = 1,
        DocumentNotFound = 2,
        UserNotFound = 3,
        DocumentGuidProblem = 4
    }

    public enum UpdatePostState
    {
        Success = 1,
        DocumentNotFound = 2,
        UserNotFound = 3,
        PostNotFound = 4
    }

    public enum GetPostState
    {
        Success = 1,
        PostNotFound = 2
    }

    public enum GetAllPostsState
    {
        Success = 1,
        NoPosts = 2
    }

    public enum GetMostViewedPostsState
    {
        Success = 1,
        NoPosts = 2
    }

    public enum GetIndexPostsState
    {
        Success = 1,
        NoPosts = 2
    }

    public enum DeletePostState
    {
        Success = 1,
        PostNotFound = 2
    }
}
