using System.Collections.Generic;

namespace Mailer
{
    public interface IEmailService
    {
        void Send(EmailMessage emailMessage);
    }
}
