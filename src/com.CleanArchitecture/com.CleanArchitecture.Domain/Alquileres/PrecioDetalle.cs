using com.CleanArchitecture.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.CleanArchitecture.Domain.Alquileres
{
    public record PrecioDetalle(
        Moneda PrecioPorPeriodo,
        Moneda Mantenimiento,
        Moneda Accesorios,
        Moneda PrecioTotal)
    {

    }
}
