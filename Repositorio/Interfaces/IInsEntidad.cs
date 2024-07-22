namespace Repositorio.Interfaces
{
    public interface IInsEntidad<T>
    {
        Task InsEntidadAsync(T entidad);
    }
}
