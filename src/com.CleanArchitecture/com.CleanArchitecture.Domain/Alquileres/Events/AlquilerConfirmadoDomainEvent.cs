using com.CleanArchitecture.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.CleanArchitecture.Domain.Alquileres.Events
{
    public sealed record AlquilerConfirmadoDomainEvent(Guid AlquilerId) : IDomainEvent;
}
