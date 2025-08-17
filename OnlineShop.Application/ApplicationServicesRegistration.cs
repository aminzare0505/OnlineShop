using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using OnlineShop.Application.Behaviors;
using OnlineShop.Application.Dto.Category;
using OnlineShop.Application.Dto.Category.Validator;
using OnlineShop.Application.Feature.CategoryType.Handler.Command;
using OnlineShop.Application.Feature.CategoryType.Request.Command;
using OnlineShop.Application.Feature.CategoryType.Request.Query;
using OnlineShop.Common.ResultPattern;
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
            Service.AddMediatR(mr => mr.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly() ));
            Service.AddSingleton(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
            Service.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
           // Service.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly() );
          //  Service.AddScoped(IValidator<CreateCategoryCommand, CreateCategoryCommandValidation>);
            // Service.AddScoped<IValidator<CreateCategoryCommand>, CreateCategoryCommandValidation>();
            Service.AddAutoMapper(Assembly.GetExecutingAssembly());
            return Service;
        }
    }
}
