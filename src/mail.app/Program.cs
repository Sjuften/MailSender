using System.Collections.Generic;
using System.IO;
using mail.app.Entities.Files;
using mail.app.Entities.Files.Enums;
using mail.app.Entities.Mails;
using mail.app.Entities.Protocols;
using mail.app.Entities.ServerSettings;
using mail.app.Entities.UserAuthentications;
using mail.app.Services;
using MimeKit;

namespace mail.app
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "cv.pdf");
            var user = new UserAuthentication() {Username = "", Password = ""};
            var settings = new ServerSetting() {Url = "smtp.gmail.com", Port = 587};
            var smtp = new Smtp(settings, user);
            var service = new MimeService(smtp);
            var mail = new Mail()
            {
                Message = "I ligner et meget spændnede firma, derfor vil jeg lige smide en uopfordret ansøgning",
                Recievers = new List<MailboxAddress>()
                {
                    new MailboxAddress("")
                },
                Sender = new MailboxAddress(""),
                Subject = "Uopfordret ansøgning",
                File = new Pdfs()
                {
                    FilePath = filePath,
                    Format = Format.Pdf,
                }
            };
            service.Send(mail);
        }
    }
}
