using FluentValidation;
using OnlineShop.Application.Dto.Product;
using OnlineShop.Application.Dto.Product.Validator;
using OnlineShop.Common.ResultPattern;
using OnlineShop.Domain.IRepositories;
using OnlineShop.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Dto.Product.Validator
{
    public class UpdateProductValidation : AbstractValidator<UpdateProductDto>
    {
        private readonly ICategoryRepository _categoryRepository;
        public UpdateProductValidation(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;

            RuleFor(x => x.Name).NotEmpty().WithName("فیلد نام را پرکنید!")
                .MaximumLength(150).WithMessage("طول عبارت بیشتر از حد مجاز است");
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("طول عبارت بییشتر از صفر نیست!");

            RuleFor(x => x.CategoryId).MustAsync(async (cref, t) =>
            {
                return await _categoryRepository.CheckExistCatgery(cref);
            }).WithMessage("دسته بندی مورد نظر وجود ندارد!");
        }

        public async Task<VoidResult> UpdateProductValidate(UpdateProductDto categoryUpdateDto)
        {
            var IsValid = await new UpdateProductValidation(_categoryRepository).ValidateAsync(categoryUpdateDto);
            if (!IsValid.IsValid)
            {
                return VoidResult.VoidFailedResult(IsValid.Errors.Select(s => s.ErrorMessage).ToList());
            }
            else
                return VoidResult.VoidSuccessResult();

        }
    }
}
