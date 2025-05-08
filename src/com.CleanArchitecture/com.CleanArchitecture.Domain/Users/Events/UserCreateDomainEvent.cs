using com.CleanArchitecture.Domain.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.CleanArchitecture.Domain.Users.Events
{
    public sealed record UserCreateDomainEvent(Guid UserId) : IDomainEvent;
   
}
