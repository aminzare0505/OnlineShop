using MediatR;
using OnlineShop.Application.Dto.User;
using OnlineShop.Common.ResultPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Feature.UserType.Request.Command
{
    public class CreateUserRequest:IRequest<VoidResult>
    {
        public CreateUserDto CreateUserDto { get; set; }
    }
}
