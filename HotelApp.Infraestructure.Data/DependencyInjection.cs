using HotelApp.Application.Contracts;
using HotelApp.Application.Services;
using HotelApp.Domain.Contracts;
using HotelApp.Infraestructure.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace HotelApp.Infraestructure.Persistence
{
    public class DependencyInjection
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IHotelService, HotelService>();
            services.AddScoped<IHotelRepository, HotelRepository>();

            services.AddScoped<IRoomService, RoomService>();
            services.AddScoped<IRoomRepository, RoomRepository>();
        }
    }
}
