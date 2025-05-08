using com.CleanArchitecture.Application.Abstractions.Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.CleanArchitecture.Infrastructure.Email
{
    internal sealed class EmailService : IEmailService
    {
        public Task SendAsync(Domain.Users.Email recipent, string subject, string body)
        {
            return Task.CompletedTask;
        }
    }
}
