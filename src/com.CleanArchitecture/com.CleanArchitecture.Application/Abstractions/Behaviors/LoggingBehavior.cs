using com.CleanArchitecture.Application.Abstractions.Messaging;
using MediatR;
using Microsoft.Extensions.Logging;

namespace com.CleanArchitecture.Application.Abstractions.Behaviors
{
    public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
        where TResponse : IBaseCommand
    {
        private readonly ILogger<TRequest> _logger;
        public LoggingBehavior(ILogger<TRequest> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(
            TRequest request, 
            RequestHandlerDelegate<TResponse> next, 
            CancellationToken cancellationToken)
        {
            var name = request.GetType().Name;
            try 
            {
                _logger.LogInformation($"Ejecutando el command request: {name}");
                var response = await next();
                _logger.LogInformation($"Command request {name} ejecutado correctamente");
                var result = await next();
                _logger.LogInformation($"Comando {name} ejecutado correctamente");
                return result;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, $"Error ejecutando el comando: {name}");
                throw;
            }
        }
    }
}
