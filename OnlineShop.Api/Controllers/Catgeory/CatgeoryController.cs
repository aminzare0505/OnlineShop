using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Dto.Category;
using OnlineShop.Application.Feature.CategoryType.Request.Command;
using OnlineShop.Application.Feature.CategoryType.Request.Query;

namespace OnlineShop.Api.Controllers.Catgeory
{
    public class CatgeoryController : BaseController
    {
        private readonly IMediator _mediator;

        public CatgeoryController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("Get/{Id}")]
        public  async Task<IActionResult> Get(int id)
        {
            var result = await _mediator.Send(new GetCategoryRequest() {Id= id });
            return Ok(result);
        }
        [HttpPost("Add")]
        public async Task<IActionResult> Add(CategoryCreateDto categoryCreateDto)
        {
            var result = await _mediator.Send(new CreateCategoryRequest() { CategoryCreateRequest = categoryCreateDto });
            return Ok(result);
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllCategoryRequest());
            return Ok(result);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(CategoryDto categoryDto)
        {
            var result = await _mediator.Send(new DeleteCategoryRequest() { CategoryDtoRequest = categoryDto });
            return Ok(result);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update(CategoryUpdateDto categoryUpdateDto)
        {
            var result = await _mediator.Send(new UpdateCategoryRequest() { CategoryUpdateRequest = categoryUpdateDto });
            return Ok(result);
        }
    }
}
