using MediatR;
using OnlineShop.Application.Dto.Category.Validator;
using OnlineShop.Application.Feature.CategoryType.Request.Command;
using OnlineShop.Common.ResultPattern;
using OnlineShop.Domain.IRepositories;
using OnlineShop.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Feature.CategoryType.Handler.Command
{
    public class UpdateCategoryHandler : IRequestHandler<UpdateCategoryRequest, VoidResult>
    {
        private readonly ICategoryRepository _categoryRepository;
        public UpdateCategoryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<VoidResult> Handle(UpdateCategoryRequest request, CancellationToken cancellationToken)
        {
            var IsValid = await UpdateCategoryValidation.UpdateCategoryValidate(request.UpdateCategoryDto);
            if (!IsValid.IsSuccess)
                return IsValid;
            var Category = await _categoryRepository.Get(request.UpdateCategoryDto.Id);
            if (Category != null)
            {
                if (!string.IsNullOrWhiteSpace(request.UpdateCategoryDto.Name))
                {
                    Category.Name = request.UpdateCategoryDto.Name;
                }
                if (!string.IsNullOrWhiteSpace(request.UpdateCategoryDto.Des))
                {
                    Category.Des = request.UpdateCategoryDto.Des;
                }
                await _categoryRepository.Update(Category);
                return VoidResult.VoidSuccessResult();
            }
            else
                return VoidResult.VoidFailedResult("This Category ID is not find");
        }
    }
}
