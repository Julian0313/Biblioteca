using Dominio.Modelo;
using Microsoft.EntityFrameworkCore;
using Repositorio.Interfaces;

namespace Repositorio.Implementacion
{
    public class GetEntidadRepo<T> : IGetEntidad<T> where T : class
    {
        private readonly LibreriaContext _context;

        public GetEntidadRepo(LibreriaContext context)
        {
            _context = context;
        }
        public async Task<IReadOnlyList<T>> IGetEntidadAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }
    }
}
