using com.CleanArchitecture.Application.Abstractions.Data;
using com.CleanArchitecture.Application.Abstractions.Messaging;
using com.CleanArchitecture.Domain.Abstractions;
using Dapper;

namespace com.CleanArchitecture.Application.Alquileres.GetAlquiler
{
    internal sealed class GetAlquilerQueryHandler : IQueryHandler<GetAlquilerQuery, AlquilerResponse>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public GetAlquilerQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<Result<AlquilerResponse>> Handle(GetAlquilerQuery request, CancellationToken cancellationToken)
        {
            using var connection = _sqlConnectionFactory.CreateConnection();
            var sql = """
            Select
                 id AS Id,
                 vehiculo_id AS VehiculoId,
                 user_id AS UserId,
                 status AS Status,
                 precio_por_periodo AS PrecioAlquiler,
                 precio_por_periodo_tipo_moneda AS TipoMonedaAlquiler,
                 precio_mantenimiento AS PrecioMantenimiento,
                 precio_mantenimiento_tipo_moneda AS TipoMonedaMantenimiento,
                 accesorios_precio AS AccesoriosPrecio,
                 accesorios_precio_tipo_moneda AS TipoMonedaAccesorios,
                 precio_total AS PrecioTotal,
                 precio_total_tipo_moneda AS TipoMonedaPrecioTotal,
                 duracion_inicio AS FechaInicio,
                 duracion_fin AS FechaFin,
                 fecha_creacion AS FechaCreacion
            FROM alquileres Where id=@AlquilerId
            """;
            var alquiler = await connection.QueryFirstOrDefaultAsync<AlquilerResponse>(
                sql,
                new { request.AlquilerId }
                );
            return alquiler!;
        }

        
    }
}
