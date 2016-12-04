using System.Collections.Generic;
using MailProgram.App.Entities.Files;
using MimeKit;

namespace MailProgram.App.Entities.Mails
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