using OnlineShop.Application;
using OnlineShop.Persistence;

var builder = WebApplication.CreateBuilder(args);
 
builder.Services.AddControllers(); 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.ApplicationConfiguration();
builder.Services.PersistenceConfiguration(builder.Configuration);


var app = builder.Build();
 
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
