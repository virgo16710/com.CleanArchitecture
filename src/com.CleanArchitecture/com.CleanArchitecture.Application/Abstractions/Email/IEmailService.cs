namespace com.CleanArchitecture.Application.Abstractions.Email
{
    public interface IEmailService
    {
        Task SendAsync(
            Domain.Users.Email recipent,
            string subject,
            string body
            );
    }
}
