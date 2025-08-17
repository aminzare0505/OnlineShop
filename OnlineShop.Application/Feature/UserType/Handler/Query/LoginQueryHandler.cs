using Microsoft.AspNetCore.Http.HttpResults;
using OnlineShop.Application.Abstractions;
using OnlineShop.Application.Feature.UserType.Request.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShop.Common.ResultPattern;
using OnlineShop.Domain.IRepositories;
using Microsoft.IdentityModel.Tokens;
using OnlineShop.Application.Dto.Common;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;

namespace OnlineShop.Application.Feature.UserType.Handler.Query
{
    internal sealed class LoginQueryHandler : IQueryHandler<LoginQuery, OnlineShop.Common.ResultPattern.Result<string>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;
        public LoginQueryHandler(IUserRepository userRepository, IConfiguration configuration)
        {
             _userRepository= userRepository;
            _configuration= configuration;
        }
        public async Task<OnlineShop.Common.ResultPattern.Result<string>> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByUserName(request.userDto.UserName);

            if (user == null)
            {
                return Result<string>.FailedResult("User not found");
            }

            var userpassword = request.userDto.password.Hashpassword(user.Salt);

            if (user.password != userpassword)
            {
                return Result<string>.FailedResult("Password incorrect");
            }

            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, request.userDto.UserName),
            new Claim(JwtRegisteredClaimNames.Jti, request.userDto.Id.ToString())
        };
            var Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));
            var Card = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: Card
            );
            return Result<string>.SuccessResult(new JwtSecurityTokenHandler().WriteToken(token).ToString());
        }
    }
}
