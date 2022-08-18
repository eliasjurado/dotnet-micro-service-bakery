using MediatR;
using MicroRabbit.Banking.Data.Context;
using MicroRabbit.Banking.Domain.Models;
using MicroRabbit.Infra.IoC;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
DependencyContainer.RegisterServices(builder.Services);
var connectionString = builder.Configuration.GetConnectionString("BakeryDBConnection");
builder.Services.AddDbContext<BakeryDbContext>(options => options.UseSqlServer(connectionString));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "BakeryInventory Microservice", Version = "v1" });
});

builder.Services.AddMediatR(typeof(StartupBase));

builder.Services.Configure<ProductSetting>(builder.Configuration.GetSection("ProductSetting"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(action =>
    {
        action.SwaggerEndpoint("/swagger/v1/swagger.json", "BakeryInventory Microservice V1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
