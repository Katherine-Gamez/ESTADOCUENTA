using EstadoCuenta.INFRASTRUCTURE.Configurations;
using EstadoCuenta.INFRASTRUCTURE.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using EstadoCuenta.CORE.InterfacesRepositories;
using System.Data;
using Microsoft.Extensions.Configuration;
using EstadoCuenta.CORE.Interfaces;
using EstadoCuenta.CORE.Services;

namespace EstadoCuenta.INFRASTRUCTURE.Middleware
{
    public static class IoC
	{
        public static IServiceCollection Dependency(this IServiceCollection services)
        {
            services.AddScoped<IUsuariosServices, UsuariosService>();
            services.AddScoped<IUsuariosRepository, UsuariosRepository>();
            services.AddScoped<IEstadoCuentaService, EstadoCuentaService>();
            services.AddScoped<IEstadoCuentaRepository, EstadoCuentaRepository>();
            services.AddScoped<IMovimientosServices, MovimientosServices>();
            services.AddScoped<IMovimientosRepository, MovimientosRepository>();
            services.AddScoped<ITransaccionesServices, TransaccionesServices>();
            services.AddScoped<ITransaccionesRepository, TransaccionesRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<DapperContext>();

            services.AddSingleton("Server=5.161.223.235;Database=EstadoCuentaDB;User Id=UserService;Password=Caronte$23;");

            return services;
        }
    }
}

