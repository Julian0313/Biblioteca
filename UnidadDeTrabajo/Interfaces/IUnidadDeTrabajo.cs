using Dominio.Modelo;
using Dominio.Utilidades;
using Repositorio.Interfaces;

namespace UnidadDeTrabajo.Interfaces
{
    public interface IUnidadDeTrabajo : IDisposable
    {
        IGetEntidad<T> IGetEntidad<T>() where T : class;

        IGetEntidadPag<Autor> AutorRepoPag { get; }
        IGetEntidadPag<LibroRtn> LibroRepoPag { get; }

        IValidarDatosEntidad<Autor> ValidarAutor { get; }
        IValidarDatosEntidad<Libro> ValidarLibro { get; }

        IGetEntidadById<Autor> ValidarAutorById { get; }
        IGetEntidadById<Libro> ValidarLibroById { get; }

        IInsEntidad<Autor> AutorRepoIns { get; }
        IInsEntidad<Libro> LibroRepoIns { get; }

        ISetEntidad<Autor> AutorRepoSet { get; }
        ISetEntidad<Libro> LibroRepoSet { get; }

        IDelEntidad DelAutor { get; }
        IDelEntidad DelLibro { get; }

        Task GuardarCambiosAsync();
    }
}
