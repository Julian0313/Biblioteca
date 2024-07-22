using AutoMapper;
using Dominio.Modelo;
using Dominio.Utilidades;
using Microsoft.EntityFrameworkCore;
using Repositorio.Interfaces;

namespace Repositorio.Implementacion
{
    public class LibroRepo : IGetEntidadPag<LibroRtn>, IInsEntidad<Libro>,
        IValidarDatosEntidad<Libro>,ISetEntidad<Libro>, IGetEntidadById<Libro>,
        IDelEntidad
    {
        private readonly LibreriaContext _context;
        private readonly IMapper _mapper;

        public LibroRepo(LibreriaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Paginacion<LibroRtn>> IGetEntidadPagAsync(ParametrosPag parametros)
        {
            var libro = _context.Libros
              .Include(a => a.Autor)
              .Include(e => e.Estado)
              .AsQueryable();

            if (parametros.Estado != "")
            {
                libro = libro.Where(p => p.FkIdEstado == int.Parse(parametros.Estado));
            }

            var contador = await libro.CountAsync();

            var libroPag = await libro
              .Skip((parametros.PageIndex - 1) * parametros.PageSize)
              .Take(parametros.PageSize)
              .ToListAsync();

            var libroMap = _mapper.Map<IReadOnlyList<LibroRtn>>(libroPag);

            var paginacion = new Paginacion<LibroRtn>(
               parametros.PageIndex,
               parametros.PageSize,
               contador,
               libroMap
           );

            return paginacion;
        }

        public async Task InsEntidadAsync(Libro libro)
        {
            _context.Libros.Add(libro);
            await _context.SaveChangesAsync();
        }

        public async Task SetEntidadAsync(Libro libro)
        {
            var setLibro =  await _context.Libros.FindAsync(libro.IdLibro);
            setLibro.FkIdAutor = libro.FkIdAutor;
            setLibro.FkIdEstado = libro.FkIdEstado;
            setLibro.Titulo = libro.Titulo;
            setLibro.AnoPublicacion = libro.AnoPublicacion;

            await _context.SaveChangesAsync();
        }

        public async Task<Libro> ValidarEntidadAsync(Libro libro)
        {
            var libroExistente = await _context.Set<Libro>()
               .FirstOrDefaultAsync(a =>
                   a.Titulo == libro.Titulo.Trim() &&
                   a.FkIdAutor == libro.FkIdAutor);

            return libroExistente;
        }

        public async Task<Libro> GetEntidadByIdAsync(int id)
        {
            var LibroExistente = await _context.Libros
                .Include(a => a.Autor)
                .Include(e => e.Estado)
                .FirstOrDefaultAsync(a => a.IdLibro == id);

            return LibroExistente;
        }

        public async Task<bool> DelEntidadAsync(int id)
        {
            var libro = await _context.Libros.FindAsync(id);
            if (libro != null)            {
                _context.Libros.Remove(libro);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
