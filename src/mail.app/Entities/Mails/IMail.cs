using System.Collections.Generic;
using mail.app.Entities.Files;
using MimeKit;

namespace mail.app.Entities.Mails
{
    public interface IMail
    {
        string Message { get; set; }
        string Subject { get; set; }

        IFile File { get; set; }
        List<MailboxAddress> Recievers { get; set; }
        MailboxAddress Sender { get; set; }
    }
}