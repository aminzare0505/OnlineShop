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
        public static IServiceCollection ApplicationCpnfiguration(this IServiceCollection Service)
        {
            Service.AddMediatR(Assembly.GetExecutingAssembly());
            return Service;
        }
    }
}
