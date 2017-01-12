using System.Collections.Generic;
using System.IO;
using System.Linq;
using mail.app.Models.Files;
using mail.app.Models.Mails;

namespace mail.app
{
    public static class Dummy
    {
        private static string Image { get; } = Path.Combine(Directory.GetCurrentDirectory(), "Attachments/portrait.jpg");
        private static string Cv { get; } = Path.Combine(Directory.GetCurrentDirectory(), "Attachments/cv.pdf");
        private static IEnumerable<string> Recievers { get; } = File.ReadAllLines("emails.txt").Select(x=> x.Trim());

        public static IMail Mail()
        {
            return new Mail()
            {
                Message = "Da jeg fandt jeres profil yderst interessant, ville jeg lige smide en uopfordret ansøgning." +
                          "" +
                          "" +
                          " Håber at høre fra jer." +
                          " Mvh Martin Berg Petersen",
                Recievers = Recievers,
                Sender = "Martin Berg Petersen",
                Subject = "Uopfordret ansøgning",
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
