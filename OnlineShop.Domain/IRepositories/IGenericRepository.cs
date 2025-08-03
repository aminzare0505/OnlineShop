using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Domain.IRepositories
{
    public interface IGenericRepository<TEntity> where TEntity:class
    {
        Task<TEntity> Get(int Id);
        Task  Update(TEntity entity);
        Task Delete(int Id);
        Task<IQueryable<TEntity>> GetAll();    
        Task Add(TEntity entity);
        Task Delete(TEntity entity);
    }
}
