using FluentValidation;
using OnlineShop.Application.Dto.Category;
using OnlineShop.Application.Feature.CategoryType.Request.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Feature.CategoryType.Handler.Command
{
    public sealed class CreateCategoryCommandValidation : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidation()
        {
            RuleFor(x => x.CreateCategoryDto.Name).NotEmpty().WithMessage("Category Name is required");
            RuleFor(x => x.CreateCategoryDto.Des).MaximumLength(200).WithMessage("Max Length of Description is 200 characters");
        }
    }
}
