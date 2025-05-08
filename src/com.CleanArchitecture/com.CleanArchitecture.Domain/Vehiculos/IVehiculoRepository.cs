using com.CleanArchitecture.Domain.Vehiculos;

namespace com.CleanArchitecture.Domain.Vehiculos
{
    public interface IVehiculoRepository
    {
        Task<Vehiculo?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
