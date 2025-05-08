using com.CleanArchitecture.Application.Alquileres.GetAlquiler;
using com.CleanArchitecture.Application.Alquileres.ReservarAlquiler;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace com.CleanArchitecture.Api.Controllers.Alquileres
{
    [ApiController]
    [Route("api/alquileres")]
    public class AlquileresControllers : ControllerBase
    {
        private readonly ISender _sender;
        public AlquileresControllers(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAlquiler(Guid id, CancellationToken cancellationToken)
        {
            var query = new GetAlquilerQuery(id);
            var result = await _sender.Send(query, cancellationToken);
            return result.IsSuccess ? Ok(result.Value) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> ReservarAlquiler(
            Guid id,
            AlquilerReservaRequest request,
            CancellationToken cancellationToken
            )
        {
            var command = new ReservarAlquilerCommand
                (
                request.VehiculoId,
                request.UserId,
                request.Inicio,
                request.Fin
                );
            var resultado = await _sender.Send(command, cancellationToken);
            if (resultado.IsFailure)
            {
                return BadRequest(resultado.Error);
            }
            return CreatedAtAction(nameof(GetAlquiler), new {id = resultado.Value}, resultado.Value);
        }
    }
}
