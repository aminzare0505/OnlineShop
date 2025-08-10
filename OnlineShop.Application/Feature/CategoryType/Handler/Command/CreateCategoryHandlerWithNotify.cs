using MediatR;
using OnlineShop.Application.Dto.Category;
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
    public class CreateCategoryHandlerWithNotify : IRequestHandler<CreateCategoryRequestWithNotify, Result<Category>>
    {
        private readonly ICategoryRepository _categoryRepository;
        public CreateCategoryHandlerWithNotify(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<Result<Category>> Handle(CreateCategoryRequestWithNotify request, CancellationToken cancellationToken)
        {
            try
            {
                var IsValid = await CreateCategoryValidation.CreateCategoryValidate(request.CategoryCreateRequest);
                if (!IsValid.IsSuccess)
                    return Result<Category>.FailedResult("Fail",IsValid.Message);
                Category category = new Category()
                {
                    Name = request.CategoryCreateRequest.Name,
                    Des = request.CategoryCreateRequest.Des
                };
              var categoryEntity=  await _categoryRepository.AddWithReturn(category);
                return  Result<Category>.SuccessResult(Data: categoryEntity);
            }
            catch (Exception ex)
            {
                return Result<Category>.FailedResult("Fail", ex.Message);
            }

        }
    }
}
