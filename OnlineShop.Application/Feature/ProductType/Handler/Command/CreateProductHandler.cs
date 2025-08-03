using MediatR;
using OnlineShop.Application.Dto.Category.Validator;
using OnlineShop.Application.Dto.Product.Validator;
using OnlineShop.Application.Feature.ProductType.Request.Command;
using OnlineShop.Common.ResultPattern;
using OnlineShop.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Feature.ProductType.Handler.Command
{
    public class CreateProductHandler : IRequestHandler<CreateProductRequest, VoidResult>
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        public CreateProductHandler(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }
        public async Task<VoidResult> Handle(CreateProductRequest request, CancellationToken cancellationToken)
        {
            var IsValid =await new CreateProductValidation(_categoryRepository).CreateProductValidate(request.CreateProductDto); 
            if (!IsValid.IsSuccess)
                return IsValid;
            var CreateProductDto = request.CreateProductDto;
            await _productRepository.Add(new Domain.Entities.Product() {Id= CreateProductDto.Id,Description= CreateProductDto.Description,Name= CreateProductDto.Name,Price= CreateProductDto.Price,CategoryId= CreateProductDto.CategoryId,CreateDateTime=DateTime.Now  });

            return VoidResult.VoidSuccessResult();
        }
    }
}
