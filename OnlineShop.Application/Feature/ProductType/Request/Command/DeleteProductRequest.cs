using MediatR;
using OnlineShop.Common.ResultPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Feature.ProductType.Request.Command
{
    public class DeleteProductRequest:IRequest<VoidResult>
    {
        public int Id  { get; set; }
    }
}
