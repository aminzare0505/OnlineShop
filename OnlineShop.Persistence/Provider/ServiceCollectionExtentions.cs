using Microsoft.Extensions.DependencyInjection;
using OnlineShop.Domain.Common;
using OnlineShop.Domain.IRepositories;
using OnlineShop.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Persistence.Provider
{
    public static class ServiceCollectionExtentions
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var repoType = assembly.GetTypes().Where(w =>  typeof(IRepository).IsAssignableFrom(w)  && w.IsClass && !w.IsAbstract);
            foreach (var repo in repoType)
            {
                var interfaceType = repo.GetInterfaces().FirstOrDefault(f=>f!=typeof(IRepository) && !f.IsGenericType  );
                if (interfaceType != null)
                {
                    services.AddScoped(interfaceType, repo);
                }
            }
        }
    }
}
