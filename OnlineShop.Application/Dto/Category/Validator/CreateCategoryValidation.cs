using FluentValidation;
using MediatR;
using Microsoft.Extensions.Options;
using OnlineShop.Common.ResultPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Dto.Category.Validator
{
    public class CreateCategoryValidation : AbstractValidator<CreateCategoryDto>
    {
        public CreateCategoryValidation()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Category Name is required");
            RuleFor(x => x.Des).MaximumLength(200).WithMessage("Max Length of Description is 200 characters");
        }
        public static async Task<VoidResult> CreateCategoryValidate( CreateCategoryDto categoryCreateDto)
        { 
            var IsValid = await new CreateCategoryValidation().ValidateAsync(categoryCreateDto);
            if (!IsValid.IsValid)
            {
                return VoidResult.VoidFailedResult(IsValid.Errors.Select(s => s.ErrorMessage).ToList());
            }
            else
                return VoidResult.VoidSuccessResult();

        }
    }
}
