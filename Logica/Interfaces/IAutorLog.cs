using Dominio.Utilidades;
using Dominio.Modelo;

namespace Logica.Interfaces
{
    public interface IAutorLog
    {
        Task<Respuesta<Paginacion<Autor>>> GetAutorLog(ParametrosPag parametros);
        Task<Respuesta<string>> InsAutorLog(Autor autor);
        Task<Respuesta<string>> SetAutorLog(Autor autor);
        Task<Respuesta<string>> DelAutor(int id);
    }
}
