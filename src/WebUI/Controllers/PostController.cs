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
        /// <summary>
        /// دریافت اطلاعات پست از طریق آیدی
        /// </summary>
        /// <param name="guid">آیدی</param>
        /// <returns></returns>
        [HttpGet("[action]/{guid}")]
        public async Task<ActionResult<GetPostVm>> GetByGuid(Guid guid)
        {
            return await Mediator.Send(new GetPostQuery() { Guid = guid });
        }

        /// <summary>
        /// دریافت پست ها از طریق دسته بندی
        /// </summary>
        /// <param name="categoryId">آیدی دسته بندی</param>
        /// <param name="page">شماره صفحه</param>
        /// <returns></returns>
        [HttpGet("[action]/{categoryId}/{page}")]
        public async Task<ActionResult<GetPostsByCategoryVm>> GetByCategory(int categoryId, int page)
        {
            return await Mediator.Send(new GetPostsByCategoryQuery() { CategoryId = categoryId, Page = page });
        }

        /// <summary>
        /// دریافت تمامی پست ها
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        public async Task<ActionResult<GetAllPostVm>> GetAll()
        {
            return await Mediator.Send(new GetAllPostsQuery());
        }

        /// <summary>
        /// دریافت پست ها از طریق شماره صفحه
        /// </summary>
        /// <param name="page">شماره صفحه</param>
        /// <returns></returns>
        [HttpGet("[action]/{page}")]
        public async Task<ActionResult<GetPostsByPaginationVm>> GetByPagination(int page)
        {
            return await Mediator.Send(new GetPostsByPaginationQuery() { Page = page });
        }

        /// <summary>
        /// دریافت نظرات پذیرفته شده
        /// </summary>
        /// <param name="postId">آیدی پست</param>
        /// <returns></returns>
        [HttpGet("{postId}/[action]")]
        public async Task<ActionResult<AcceptedPostCommentsVm>> GetAcceptedComments(int postId)
        {
            return await Mediator.Send(new GetAcceptedPostCommentsQuery() { PostId = postId });
        }

        /// <summary>
        /// دریافت نظرات پذیرفته نشده
        /// </summary>
        /// <param name="postId">آیدی پست</param>
        /// <returns></returns>
        [HttpGet("{postId}/[action]")]
        public async Task<ActionResult<RejectedPostCommentsVm>> GetRejectedComments(int postId)
        {
            return await Mediator.Send(new GetRejectedPostCommentsQuery() { PostId = postId });
        }

        /// <summary>
        /// افزودن پست جدید
        /// </summary>
        /// <param name="command">اطلاعات پست</param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public async Task<ActionResult<CreatePostCommandVm>> Create(CreatePostCommand command)
        {
            return await Mediator.Send(command);
        }

        /// <summary>
        /// لایک پست
        /// </summary>
        /// <param name="command">آیدی پست</param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public async Task<ActionResult<int>> Like(LikePostCommand command)
        {
            return await Mediator.Send(command);
        }

        /// <summary>
        /// تغییر وضعیت نمایش پست
        /// </summary>
        /// <param name="command">اطلاعات لازم</param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public async Task<ActionResult<int>> ChangeShow(ChangePostShowCommand command)
        {
            return await Mediator.Send(command);
        }

        /// <summary>
        /// افزودن نظر جدید
        /// </summary>
        /// <param name="command">اطلاعات نظر</param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public async Task<ActionResult<int>> CreateComment(CreatePostCommentCommand command)
        {
            return await Mediator.Send(command);
        }

        /// <summary>
        /// تغییر وضعیت پذیرش نظر
        /// </summary>
        /// <param name="command">اطلاعات لازم</param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public async Task<ActionResult<int>> ChangeCommentAcceptance(ChangePostCommentAcceptanceCommand command)
        {
            return await Mediator.Send(command);
        }

        /// <summary>
        /// ویرایش پست
        /// </summary>
        /// <param name="command">اطلاعات نظر</param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public async Task<ActionResult<UpdatePostCommandVm>> Update(UpdatePostCommand command)
        {
            return await Mediator.Send(command);
        }

        /// <summary>
        /// حذف پست
        /// </summary>
        /// <param name="id">آیدی پست</param>
        /// <returns></returns>
        [HttpPost("[action]/{id}")]
        public async Task<ActionResult<int>> Delete(int id)
        {
            return await Mediator.Send(new DeletePostCommand { PostId = id });
        }

        /// <summary>
        /// حذف نظر
        /// </summary>
        /// <param name="id">آیدی نظر</param>
        /// <returns></returns>
        [HttpPost("[action]/{id}")]
        public async Task<ActionResult<int>> DeleteComment(int id)
        {
            return await Mediator.Send(new DeletePostCommentCommand { PostCommentId = id });
        }
    }
}