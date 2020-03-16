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
        [HttpGet("[action]/{guid}")]
        public async Task<ActionResult<CategoryVm>> GetByGuid(Guid guid)
        {
            return await Mediator.Send(new GetCategoryByGuidQuery() { CategoryGuid = guid });
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<PrimaryCategoriesVm>> GetPrimaries()
        {
            return await Mediator.Send(new GetPrimaryCategoriesQuery());
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<AllCategoriesVm>> GetAll()
        {
            return await Mediator.Send(new GetAllCategoriesQuery());
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<int>> Create(CreateCategoryCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("[action]")]
        public async Task<ActionResult<int>> Update(UpdateCategoryCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpDelete("[action]/{id}")]
        public async Task<ActionResult<int>> Delete(int id)
        {
            return await Mediator.Send(new DeleteCategoryCommand { CategoryId = id });
        }
    }
}