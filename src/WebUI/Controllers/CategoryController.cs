using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pisheyar.Application.Categories.Commands.CreateCategory;
using Pisheyar.Application.Categories.Commands.DeleteCategory;
using Pisheyar.Application.Categories.Commands.UpdateCategory;
using Pisheyar.Application.Categories.Queries.GetAllCategories;
using Pisheyar.Application.Categories.Queries.GetCategoryByGuid;
using Pisheyar.Application.Categories.Queries.GetPrimaryCategories;

namespace WebUI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ApiController
    {
        /// <summary>
        /// دریافت اطلاعات دسته بندی از طریق آیدی
        /// </summary>
        /// <param name="id">آیدی دسته بندی</param>
        /// <returns></returns>
        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<CategoryVm>> GetById(int id)
        {
            return await Mediator.Send(new GetCategoryByGuidQuery() { CategoryId = id });
        }

        /// <summary>
        /// دریافت دسته بندی های اصلی
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        public async Task<ActionResult<PrimaryCategoriesVm>> GetPrimaries()
        {
            return await Mediator.Send(new GetPrimaryCategoriesQuery());
        }

        /// <summary>
        /// دریافت تمامی دسته بندی ها
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        public async Task<ActionResult<AllCategoriesVm>> GetAll()
        {
            return await Mediator.Send(new GetAllCategoriesQuery());
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
        /// <param name="id">آیدی دسته بندی</param>
        /// <returns></returns>
        [HttpPost("[action]/{id}")]
        public async Task<ActionResult<int>> Delete(int id)
        {
            return await Mediator.Send(new DeleteCategoryCommand { CategoryId = id });
        }
    }
}