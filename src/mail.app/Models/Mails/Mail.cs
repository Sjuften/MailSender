﻿using System.Collections.Generic;
using mail.app.Models.Files;

namespace mail.app.Models.Mails
{
    public class Mail : IMail
    {
        public string Message { get; set; }
        public string Subject { get; set; }
        public string Sender { get; set; }

        public IEnumerable<IFile> Files { get; set; } = new List<IFile>();
        public IEnumerable<string> Recievers { get; set; } = new List<string>();
    }
}