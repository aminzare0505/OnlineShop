using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Common;
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
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        private readonly ShopDbContext _dbContext;
        public CategoryRepository(ShopDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> CheckExistCatgery(int id)
        {
            return await _dbContext.Categories.AnyAsync(a => a.Id == id);
        }
        public async Task EventOccured(Category category, string evt)
        {
            _dbContext.Categories.Single(c => c.Id == category.Id).Name = $"{category.Name} evt: {evt}";
            await Task.CompletedTask;

        }
        public async Task<Category> AddWithReturn(Category category)
        {
            var categoryEntity = await _dbContext.AddAsync(category);
            await _dbContext.SaveChangesAsync();
            return categoryEntity.Entity;

        }

    }
}
