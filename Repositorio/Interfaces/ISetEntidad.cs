namespace Repositorio.Interfaces
{
    public interface ISetEntidad<T>
    {
        Task SetEntidadAsync(T entidad);
    }
}
