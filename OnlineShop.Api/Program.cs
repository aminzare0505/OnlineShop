using FluentValidation;
using MediatR;
using OnlineShop.Api.Middleware;
using OnlineShop.Application;
using OnlineShop.Application.Behaviors;
using OnlineShop.Application.Feature.CategoryType.Handler.Command;
using OnlineShop.Application.Feature.CategoryType.Request.Command;
using OnlineShop.Persistence;

var builder = WebApplication.CreateBuilder(args);
 
builder.Services.AddControllers(); 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.ApplicationConfiguration();
builder.Services.PersistenceConfiguration(builder.Configuration);
builder.Services.AddScoped<IValidator<CreateCategoryCommand>, OnlineShop.Application.Feature.CategoryType.Handler.Command.CreateCategoryCommandValidation>();
//builder.Services.AddMediatR(mr=>mr.RegisterServicesFromAssembly( typeof(Program).Assembly));
//builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
builder.Services.AddTransient<ExceptionHandlingMiddleware>();
var app = builder.Build();
 
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.Run();
