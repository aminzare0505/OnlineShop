using MediatR;
using OnlineShop.Application.Dto.Category;
using OnlineShop.Common.ResultPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Feature.CategoryType.Request.Command
{
    public class UpdateCategoryRequest:IRequest<VoidResult>
    {
        public UpdateCategoryDto UpdateCategoryDto { get; set; }
    }
}
