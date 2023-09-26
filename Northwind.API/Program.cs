using Microsoft.EntityFrameworkCore;
using Northwind.API.Models.Context;
using Northwind.API.Repositories;
using Northwind.API.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<NorthwindContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//Services
builder.Services.AddScoped<IEmployeeRepository, EmployeeService>();
builder.Services.AddScoped<IProductRepository, ProductService>();

//Disturbed Session Configure
builder.Services.AddDistributedMemoryCache();

//Session
builder.Services.AddSession( options =>
{
    options.Cookie.Name = "product_card";
    options.IdleTimeout=TimeSpan.FromMinutes(5);
});


//CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("CORS", cors =>
    {
        cors.AllowAnyHeader().AllowAnyMethod().AllowCredentials().WithOrigins("https://localhost:7236");
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseCors("CORS");

app.MapControllers();

app.UseSession();

app.Run();

