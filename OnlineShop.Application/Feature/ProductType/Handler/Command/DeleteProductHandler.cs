using MediatR;
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
    public class DeleteProductHandler : IRequestHandler<DeleteProductRequest, VoidResult>
    {
        private readonly IProductRepository _productRepository;

        public DeleteProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<VoidResult> Handle(DeleteProductRequest request, CancellationToken cancellationToken)
        {
            var product = _productRepository.Get(request.Id);
            if (product == null)
            {
                return VoidResult.VoidFailedResult("This Id is not correct");
            }
            await _productRepository.Delete(request.Id);
            return VoidResult.VoidSuccessResult();
        }
    }
}
