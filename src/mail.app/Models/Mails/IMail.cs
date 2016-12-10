using System.Collections.Generic;
using mail.app.Models.Files;

namespace mail.app.Models.Mails
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