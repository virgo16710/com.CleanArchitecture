using com.CleanArchitecture.Domain.Vehiculos;

namespace com.CleanArchitecture.Domain.Alquileres
{
    public interface IAlquilerRepository
    {
        Task<Alquiler?> GetByIdAsync(Guid id,CancellationToken cancellationToken=default);
        Task<bool> IsOverlappingAsync(Vehiculo vehiculos, DateRange duracion, CancellationToken cancellationToken = default);
        void Add(Alquiler alquiler);
    }
}
