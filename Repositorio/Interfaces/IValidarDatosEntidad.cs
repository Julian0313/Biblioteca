namespace Repositorio.Interfaces
{
    public interface IValidarDatosEntidad<T>
    {
        Task<T> ValidarEntidadAsync(T entidad);
    }
}
