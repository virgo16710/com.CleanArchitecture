using com.CleanArchitecture.Domain.Vehiculos;

namespace com.CleanArchitecture.Infrastructure.Repositories
{
    internal sealed class VehiculoRepository:Repository<Vehiculo>, IVehiculoRepository
    {
        public VehiculoRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
