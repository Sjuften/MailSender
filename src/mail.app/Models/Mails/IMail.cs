using System.Collections.Generic;
using mail.app.Files;

namespace mail.app.Mails
{
    public interface IMail
    {
        string Message { get; set; }
        string Subject { get; set; }
        string Sender { get; set; }

        IEnumerable<IFile> Files { get; set; }
        IEnumerable<string> Recievers { get; set; }
    }
}