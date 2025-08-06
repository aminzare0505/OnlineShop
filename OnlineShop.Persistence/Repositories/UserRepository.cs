using Microsoft.EntityFrameworkCore;
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
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly ShopDbContext _dbContext;
        public UserRepository(ShopDbContext dbContext) : base(dbContext)
        {
            _dbContext=dbContext;
        }
        
        public async Task<bool> CheckWithUserName(string username)
        {
            return await _dbContext.User.AnyAsync(x => x.UserName == username);
        }
        public async Task<User> GetUserById(Guid id)
        {
            return await _dbContext.User.FindAsync(id);
        }
    }
}
