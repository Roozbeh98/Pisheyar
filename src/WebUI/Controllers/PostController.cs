using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
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
using Pisheyar.Application.Posts.Queries.GetIndexPosts;
using Pisheyar.Application.Posts.Queries.GetMonthlyMostViewedPosts;
using Pisheyar.Application.Posts.Queries.GetMostViewedPosts;
using Pisheyar.Application.Posts.Queries.GetPost;
using Pisheyar.Application.Posts.Queries.GetPostsByCategory;
using Pisheyar.Application.Posts.Queries.GetPostsByPagination;
using Pisheyar.Application.Posts.Queries.GetRejectedPostCommentsQuery;
using Pisheyar.Application.Posts.Queries.GetWeeklyMostViewedPosts;
using Swashbuckle.AspNetCore.Annotations;

namespace WebUI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ApiController
    {
        private readonly IWebHostEnvironment _hostingEnvironment;

        public PostController(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

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
        /// <param name="categoryGuid">آیدی دسته بندی</param>
        /// <param name="page">شماره صفحه</param>
        /// <returns></returns>
        [HttpGet("[action]/{categoryId}/{page}")]
        public async Task<ActionResult<GetPostsByCategoryVm>> GetByCategory(Guid categoryGuid, int page)
        {
            return await Mediator.Send(new GetPostsByCategoryQuery() { CategoryGuid = categoryGuid, Page = page });
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
        /// دریافت تمامی پست ها Anonymous
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        [AllowAnonymous]
        public async Task<ActionResult<GetAllPostVm>> GetAllAnonymous()
        {
            return await Mediator.Send(new GetAllPostsQuery());
        }

        /// <summary>
        /// دریافت 3 پست شاخص Anonymous
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        [AllowAnonymous]
        public async Task<ActionResult<GetIndexPostsVm>> GetIndexesAnonymous()
        {
            return await Mediator.Send(new GetIndexPostsQuery());
        }

        /// <summary>
        /// دریافت 5 پست منتخب هفته Anonymous
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        [AllowAnonymous]
        public async Task<ActionResult<GetWeeklyMostViewedPostsVm>> GetWeeklyMostViewed()
        {
            return await Mediator.Send(new GetWeeklyMostViewedPostsQuery());
        }

        /// <summary>
        /// دریافت 5 پست منتخب ماه Anonymous
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        [AllowAnonymous]
        public async Task<ActionResult<GetMonthlyMostViewedPostsVm>> GetMonthlyMostViewed()
        {
            return await Mediator.Send(new GetMonthlyMostViewedPostsQuery());
        }

        /// <summary>
        /// دریافت 15 پست پربازدید Anonymous
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        [AllowAnonymous]
        public async Task<ActionResult<GetMostViewedPostsVm>> GetMostViewedAnonymous()
        {
            return await Mediator.Send(new GetMostViewedPostsQuery());
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
        /// <param name="postGuid">آیدی پست</param>
        /// <returns></returns>
        [HttpGet("{postGuid}/[action]")]
        public async Task<ActionResult<AcceptedPostCommentsVm>> GetAcceptedComments(Guid postGuid)
        {
            return await Mediator.Send(new GetAcceptedPostCommentsQuery() { PostGuid = postGuid });
        }

        /// <summary>
        /// دریافت نظرات پذیرفته نشده
        /// </summary>
        /// <param name="postGuid">آیدی پست</param>
        /// <returns></returns>
        [HttpGet("{postGuid}/[action]")]
        public async Task<ActionResult<RejectedPostCommentsVm>> GetRejectedComments(Guid postGuid)
        {
            return await Mediator.Send(new GetRejectedPostCommentsQuery() { PostGuid = postGuid });
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
        public async Task<ActionResult<UpdatePostCommandVm>> Update(UpdatePostCommandDto command)
        {
            return await Mediator.Send(new UpdatePostCommand { Command = command, WebRootPath = _hostingEnvironment.WebRootPath });
        }

        /// <summary>
        /// حذف پست
        /// </summary>
        /// <param name="guid">آیدی پست</param>
        /// <returns></returns>
        [HttpPost("[action]/{guid}")]
        public async Task<ActionResult<DeletePostCommandVm>> Delete(Guid guid)
        {
            return await Mediator.Send(new DeletePostCommand { PostGuid = guid });
        }

        /// <summary>
        /// حذف نظر
        /// </summary>
        /// <param name="guid">آیدی نظر</param>
        /// <returns></returns>
        [HttpPost("[action]/{guid}")]
        public async Task<ActionResult<int>> DeleteComment(Guid guid)
        {
            return await Mediator.Send(new DeletePostCommentCommand { PostCommentGuid = guid });
        }
    }
}