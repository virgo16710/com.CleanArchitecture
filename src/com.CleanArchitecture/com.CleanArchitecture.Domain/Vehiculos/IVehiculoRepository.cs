using com.CleanArchitecture.Domain.Vehiculos;

namespace com.CleanArchitecture.Domain.Vehiculos
{
    public interface IVehiculoRepository
    {
        Task<Vehiculo?> GetByIdAsync(VehiculoId id, CancellationToken cancellationToken = default);
    }
}
