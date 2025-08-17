using OnlineShop.Application.Abstractions;
using OnlineShop.Application.Dto.User;
using OnlineShop.Common.ResultPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Feature.UserType.Request.Query
{
    public sealed class LoginQuery:IQuery<Result<string>>
    {
        public UserDto userDto{ get; set; }
    }
}
