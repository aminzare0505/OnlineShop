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
    public class UpdateUserRequest:IRequest<VoidResult>
    {
        public UpdateUserDto UpdateUserDto{ get; set; }
    }
}
