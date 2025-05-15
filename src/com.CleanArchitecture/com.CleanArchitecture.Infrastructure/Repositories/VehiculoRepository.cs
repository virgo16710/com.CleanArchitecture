using com.CleanArchitecture.Domain.Vehiculos;

namespace com.CleanArchitecture.Infrastructure.Repositories
{
    internal sealed class VehiculoRepository:Repository<Vehiculo, VehiculoId>, IVehiculoRepository
    {
        public VehiculoRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
