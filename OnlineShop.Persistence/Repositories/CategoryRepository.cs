using OnlineShop.Domain.Entities;
using OnlineShop.Domain.Repositories;
using OnlineShop.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Persistence.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ShopDbContext dbContext) : base(dbContext)
        {
        }
    }
}
