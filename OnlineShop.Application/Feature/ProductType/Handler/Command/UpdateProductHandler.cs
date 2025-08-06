using AutoMapper;
using MediatR;
using OnlineShop.Application.Dto.Product;
using OnlineShop.Application.Dto.Product.Validator;
using OnlineShop.Application.Feature.ProductType.Request.Command;
using OnlineShop.Common.ResultPattern;
using OnlineShop.Domain.Entities;
using OnlineShop.Domain.IRepositories;
using OnlineShop.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Feature.ProductType.Handler.Command
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductRequest, VoidResult>
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public UpdateProductHandler(IProductRepository productRepository, ICategoryRepository categoryRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public async Task<VoidResult> Handle(UpdateProductRequest request, CancellationToken cancellationToken)
        {
            var IsValid = await new UpdateProductValidation(_categoryRepository).UpdateProductValidate(request.UpdateProductDto);
            if (!IsValid.IsSuccess)
                return IsValid;
            var ProductEntity =await _productRepository.Get(request.UpdateProductDto.Id);
            if (ProductEntity == null)
                return VoidResult.VoidFailedResult("Product is not found for this Id");
            var ProductForUpdate = _mapper.Map(request.UpdateProductDto,ProductEntity);
           await _productRepository.Update(ProductForUpdate);
            return VoidResult.VoidSuccessResult();
        }
    }
}
