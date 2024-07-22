using Dominio.Utilidades;

namespace Repositorio.Interfaces
{
    public interface IGetEntidadPag<T> where T : class
    {
        Task<Paginacion<T>> IGetEntidadPagAsync(ParametrosPag parametros);
    }
}
