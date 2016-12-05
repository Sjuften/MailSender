using System.Collections.Generic;
using mail.app.Entities.Files;

namespace mail.app.Entities.Mails
{
    public interface IMail
    {
        string Message { get; set; }
        string Subject { get; set; }

        IEnumerable<IFile> Files { get; set; }
        IEnumerable<string> Recievers { get; set; }
        string Sender { get; set; }
    }
}