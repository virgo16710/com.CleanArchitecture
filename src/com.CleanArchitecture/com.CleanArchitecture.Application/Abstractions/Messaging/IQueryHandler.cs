using com.CleanArchitecture.Domain.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.CleanArchitecture.Application.Abstractions.Messaging
{
    public interface IQueryHandler<Iquery,TResponse> : 
        IRequestHandler<Iquery, Result<TResponse>> where Iquery : 
        IQuery<TResponse>
    {
    }
}
