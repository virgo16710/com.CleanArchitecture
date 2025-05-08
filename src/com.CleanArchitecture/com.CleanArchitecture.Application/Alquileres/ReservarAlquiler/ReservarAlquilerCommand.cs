
using com.CleanArchitecture.Application.Abstractions.Messaging;

namespace com.CleanArchitecture.Application.Alquileres.ReservarAlquiler
{
    public record ReservarAlquilerCommand(
        Guid VehiculoId,
        Guid UserId,
        DateOnly Start,
        DateOnly End
        ) : ICommand<Guid>
    {
    }
}
