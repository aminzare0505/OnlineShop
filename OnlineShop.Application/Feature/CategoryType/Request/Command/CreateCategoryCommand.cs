using OnlineShop.Application.Abstractions;
using OnlineShop.Application.Dto.Category;
using OnlineShop.Common.ResultPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OnlineShop.Application.Feature.CategoryType.Request.Command
{
    public sealed record CreateCategoryCommand() :ICommand<VoidResult>
    {
        public CreateCategoryDto CreateCategoryDto { get; set; }
    }
}
