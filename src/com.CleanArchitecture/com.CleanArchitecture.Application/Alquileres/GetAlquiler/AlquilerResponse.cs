using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.CleanArchitecture.Application.Alquileres.GetAlquiler
{
    public sealed class AlquilerResponse
    {
        public Guid Id { get; init; }
        public Guid UserId { get; init; }
        public Guid VehiculoId { get; init; }
        public int Status { get; init; }
        public decimal PrecioAlquiler { get; init; }
        public string? TipoMonedaAlquiler { get; init; }
        public decimal PrecioMantenimiento { get; init; }
        public string? TipoMonedaMantenimiento { get; init; }
        public decimal AccesoriosPrecio { get; init; }
        public string? TipoMonedaAccesorios { get; init; }
        public decimal PrecioTotal { get; init; }
        public string? TipoMonedaPrecioTotal { get; init; }
        public DateOnly FechaInicio { get; init; }
        public DateOnly FechaFin { get; init; }
        public DateTime FechaCreacion { get; init; }
    }
}
