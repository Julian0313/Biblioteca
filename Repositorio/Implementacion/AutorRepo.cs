using Dominio.Utilidades;
using Dominio.Modelo;
using Microsoft.EntityFrameworkCore;
using Repositorio.Interfaces;

namespace Repositorio.Implementacion
{
    public class AutorRepo : IGetEntidadPag<Autor>, IInsEntidad<Autor>,
        IValidarDatosEntidad<Autor>, ISetEntidad<Autor>, IGetEntidadById<Autor>,
        IDelEntidad
    {
        private readonly LibreriaContext _context;

        public AutorRepo(LibreriaContext context)
        {
            _context = context;
        }
        public async Task<Autor> ValidarEntidadAsync(Autor autor)
        {
            var AutorExistente = await _context.Set<Autor>()
             .FirstOrDefaultAsync(a =>
                 a.Nombre == autor.Nombre &&
                 a.AnoNac == autor.AnoNac &&
                 a.AnoFal == autor.AnoFal);

            return AutorExistente;
        }

        public async Task<Paginacion<Autor>> IGetEntidadPagAsync(ParametrosPag parametros)
        {
            var autor = _context.Autores.AsQueryable();

            var contador = await autor.CountAsync();

            var autorPag = await autor
              .Skip((parametros.PageIndex - 1) * parametros.PageSize)
              .Take(parametros.PageSize)
              .ToListAsync();

            var paginacion = new Paginacion<Autor>(
               parametros.PageIndex,
               parametros.PageSize,
               contador,
               autorPag
           );

            return paginacion;
        }
        public async Task InsEntidadAsync(Autor autor)
        {
            try
            {
                _context.Autores.Add(autor);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task SetEntidadAsync(Autor autor)
        {
            var setAutor = await _context.Autores.FindAsync(autor.IdAutor);
            setAutor.Nombre = autor.Nombre;
            setAutor.AnoNac = autor.AnoNac;
            setAutor.AnoFal = autor.AnoFal;
            await _context.SaveChangesAsync();

        }

        public async Task<Autor> GetEntidadByIdAsync(int id)
        {
            var AutorExistente = await _context.Autores
           .FirstOrDefaultAsync(a => a.IdAutor == id);

            return AutorExistente;
        }

        public async Task<bool> DelEntidadAsync(int id)
        {
            var Autor = await _context.Autores.FindAsync(id);
            if (Autor != null)
            {
                _context.Autores.Remove(Autor);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
