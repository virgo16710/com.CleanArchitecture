using com.CleanArchitecture.Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.CleanArchitecture.Application.Vehiculos.SearchVehiculos
{
    public sealed record SearchVehiculoQuery(
        DateOnly fechaInicio,
        DateOnly fechaFin
        ):IQuery<IReadOnlyList<VehiculoResponse>>;
        
}
