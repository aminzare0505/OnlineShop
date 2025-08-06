using AutoMapper;
using MediatR;
using OnlineShop.Application.Dto.Product;
using OnlineShop.Application.Feature.ProductType.Request.Query;
using OnlineShop.Common.ResultPattern;
using OnlineShop.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Feature.ProductType.Handler.Query
{
    public class GetAllProductHandler : IRequestHandler<GetAllProductRequest, Result<List<ProductDto>>>
    {private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public GetAllProductHandler(IProductRepository productRepository,IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper=mapper;
        }

        
        public async Task<Result<List<ProductDto>>> Handle(GetAllProductRequest request, CancellationToken cancellationToken)
        {
            var products = _mapper.Map<List<ProductDto>>((await _productRepository.GetAll()));
            return Result<List<ProductDto>>.SuccessResult(Data: products);
        }
    }
}
