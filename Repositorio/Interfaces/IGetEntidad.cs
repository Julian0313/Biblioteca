namespace Repositorio.Interfaces
{
    public interface IGetEntidad<T>
    {
        Task<IReadOnlyList<T>> IGetEntidadAsync();
    }
}
