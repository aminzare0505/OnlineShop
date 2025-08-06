using AutoMapper;
using OnlineShop.Application.Dto.Product;
using OnlineShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Profiler
{
    public class AutomapperProfiler:Profile
    {
        public AutomapperProfiler()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Product, CreateProductDto>();
            CreateMap<Product, UpdateProductDto>();
        }
    }
}
