using MediatR;
using OnlineShop.Application.Dto.Category;
using OnlineShop.Common.ResultPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Feature.CategoryType.Request.Query
{
    public class GetCategoryRequest:IRequest<Result<CategoryDto>>
    {
        public int Id  { get; set; }
    }
}
