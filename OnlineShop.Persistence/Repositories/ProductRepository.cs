using OnlineShop.Domain.Entities;
using OnlineShop.Domain.IRepositories;
using OnlineShop.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Persistence.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(ShopDbContext dbContext) : base(dbContext)
        {
        }
    }
}
