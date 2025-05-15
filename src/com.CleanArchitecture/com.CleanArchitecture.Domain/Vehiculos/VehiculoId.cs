using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.CleanArchitecture.Domain.Vehiculos
{
    public record VehiculoId(Guid Value)
    {
        public static VehiculoId New() => new (Guid.NewGuid());
    }
}
