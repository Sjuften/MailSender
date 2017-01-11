using System.Collections.Generic;
using System.IO;
using mail.app.Models.Files;
using mail.app.Models.Mails;

namespace mail.app
{
    public static class Dummy
    {
        private static string Image { get; } = Path.Combine(Directory.GetCurrentDirectory(), "Attachments/portrait.jpg");
        private static string Cv { get; } = Path.Combine(Directory.GetCurrentDirectory(), "Attachments/cv.pdf");
        private static IEnumerable<string> Recievers { get; } = File.ReadAllLines("emails.txt");

        public static IMail Mail()
        {
            return new Mail()
            {
                Message = "XXX",
                Recievers = Recievers,
                Sender = "XXX",
                Subject = "XXX",
                Files = new List<IFile>()
                {
                    new PngFile()
                    {
                        FilePath = Image
                    },
                    new PdfFile()
                    {
                        FilePath = Cv
                    }
                }
            };
        }
    }
}
