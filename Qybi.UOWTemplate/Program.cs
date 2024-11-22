using Microsoft.EntityFrameworkCore;
using Qybi.UOWTemplate.DataAccess.Contexts;
using Qybi.UOWTemplate.DataAccess.Abstractions;
using Qybi.UOWTemplate.DataAccess;
using Qybi.UOWTemplate.DataAccess.Abstractions.Contexts;
using Qybi.UOWTemplate.Endpoints;
using Qybi.UOWTemplate.DataAccess.Abstractions.Repositories;
using Qybi.UOWTemplate.DataAccess.Repositories;
using Microsoft.AspNetCore.Http.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("db"));
});

builder.Services.AddScoped<IApplicationDbContext, ApplicationDbContext>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IProductsRepository, ProductsRepository>();
builder.Services.AddScoped<ICategoriesRepository, CategoriesRepository>();


builder.Services.Configure<JsonOptions>(options =>
    options.SerializerOptions.ReferenceHandler =
        System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapProductEndPoints();
app.MapCategoryEndPoints();

app.Run();
