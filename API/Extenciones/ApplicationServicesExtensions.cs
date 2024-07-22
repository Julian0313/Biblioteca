using Dominio.Modelo;
using Dominio.Utilidades;
using Logica.Implementacion;
using Logica.Interfaces;
using Microsoft.EntityFrameworkCore;
using Repositorio.Implementacion;
using Repositorio.Interfaces;
using Repositorio.Utilidades;
using UnidadDeTrabajo.Interfaces;

namespace API.Extenciones
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services,
            IConfiguration config)
        {
            services.AddDbContext<LibreriaContext>(opt =>
            {
                opt.UseNpgsql(config.GetConnectionString("Default"));
            });
            
            services.AddScoped<IValidarDatosEntidad<Autor>, AutorRepo>();
            services.AddScoped<IValidarDatosEntidad<Libro>, LibroRepo>();   
            
            services.AddScoped<IGetEntidadById<Libro>, LibroRepo>();
            services.AddScoped<IGetEntidadById<Autor>, AutorRepo>();

            services.AddScoped<IGetEntidadPag<LibroRtn>, LibroRepo>();
            services.AddScoped<IGetEntidadPag<Autor>, AutorRepo>();

            services.AddScoped<IGetEntidad<Estado>, GetEntidadRepo<Estado>>();

            services.AddScoped<IEstadoLog, EstadoLog>();
            services.AddScoped<IAutorLog, AutorLog>();
            services.AddScoped<ILibroLog, LibroLog>();

            services.AddScoped<IInsEntidad<Autor>, AutorRepo>();
            services.AddScoped<IInsEntidad<Libro>, LibroRepo>();

            services.AddScoped<ISetEntidad<Libro>, LibroRepo>();
            services.AddScoped<ISetEntidad<Autor>, AutorRepo>();

            services.AddScoped<IDelEntidad, LibroRepo>();
            services.AddScoped<IDelEntidad, AutorRepo>();

            services.AddScoped<IUnidadDeTrabajo, UnidadDeTrabajo.Implementacion.UnidadDeTrabajo>();

            services.AddAutoMapper(typeof(PerfildeMapeo));           

            return services;
        }
    }
}
