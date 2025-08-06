using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Dto.Product;
using OnlineShop.Application.Feature.ProductType.Request.Command;
using OnlineShop.Application.Feature.ProductType.Request.Query;

namespace OnlineShop.Api.Controllers.Product
{
    public class ProductController : BaseController
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("Get")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _mediator.Send(new GetProductByIdRequest() { Id = id });
            return Ok(result);
        }
        [HttpPost("Add")]
        public async Task<IActionResult> Add(CreateProductDto createProductDto)
        {
            var result = await _mediator.Send(new CreateProductRequest() { CreateProductDto = createProductDto });
            return Ok(result);
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllProductRequest());
            return Ok(result);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteProductRequest() { Id=id});
            return Ok(result);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update(UpdateProductDto updateProductDto)
        {
            var result = await _mediator.Send(new UpdateProductRequest() { UpdateProductDto = updateProductDto });
            return Ok(result);
        }
    }
}
