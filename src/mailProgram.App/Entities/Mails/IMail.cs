using System.Collections.Generic;
using MailProgram.Entities.Files;
using MimeKit;

namespace MailProgram.Entities.Mails
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