using com.CleanArchitecture.Domain.Abstractions;
using MediatR;

namespace com.CleanArchitecture.Application.Abstractions.Messaging
{
    public interface ICommand : IRequest<Result>, IBaseCommand
    {
    }
    public interface ICommand<TResponse> : IRequest<Result<TResponse>>, IBaseCommand
    {
    }
    public interface IBaseCommand 
    {

    }
}
