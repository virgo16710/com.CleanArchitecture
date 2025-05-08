using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.CleanArchitecture.Domain.Alquileres
{
    public enum AlquilerStatus
    {
        Reservado = 1,
        Confirmado = 2,
        Rechazado = 3,
        Cancelado = 4,
        Completado = 5
    }
}
