using MediatR;
using OnlineShop.Application.Dto.Product;
using OnlineShop.Common.ResultPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Feature.ProductType.Request.Command
{
    public class CreateProductRequest:IRequest<VoidResult>
    {
        public CreateProductDto  CreateProductDto{ get; set; }
    }
}
