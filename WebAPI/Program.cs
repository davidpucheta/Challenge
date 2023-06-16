using Microsoft.EntityFrameworkCore;
using Repository;
using WebAPI.Profiles;
using AutoMapper;
using Models.Data;
using Models.Interfaces;
using WebAPI.Services;

var builder = WebApplication.CreateBuilder(args);
IConfiguration config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false)
    .Build();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(config.GetConnectionString("postgres")));
builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddTransient<IRepository<Category>, CategoriesRepository>();
builder.Services.AddTransient<IRepository<Product>, ProductsRepository>();
builder.Services.AddTransient<ICSVProcessor, CsvProcessor>();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}


//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
