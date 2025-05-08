using com.CleanArchitecture.Domain.Abstractions;
using MediatR;

namespace com.CleanArchitecture.Application.Abstractions.Messaging
{
    public interface IQuery<TResponse> : IRequest<Result<TResponse>> 
    {
    }
}
