using com.CleanArchitecture.Application.Vehiculos.SearchVehiculos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace com.CleanArchitecture.Api.Controllers.Vehiculos
{
    [ApiController]
    [Route("api/vehiculos")]
    public class VehiculoControllers : ControllerBase
    {
        private readonly ISender _sender;

        public VehiculoControllers(ISender sender)
        {
            _sender = sender;
        }
        [HttpGet]
        public async Task<IActionResult> BuscarVehiculos
            (
            DateOnly Inicio,
            DateOnly Fin,
            CancellationToken cancellationToken
            )
        {
            var query = new SearchVehiculoQuery(Inicio, Fin);
            var resultados = await _sender.Send(query, cancellationToken);
            return Ok(resultados.Value);
        }

    }
}
