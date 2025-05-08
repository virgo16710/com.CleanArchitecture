using com.CleanArchitecture.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.CleanArchitecture.Domain.Alquileres
{
    public static class AlquilerErrors
    {
        public static Error NotFound = new Error(
            "Alquiler.Found",
            "El alquiler con el Id Especificado no existe");
        public static Error Overlap = new Error(
            "Alquiler.Overlap",
            "El Alquiler esta siendo tomado por 2 o mas clientes al mismo tiempo en la misma fecha");
        public static Error NotReserved = new Error(
            "Alquiler.NotReserved",
            "El Alquiler no esta reservado");
        public static Error NotConfirmed = new Error(
            "Alquiler.NotConfirmed",
            "El Alquiler no esta confirmado");
        public static Error AlreadyStarted = new Error(
            "Alquiler.AlreadyStarted",
            "El Alquiler ya ha comenzado");
    }
}
