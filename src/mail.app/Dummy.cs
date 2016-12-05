using System;
using System.Collections.Generic;
using System.IO;
using mail.app.Entities.Files;
using mail.app.Entities.Mails;

namespace mail.app
{
    public static class Dummy
    {
        private static string FilePath { get; } = Path.Combine(Directory.GetCurrentDirectory(), "cv.pdf");

        public static IMail Mail()
        {
            return new Mail()
            {
                Message = "I ligner et meget spændnede firma, derfor vil jeg lige smide en uopfordret ansøgning",
                Recievers = new List<string>()
                {
                    "bergpetersen@outlook.com"
                },
                Sender = "Martin Berg Petersen",
                Subject = "Uopfordret ansøgning",
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