using System.Collections.Generic;
using System.IO;
using mail.app.Models.Entities.Files;
using mail.app.Models.Entities.Mails;

namespace mail.app
{
    public static class Dummy
    {
        private static string FilePath { get; } = Path.Combine(Directory.GetCurrentDirectory(), "cv.pdf");

        public static IMail Mail()
        {
            return new Mail()
            {
                Message = "Resume",
                Recievers = new List<string>()
                {
                    "example@example.dk"
                },
                Sender = "John Smith",
                Subject = "Resume",
                Files = new List<IFile>()
                {
                    new Pdfs()
                    {
                        FilePath = FilePath
                    }
                }
            };
        }
    }
}