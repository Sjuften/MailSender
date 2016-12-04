using System.Collections.Generic;
using mail.app.Entities.Files;
using MimeKit;

namespace mail.app.Entities.Mails
{
    public class Mail : IMail
    {
        public string Message { get; set; }
        public string Subject { get; set; }

        public IFile File { get; set; }
        public List<MailboxAddress> Recievers { get; set; }
        public MailboxAddress Sender { get; set; }
    }
}