using MediatR;
using OnlineShop.Application.Dto.Category;
using OnlineShop.Common.ResultPattern;
using OnlineShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Feature.CategoryType.Request.Command
{
    public class CreateCategoryRequestWithNotify : IRequest<Result<Category>>
    {
        public CreateCategoryDto CategoryCreateRequest { get; set; }
    }
}
