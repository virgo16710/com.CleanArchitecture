using com.CleanArchitecture.Domain.Abstractions;

namespace com.CleanArchitecture.Domain.Users.Events
{
    public sealed record UserCreateDomainEvent(UserId UserId) : IDomainEvent;
   
}
