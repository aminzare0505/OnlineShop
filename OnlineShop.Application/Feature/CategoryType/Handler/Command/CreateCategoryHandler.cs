using FluentValidation;
using MediatR;
using OnlineShop.Application.Dto.Category.Validator;
using OnlineShop.Application.Feature.CategoryType.Request.Command;
using OnlineShop.Common.ResultPattern;
using OnlineShop.Domain.Entities;
using OnlineShop.Domain.Repositories;
using OnlineShop.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Feature.CategoryType.Handler.Command
{
    public class CreateCategoryHandler : IRequestHandler<CreateCategoryRequest, VoidResult>
    {
        private readonly ICategoryRepository _categoryRepository;
        public CreateCategoryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository=categoryRepository;
        }
        public async Task<VoidResult> Handle(CreateCategoryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var IsValid = await CreateCategoryValidation.CreateCategoryValidate(request.CategoryCreateRequest);
                if (!IsValid.IsSuccess)
                    return IsValid;
                Category category = new Category()
                {
                    Name = request.CategoryCreateRequest.Name,
                    Des = request.CategoryCreateRequest.Des
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
