using AutoMapper;
using MediatR;
using OnlineShop.Application.Dto.Product;
using OnlineShop.Application.Feature.ProductType.Request.Query;
using OnlineShop.Common.ResultPattern;
using OnlineShop.Domain.IRepositories;
using OnlineShop.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Feature.ProductType.Handler.Query
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdRequest, Result<ProductDto>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetProductByIdHandler(IProductRepository productRepository,IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<Result<ProductDto>> Handle(GetProductByIdRequest request, CancellationToken cancellationToken)
        {
            var porduct = await _productRepository.Get(request.Id);
            var productDto = _mapper.Map<ProductDto>(porduct);
            return Result<ProductDto>.SuccessResult(Data: productDto);
        }
    }
}
