using OnlineShop.Application.Dto.Category.Validator;
using OnlineShop.Application.Dto.Category;
using OnlineShop.Common.ResultPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using OnlineShop.Domain.IRepositories;

namespace OnlineShop.Application.Dto.Product.Validator
{
    public class CreateProductValidation : AbstractValidator<CreateProductDto>
    {
        private ICategoryRepository _categoryRepository;
        public CreateProductValidation(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
            RuleFor(x => x.Description).MaximumLength(200).WithMessage("Max Length of Description is 200 characters");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Product Name is required").MaximumLength(150)
           .WithMessage("Max Length of Product Name is 150 characters");
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price Must be greater than zero");
            RuleFor(x => x.CategoryId).MustAsync(async (CategoryId, Token) =>
            {
                var result = await _categoryRepository.CheckExistCatgery(CategoryId);
                return result;
            }).WithMessage("دسته مورد نظر موجود نمی باشد!");
        }
        public   async Task<VoidResult> CreateProductValidate(CreateProductDto categoryCreateDto)
        {
            var IsValid = await new CreateProductValidation(_categoryRepository).ValidateAsync(categoryCreateDto);
            if (!IsValid.IsValid)
            {
                return VoidResult.VoidFailedResult(IsValid.Errors.Select(s => s.ErrorMessage).ToList());
            }
            else
                return VoidResult.VoidSuccessResult();

        }
    }
}
