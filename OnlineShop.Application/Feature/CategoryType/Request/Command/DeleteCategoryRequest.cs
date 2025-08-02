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
    public class DeleteCategoryRequest : IRequest<VoidResult>
    {
        public CategoryDto CategoryDtoRequest { get; set; }
    }
}
