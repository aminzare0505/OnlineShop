using OnlineShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Domain.IRepositories
{
    public interface IUserRepository:IGenericRepository<User>
    {
        Task<bool> CheckWithUserName(string username);
        Task<User> GetUserById(Guid id);
    }
}
