using System.Collections.Generic;
using mail.app.Models.Entities.Files;

namespace mail.app.Models.Entities.Mails
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