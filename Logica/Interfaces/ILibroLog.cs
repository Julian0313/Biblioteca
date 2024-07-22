using Dominio.Dto;
using Dominio.Utilidades;

namespace Logica.Interfaces
{
    public interface ILibroLog
    {
        Task<Respuesta<Paginacion<LibroRtn>>> GetLibro(ParametrosPag parametros);
        Task<Respuesta<LibroRtn>> GetLibroById(int id);
        Task<Respuesta<string>> InsLibroLog(LibroDto libro);
        Task<Respuesta<string>> SetLibroLog(LibroDto libro); 
        Task<Respuesta<string>> DelLibro(int id);
    }
}
