namespace com.CleanArchitecture.Api.Controllers.Alquileres
{
    public sealed record AlquilerReservaRequest(
        Guid VehiculoId,
        Guid UserId,
        DateOnly Inicio,
        DateOnly Fin);
}
