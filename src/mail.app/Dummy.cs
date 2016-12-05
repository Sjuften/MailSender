using System.Collections.Generic;
using System.IO;
using mail.app.Models.Entities.Files;
using mail.app.Models.Entities.Mails;

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
                Message = "I ser spændende ud, derfor har jeg lavet denne uopfordret ansøgning",
                Recievers = Recievers,
                Sender = "Martin Berg Petersen",
                Subject = "Uopfordret ansøgning",
                Files = new List<IFile>()
                {
                    new Png()
                    {
                        FilePath = Image
                    },
                    new Pdf()
                    {
                        FilePath = Cv
                    }
                }
            };
        }
    }
}