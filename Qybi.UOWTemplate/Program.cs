using Microsoft.EntityFrameworkCore;
using Qybi.UOWTemplate.DataAccess.Contexts;
using Qybi.UOWTemplate.DataAccess.Abstractions;
using Qybi.UOWTemplate.DataAccess;
using Qybi.UOWTemplate.DataAccess.Abstractions.Contexts;
using Qybi.UOWTemplate.Endpoints;

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
