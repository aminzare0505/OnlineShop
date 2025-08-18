using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineShop.Domain.IRepositories;
using OnlineShop.Persistence.Context;
using OnlineShop.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Common;
using OnlineShop.Persistence.Provider;

namespace OnlineShop.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection PersistenceConfiguration(this IServiceCollection service, IConfiguration config)
        {
            //service.AddScoped<ICategoryRepository, CategoryRepository>();
            //service.AddScoped<IProductRepository, ProductRepository>();
            //service.AddScoped<IUserRepository,UserRepository>();
            service.AddRepositories();
            service.AddDbContext<ShopDbContext>(opt=>opt.UseSqlServer(config.GetConnectionString("OnlineShopConnectionString")));
            return service;
        }
    }
}
