using com.CleanArchitecture.Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.CleanArchitecture.Application.Alquileres.GetAlquiler
{
    public sealed record GetAlquilerQuery(Guid AlquilerId) : IQuery<AlquilerResponse>;
}
