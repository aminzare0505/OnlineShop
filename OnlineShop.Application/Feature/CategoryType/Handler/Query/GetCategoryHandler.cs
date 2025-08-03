using MediatR;
using OnlineShop.Application.Dto.Category;
using OnlineShop.Application.Feature.CategoryType.Request.Query;
using OnlineShop.Common.ResultPattern;
using OnlineShop.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Feature.CategoryType.Handler.Query
{
    public class GetCategoryHandler : IRequestHandler<GetCategoryRequest, Result<CategoryDto>>
    {
        private readonly ICategoryRepository _categoryRepository;
        public GetCategoryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<Result<CategoryDto>> Handle(GetCategoryRequest request, CancellationToken cancellationToken)
        {
            var Category = await _categoryRepository.Get(request.Id);
            return Result<CategoryDto>.SuccessResult(Data: new CategoryDto() { Id = Category.Id, Des = Category.Des, Name = Category.Name });
        }
    }
}
