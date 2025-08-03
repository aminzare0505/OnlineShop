using MediatR;
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
    public class DeleteCategoryHandler : IRequestHandler<DeleteCategoryRequest, VoidResult>
    {
        private readonly ICategoryRepository _categoryRepository;
        public DeleteCategoryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<VoidResult> Handle(DeleteCategoryRequest request, CancellationToken cancellationToken)
        {
         await   _categoryRepository.Delete(request.CategoryDtoRequest.Id);
            return VoidResult.VoidSuccessResult();
        }
    }
}
