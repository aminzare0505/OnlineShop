using FluentValidation;
using OnlineShop.Common.ResultPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Dto.Category.Validator
{
    public class UpdateCategoryValidation : AbstractValidator<CategoryUpdateDto>
    {
        public UpdateCategoryValidation()
        {
            RuleFor(x=>x.Id).NotEmpty().NotNull().WithMessage("Category ID is required");
            RuleFor(x => x.Name).NotEmpty().NotNull().WithMessage("Category Name is required");
            RuleFor(x => x.Des).MaximumLength(200).WithMessage("Max Length of Description is 200 characters");
        }
        public static async Task<VoidResult> UpdateCategoryValidate(CategoryUpdateDto categoryUpdateDto)
        {
            var IsValid = await new UpdateCategoryValidation().ValidateAsync(categoryUpdateDto);
            if (!IsValid.IsValid)
            {
                return VoidResult.VoidFailedResult(IsValid.Errors.Select(s => s.ErrorMessage).ToList());
            }
            else
                return VoidResult.VoidSuccessResult();

        }
    }
}
