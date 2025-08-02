using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Repositories;
using OnlineShop.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Persistence.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly ShopDbContext _dbContext;
        public GenericRepository(ShopDbContext dbContext)
        {
            _dbContext = dbContext;

        }
        public async Task Add(TEntity entity)
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

        }

        public async Task Delete(int Id)
        {
            var result = await Get(Id);
            await Delete(result);
        }

        public async Task Delete(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<TEntity> Get(int id)
        {
            return await _dbContext.Set<TEntity>().FindAsync(id);
        }

        public async Task<IQueryable<TEntity>> GetAll()
        {
            return _dbContext.Set<TEntity>().AsQueryable().AsNoTracking();
        }

        public async Task Update(TEntity entity)
        {
            _dbContext.Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
