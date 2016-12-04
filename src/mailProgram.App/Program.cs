using System.Collections.Generic;
using System.IO;
using MailProgram.Entities.Files;
using MailProgram.Entities.Files.Enums;
using MailProgram.Entities.Mails;
using MailProgram.Entities.Protocols;
using MailProgram.Entities.ServerSettings;
using MailProgram.Entities.UserAuthentications;
using MailProgram.Services;
using MimeKit;

namespace MailProgram
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "cv.pdf");
            var user = new UserAuthentication() {Username = "martinbergpetersen", Password = "martinbp88"};
            var settings = new ServerSetting() {Url = "smtp.gmail.com", Port = 587};
            var smtp = new Smtp(settings, user);
            var service = new MimeService(smtp);
            var mail = new Mail()
            {
                Message = "I ligner et meget spændnede firma, derfor vil jeg lige smide en uopfordret ansøgning",
                Recievers = new List<MailboxAddress>()
                {
                    new MailboxAddress("bergpetersen@outlook.com")
                },
                Sender = new MailboxAddress("Martinbergpetersen@gmail.com"),
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