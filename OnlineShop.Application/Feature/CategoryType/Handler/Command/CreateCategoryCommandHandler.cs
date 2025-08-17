using OnlineShop.Application.Abstractions;
using OnlineShop.Application.Dto.Category.Validator;
using OnlineShop.Application.Feature.CategoryType.Request.Command;
using OnlineShop.Common.ResultPattern;
using OnlineShop.Domain.Entities;
using OnlineShop.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Feature.CategoryType.Handler.Command
{
    internal sealed class CreateCategoryCommandHandler : ICommandHandler<CreateCategoryCommand, VoidResult>
    {
        private readonly ICategoryRepository _categoryRepository;
        public CreateCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<VoidResult> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                //var IsValid = await CreateCategoryValidation.CreateCategoryValidate(request.CategoryCreateCommand);
                //if (!IsValid.IsSuccess)
                //    return IsValid;
                Category category = new Category()
                {
                    Name = request.CreateCategoryDto.Name,
                    Des = request.CreateCategoryDto.Des
                };
                await _categoryRepository.Add(category);
                return VoidResult.VoidSuccessResult();
            }
            catch (Exception ex)
            {
                return VoidResult.VoidFailedResult(ex);
            }
        }
    }
}
