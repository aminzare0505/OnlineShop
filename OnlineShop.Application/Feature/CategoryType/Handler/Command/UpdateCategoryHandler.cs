using MediatR;
using OnlineShop.Application.Dto.Category.Validator;
using OnlineShop.Application.Feature.CategoryType.Request.Command;
using OnlineShop.Common.ResultPattern;
using OnlineShop.Domain.Repositories;
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
            var IsValid = await UpdateCategoryValidation.UpdateCategoryValidate(request.CategoryUpdateRequest);
            if (!IsValid.IsSuccess)
                return IsValid;
            var Category = await _categoryRepository.Get(request.CategoryUpdateRequest.Id);
            if (Category != null)
            {
                if (!string.IsNullOrWhiteSpace(request.CategoryUpdateRequest.Name))
                {
                    Category.Name = request.CategoryUpdateRequest.Name;
                }
                if (!string.IsNullOrWhiteSpace(request.CategoryUpdateRequest.Des))
                {
                    Category.Des = request.CategoryUpdateRequest.Des;
                }
                await _categoryRepository.Update(Category);
                return VoidResult.VoidSuccessResult();
            }
            else
                return VoidResult.VoidFailedResult("This Category ID is not find");
        }
    }
}
