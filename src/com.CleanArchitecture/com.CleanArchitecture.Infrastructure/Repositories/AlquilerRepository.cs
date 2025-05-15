using com.CleanArchitecture.Domain.Alquileres;
using com.CleanArchitecture.Domain.Vehiculos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.CleanArchitecture.Infrastructure.Repositories
{
    internal sealed class AlquilerRepository: Repository<Domain.Alquileres.Alquiler, AlquilerId>, IAlquilerRepository
    {
        private static readonly AlquilerStatus[] ActiveAlquilerStatuses =
        {
            AlquilerStatus.Reservado,
            AlquilerStatus.Confirmado,
            AlquilerStatus.Completado
        };
        public AlquilerRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<bool> IsOverlappingAsync(
            Vehiculo vehiculos, 
            DateRange duracion, 
            CancellationToken cancellationToken = default)
        {
            return await DbContext.Set<Alquiler>()
                .AnyAsync(alquiler =>
                alquiler.VehiculoId == vehiculos.Id &&
                alquiler.Duracion!.Start <= duracion.End &&
                alquiler.Duracion.End >= duracion.Start &&
                ActiveAlquilerStatuses.Contains(alquiler.Status),
                cancellationToken);
        }
    }
}
