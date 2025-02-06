using HotelApp.Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;
using HotelApp.Infraestructure.Persistence.Context;
using HotelApp.Application.EventHandlers;
using HotelApp.Domain.Contracts;
using HotelApp.Infraestructure.Persistence.Email;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(SendReservationEmailHandler).Assembly));
builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));

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
