namespace Repositorio.Interfaces
{
    public interface IDelEntidad
    {
        Task<bool> DelEntidadAsync(int id);
    }
}
