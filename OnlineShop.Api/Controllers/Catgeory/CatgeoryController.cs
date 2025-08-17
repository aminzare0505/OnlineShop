using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Dto.Category;
using OnlineShop.Application.Feature.CategoryType.Request.Command;
using OnlineShop.Application.Feature.CategoryType.Request.Notifications;
using OnlineShop.Application.Feature.CategoryType.Request.Query;

namespace OnlineShop.Api.Controllers.Catgeory
{
    public class CategoryController : BaseController
    {
        private readonly ISender _sender;
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator, ISender sender)
        {
            _mediator = mediator;
            _sender = sender;
        }
        [HttpGet("Get/{Id}")]
        public  async Task<IActionResult> Get(int id)
        {
            var result = await _mediator.Send(new GetCategoryRequest() {Id= id });
            return Ok(result);
        }
        [HttpPost("Add")]
        public async Task<IActionResult> Add(CreateCategoryDto createCategoryDto)
        {
            var result = await _mediator.Send(new CreateCategoryRequest() { CategoryCreateRequest = createCategoryDto });
            return Ok(result);
        }
        [HttpPost("SecoundAdd")]
        public async Task<IActionResult> SecoundAdd(CreateCategoryDto createCategoryDto, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new CreateCategoryCommand() {CreateCategoryDto= createCategoryDto }  );
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
        public async Task<IActionResult> Update(UpdateCategoryDto updateCategoryDto)
        {
            var result = await _mediator.Send(new UpdateCategoryRequest() { UpdateCategoryDto = updateCategoryDto });
            return Ok(result);
        }
        [HttpPost("AddWithNotify")]
        public async Task<IActionResult> AddWithNotify(CreateCategoryDto createCategoryDto)
        {
            var result = await _mediator.Send(new CreateCategoryRequestWithNotify() { CategoryCreateRequest = createCategoryDto });
            await _mediator.Publish(new CategoryAddedNotification(result.Data));
            return Ok(result);
        }
    }
} 
