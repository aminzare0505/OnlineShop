using MediatR;
using OnlineShop.Application.Dto.Category;
using OnlineShop.Application.Feature.CategoryType.Request.Command;
using OnlineShop.Application.Feature.CategoryType.Request.Query;
using OnlineShop.Common.ResultPattern;
using OnlineShop.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Feature.CategoryType.Handler.Query
{
    public class GetAllCategoryHandler : IRequestHandler<GetAllCategoryRequest, Result<IQueryable<CategoryDto>>>
    {
        private readonly ICategoryRepository _categoryRepository;
        public GetAllCategoryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Result<IQueryable<CategoryDto>>> Handle(GetAllCategoryRequest request, CancellationToken cancellationToken)
        {
            var Categories = await _categoryRepository.GetAll();
            var CategoriesDto = Categories.Select(s => new CategoryDto() { Id = s.Id, Name = s.Name, Des = s.Des }) ;
            return   Result<IQueryable<CategoryDto>>.SuccessResult(Data: CategoriesDto);


        }
    }
}
