using System.Collections.Generic;
using System.IO;
using mail.app.Entities.Files;
using mail.app.Entities.Files.Enums;
using mail.app.Entities.Mails;
using mail.app.Entities.ServerSettings;
using mail.app.Entities.UserAuthentications;
using mail.app.Services;
using Microsoft.Extensions.Configuration;

namespace mail.app
{
    public class Program
    {
        public static IConfiguration Configuration()
            =>
            new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

        public static void Main(string[] args)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "cv.pdf");
            var user = new UserAuthentication();
            var settings = new ServerSetting();
            var service = new MimeService(settings, user);
            var mail = new Mail()
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
                        FilePath = filePath,
                        Format = Format.Pdf
                    }
                }
            };
            service.Send(mail);
        }
    }
}