using OnlineShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Domain.IRepositories
{
    public interface ICategoryRepository:IGenericRepository<Category>
    {
        Task<bool> CheckExistCatgery(int id);
        Task EventOccured(Category category, string evt);
        Task<Category> AddWithReturn(Category category);
    }
}
