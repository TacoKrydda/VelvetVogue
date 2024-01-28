using Microsoft.EntityFrameworkCore;
using WebbShopClassLibrary.Context;
using WebbShopClassLibrary.Interfaces.Production;
using WebbShopClassLibrary.Interfaces.Sales;
using WebbShopClassLibrary.Models.Production;
using WebbShopClassLibrary.Models.Sales;
using WebbShopClassLibrary.Services;
using WebbShopClassLibrary.Services.Production;
using WebbShopClassLibrary.Services.Sales;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<WebbShopContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
}, ServiceLifetime.Scoped);

//-------------Production-------------//
builder.Services.AddScoped<IGenericService<Brand>, BrandService>();
builder.Services.AddScoped<IGenericService<Category>, CategoryService>();
builder.Services.AddScoped<IGenericService<Color>, ColorService>();
builder.Services.AddScoped<IGenericService<Product>, ProductService>();
builder.Services.AddScoped<IGenericService<Size>, SizeService>();
builder.Services.AddScoped<IGenericService<Stock>, StockService>();
builder.Services.AddScoped<GenericService<Brand>>();
builder.Services.AddScoped<GenericService<Category>>();
builder.Services.AddScoped<GenericService<Color>>();
builder.Services.AddScoped<GenericService<Product>>();
builder.Services.AddScoped<GenericService<Size>>();
builder.Services.AddScoped<GenericService<Stock>>();

//----------------Sales---------------//
builder.Services.AddScoped<IGenericService<CartItem>, CartItemService>();
builder.Services.AddScoped<IGenericService<Customer>, CustomerService>();
builder.Services.AddScoped<IGenericService<Order>, OrderService>();
builder.Services.AddScoped<IGenericService<Staff>, StaffService>();
builder.Services.AddScoped<GenericService<CartItem>>();
builder.Services.AddScoped<GenericService<Customer>>();
builder.Services.AddScoped<GenericService<Order>>();
builder.Services.AddScoped<GenericService<Staff>>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
