using System;
using System.Collections.Generic;

namespace Mailer
{
    public class EmailService : IEmailService
    {
        private readonly IEmailConfiguration _emailConfiguration;
    
        public EmailService(IEmailConfiguration emailConfiguration)
        {
            _emailConfiguration = emailConfiguration;
        }
    
        public List<EmailMessage> ReceiveEmail(int maxCount = 10)
        {
            throw new NotImplementedException();
        }
    
        public void Send(EmailMessage emailMessage)
        {
            throw new NotImplementedException();
        }
    }
}
