namespace Repositorio.Interfaces
{
    public interface IGetEntidadById<T>
    {
        Task<T> GetEntidadByIdAsync(int id);
    }
}
