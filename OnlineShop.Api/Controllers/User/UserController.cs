using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Dto.Product;
using OnlineShop.Application.Dto.User;
using OnlineShop.Application.Feature.ProductType.Request.Command;
using OnlineShop.Application.Feature.ProductType.Request.Query;
using OnlineShop.Application.Feature.UserType.Request.Command;
using OnlineShop.Application.Feature.UserType.Request.Query;

namespace OnlineShop.Api.Controllers.User
{
    public class UserController : BaseController
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserDto userDto)
        {
            var result = await _mediator.Send(new LoginQuery() { userDto = userDto });
            return Ok(result);
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register(CreateUserDto createUserDto)
        {
            var result = await _mediator.Send(new CreateUserRequest() {CreateUserDto = createUserDto });
            return Ok(result);
        }
    }
}
/*
 * {
  "fullName": "AminZare",
  "userName": "AminZare05052",
  "email": "AminZare@gmail.com",
  "password": "@Min123",
  "salt": "string"
}
*/