using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Pisheyar.Application.Posts.Commands.ChangePostCommentAcceptance;
using Pisheyar.Application.Posts.Commands.ChangePostShow;
using Pisheyar.Application.Posts.Commands.CreatePost;
using Pisheyar.Application.Posts.Commands.CreatePostComment;
using Pisheyar.Application.Posts.Commands.DeletePost;
using Pisheyar.Application.Posts.Commands.DeletePostComment;
using Pisheyar.Application.Posts.Commands.LikePost;
using Pisheyar.Application.Posts.Commands.UpdatePost;
using Pisheyar.Application.Posts.Queries.GetAcceptedPostComments;
using Pisheyar.Application.Posts.Queries.GetAllPosts;
using Pisheyar.Application.Posts.Queries.GetPost;
using Pisheyar.Application.Posts.Queries.GetPostsByCategory;
using Pisheyar.Application.Posts.Queries.GetPostsByPagination;
using Pisheyar.Application.Posts.Queries.GetRejectedPostCommentsQuery;
using Swashbuckle.AspNetCore.Annotations;

namespace WebUI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ApiController
    {
        [HttpGet("[action]/{guid}")]
        public async Task<ActionResult<GetPostVm>> GetByGuid(Guid guid)
        {
            return await Mediator.Send(new GetPostQuery() { Guid = guid });
        }

        [HttpGet("[action]/{categoryId}/{page}")]
        public async Task<ActionResult<GetPostsByCategoryVm>> GetByCategory(int categoryId, int page)
        {
            return await Mediator.Send(new GetPostsByCategoryQuery() { CategoryId = categoryId, Page = page });
        }

        /// <summary>
        /// لیست تمام پست ها
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        public async Task<ActionResult<GetAllPostVm>> GetAll()
        {
            return await Mediator.Send(new GetAllPostsQuery());
        }

        [HttpGet("[action]/{page}")]
        public async Task<ActionResult<GetPostsByPaginationVm>> GetByPagination(int page)
        {
            return await Mediator.Send(new GetPostsByPaginationQuery() { Page = page });
        }

        [HttpGet("{postId}/[action]")]
        public async Task<ActionResult<AcceptedPostCommentsVm>> GetAcceptedComments(int postId)
        {
            return await Mediator.Send(new GetAcceptedPostCommentsQuery() { PostId = postId });
        }

        [HttpGet("{postId}/[action]")]
        public async Task<ActionResult<RejectedPostCommentsVm>> GetRejectedComments(int postId)
        {
            return await Mediator.Send(new GetRejectedPostCommentsQuery() { PostId = postId });
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<int>> Create(CreatePostCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<int>> Like(LikePostCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<int>> ChangeShow(ChangePostShowCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<int>> CreateComment(CreatePostCommentCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<int>> ChangeCommentAcceptance(ChangePostCommentAcceptanceCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("[action]")]
        public async Task<ActionResult<int>> Update(UpdatePostCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpDelete("[action]/{id}")]
        public async Task<ActionResult<int>> Delete(int id)
        {
            return await Mediator.Send(new DeletePostCommand { PostId = id });
        }

        [HttpDelete("[action]/{id}")]
        public async Task<ActionResult<int>> DeleteComment(int id)
        {
            return await Mediator.Send(new DeletePostCommentCommand { PostCommentId = id });
        }
    }
}