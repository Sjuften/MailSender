using System.Collections.Generic;
using mail.app.Entities.Files;
using MimeKit;

namespace mail.app.Entities.Mails
{
    public class Mail : IMail
    {
        public string Message { get; set; }
        public string Subject { get; set; }

        public IEnumerable<IFile> Files { get; set; }
        public IEnumerable<string> Recievers { get; set; }
        public string Sender { get; set; }
    }
}