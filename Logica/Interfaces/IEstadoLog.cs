using Dominio.Utilidades;
using Dominio.Modelo;

namespace Logica.Interfaces
{
    public interface IEstadoLog
    {
        Task<Respuesta<IReadOnlyList<Estado>>> GetEstado();
    }
}
