using com.CleanArchitecture.Application.Abstractions.Data;
using com.CleanArchitecture.Application.Abstractions.Messaging;
using com.CleanArchitecture.Domain.Abstractions;
using com.CleanArchitecture.Domain.Alquileres;
using Dapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace com.CleanArchitecture.Application.Vehiculos.SearchVehiculos
{
    internal sealed class SearchVehiculoHandler : IQueryHandler<SearchVehiculoQuery, IReadOnlyList<VehiculoResponse>>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;
        private static readonly int[] ActiveAlquilerStatuses =
        {
            (int)AlquilerStatus.Reservado,
            (int)AlquilerStatus.Confirmado,
            (int)AlquilerStatus.Completado,
        };

        public SearchVehiculoHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<Result<IReadOnlyList<VehiculoResponse>>> Handle(SearchVehiculoQuery request, CancellationToken cancellationToken)
        {
            if (request.fechaInicio > request.fechaFin)
                return new List<VehiculoResponse>();
            using var connection = _sqlConnectionFactory.CreateConnection();
            const string sql = """
               SELECT
                a.id as Id,
                a.modelo as Modelo,
                a.vin as Vin,
                a.precio_monto as Precio,
                a.precio_tipo_moneda as TipoMoneda,
                a.direccion_pais as Pais,
                a.direccion_departamento as Departamento,
                a.direccion_provincia as Provincia,
                a.direccion_ciudad as Ciudad,
                a.direccion_calle as Calle
             FROM vehiculos AS a
             WHERE NOT EXISTS
             (
                    SELECT 1 
                    FROM alquileres AS b
                    WHERE 
                        b.vehiculo_id = a.id  AND
                        b.duracion_start <= @EndDate AND
                        b.duracion_end  >= @StartDate AND
                        b.status = ANY(@ActiveAlquilerStatuses)
             )      
        """;





            var vehiculos = await connection.
                QueryAsync<VehiculoResponse,DireccionResponse,VehiculoResponse>(
                sql,
                (vehiculo, direccion) =>
                {
                    vehiculo.Direccion = direccion;
                    return vehiculo;
                },
                new
                {
                    StartDate = request.fechaInicio,
                    EndDate = request.fechaFin,
                    ActiveAlquilerStatuses
                } ,
                splitOn: "Pais"
            );
            return vehiculos.ToList();
        }
    }
}
