using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Pisheyar.Application.Categories.Commands.CreateCategory;
using Pisheyar.Application.Categories.Commands.DeleteCategory;
using Pisheyar.Application.Categories.Commands.SetCategoryDetails;
using Pisheyar.Application.Categories.Commands.UpdateCategory;
using Pisheyar.Application.Categories.Queries.GetAllCategories;
using Pisheyar.Application.Categories.Queries.GetAllCategoriesName;
using Pisheyar.Application.Categories.Queries.GetCategoryByGuid;
using Pisheyar.Application.Categories.Queries.GetPrimaryCategories;
using Pisheyar.Application.Categories.Queries.SearchCategories;
using Pisheyar.Application.Categories.Queries.SearchCategoriesByCity;

namespace WebUI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ApiController
    {
        private readonly IWebHostEnvironment _hostingEnvironment;

        public CategoryController(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        /// <summary>
        /// دریافت اطلاعات دسته بندی از طریق آیدی
        /// </summary>
        /// <param name="categoryGuid">آیدی دسته بندی</param>
        /// <param name="includeChildren">شامل زیر دسته ها؟</param>
        /// <returns></returns>
        [HttpGet("{categoryGuid}")]
        [AllowAnonymous]
        public async Task<ActionResult<CategoryVm>> GetByGuid(Guid categoryGuid, bool includeChildren = true)
        {
            return await Mediator.Send(new GetCategoryByGuidQuery() { CategoryGuid = categoryGuid, IncludeChildren = includeChildren });
        }

        /// <summary>
        /// دریافت دسته بندی های اصلی
        /// </summary>
        /// <param name="guid">آیدی دسته بندی</param>
        /// <returns></returns>
        [HttpGet("[action]")]
        [AllowAnonymous]
        public async Task<ActionResult<PrimaryCategoriesVm>> GetPrimaries(Guid? guid)
        {
            return await Mediator.Send(new GetPrimaryCategoriesQuery() { CategoryGuid = guid});
        }

        /// <summary>
        /// دریافت تمامی دسته بندی ها
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        [AllowAnonymous]
        public async Task<ActionResult<AllCategoriesVm>> GetAll()
        {
            return await Mediator.Send(new GetAllCategoriesQuery());
        }

        /// <summary>
        /// دریافت نام تمامی دسته بندی ها
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        [AllowAnonymous]
        public async Task<ActionResult<AllCategoriesNameVm>> GetAllNames()
        {
            return await Mediator.Send(new GetAllCategoriesNameQuery());
        }

        /// <summary>
        /// جستجو دسته بندی ها بر اساس شهر
        /// </summary>
        /// <param name="cityGuid">آیدی شهر</param>
        /// <param name="searchInput">دسته بندی</param>
        /// <returns></returns>
        [HttpGet("[action]")]
        [AllowAnonymous]
        public async Task<ActionResult<SearchCategoriesByCityVm>> SearchByCity(Guid cityGuid, string searchInput)
        {
            return await Mediator.Send(new SearchCategoriesByCityQuery() { CityGuid = cityGuid, SearchInput = searchInput });
        }

        /// <summary>
        /// جستجو دسته بندی ها
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        [AllowAnonymous]
        public async Task<ActionResult<SearchCategoriesVm>> Search(string input)
        {
            return await Mediator.Send(new SearchCategoriesQuery() { Input = input });
        }

        /// <summary>
        /// افزودن دسته بندی جدید
        /// </summary>
        /// <param name="command">اطلاعات دسته بندی</param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public async Task<ActionResult<int>> Create(CreateCategoryCommand command)
        {
            return await Mediator.Send(command);
        }

        /// <summary>
        /// افزودن جزئیات دسته بندی
        /// </summary>
        /// <param name="command">اطلاعات دسته بندی</param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public async Task<ActionResult<SetCategoryDetailsVm>> SetDetails(SetCategoryDetailsDto command)
        {
            return await Mediator.Send(new SetCategoryDetailsCommand { Command = command, WebRootPath = _hostingEnvironment.WebRootPath });
        }

        /// <summary>
        /// ویرایش دسته بندی
        /// </summary>
        /// <param name="command">اطلاعات لازم</param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public async Task<ActionResult<int>> Update(UpdateCategoryCommand command)
        {
            return await Mediator.Send(command);
        }

        /// <summary>
        /// حذف دسته بندی
        /// </summary>
        /// <param name="command">آیدی دسته بندی</param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public async Task<ActionResult<DeleteCategoryVm>> Delete(DeleteCategoryCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}