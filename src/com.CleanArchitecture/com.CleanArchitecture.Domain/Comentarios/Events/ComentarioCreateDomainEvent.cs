using com.CleanArchitecture.Domain.Abstractions;

namespace com.CleanArchitecture.Domain.Comentarios.Events
{
    public record ComentarioCreateDomainEvent(Guid ComentarioId) : IDomainEvent;
}
