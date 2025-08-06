using MediatR;
using OnlineShop.Application.Dto.Product;
using OnlineShop.Common.ResultPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Feature.ProductType.Request.Query
{
    public class GetAllProductRequest:IRequest<Result<List<ProductDto>>>
    {

    }
}
