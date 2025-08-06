using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application
{
    public static class ApplicationServicesRegistration
    {
        public static IServiceCollection ApplicationConfiguration(this IServiceCollection Service)
        {
            Service.AddMediatR(Assembly.GetExecutingAssembly());
            Service.AddAutoMapper(Assembly.GetExecutingAssembly());
            return Service;
        }
    }
}
