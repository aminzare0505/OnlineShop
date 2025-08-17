using FluentValidation;
using OnlineShop.Application.Abstractions;
using OnlineShop.Application.Feature.CategoryType.Request.Command;

namespace OnlineShop.Application.Feature.CategoryType.Handler.Command
{
    public sealed class CreateCategoryCommandValidation : Validation<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidation()
        {
            RuleFor(x => x.CreateCategoryDto.Name).NotEmpty().WithMessage("Category Name is required");
            RuleFor(x => x.CreateCategoryDto.Des).MaximumLength(200).WithMessage("Max Length of Description is 200 characters");
        }
    }
}
