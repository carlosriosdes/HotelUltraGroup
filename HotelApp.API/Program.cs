using HotelApp.Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;
using HotelApp.Infraestructure.Persistence.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<HotelUltraGroupContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConecctionHotelUltraGroupDB"));
});

DependencyInjection.RegisterServices(builder.Services);

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
