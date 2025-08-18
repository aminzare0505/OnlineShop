using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using OnlineShop.Application.Abstractions;
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
        public static IServiceCollection ApplicationConfiguration(this IServiceCollection Service,IConfiguration configuration)
        {
            Service.AddMediatR(mr => mr.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly() ));
            Service.AddSingleton(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
            Service.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            Service.AddValidatorsFromAssemblyContaining<IValidation>(); // register validators
            Service.AddAutoMapper(Assembly.GetExecutingAssembly());

            Service.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(opt =>
            {
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateLifetime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Key"])),
                    ValidateIssuer = true,
                    ValidateAudience = true, 
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = "myApp",
                    ValidAudience = "myAppUsers" 
                };
            });

            return Service;

            //Service.AddScoped(typeof(IValidator<>), typeof(ICommand<>));
            // Service.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly() );
            //  Service.AddScoped(IValidator<CreateCategoryCommand, CreateCategoryCommandValidation>);
            // Service.AddScoped<IValidator<CreateCategoryCommand>, CreateCategoryCommandValidation>();
            //Service.AddValidatorsFromAssembly(typeof(AbstractValidator<>).Assembly);
        }
    }
}
