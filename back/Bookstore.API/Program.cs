using Microsoft.EntityFrameworkCore;
using Bookstore.Application.Services;
using Bookstore.Domain.Interfaces.Repositories;
using Bookstore.Domain.Interfaces.Services;
using Bookstore.Infra;
using Bookstore.Infra.Repositories;
using Bookstore.Domain.Entities;
using FluentValidation;
using Bookstore.Domain.Validators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Package Services
builder.Services.AddDbContext<DataContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("Default")));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// App Services
builder.Services.AddTransient<IBookService, BookService>();
builder.Services.AddTransient<ICategoryService, CategoryService>();

// Repositories
builder.Services.AddTransient<IBookRepository, BookRepository>();
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();

// Validators
builder.Services.AddScoped<IValidator<Book>, BookValidator>();
builder.Services.AddScoped<IValidator<Category>, CategoryValidator>();

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
