using System.Collections.Generic;
using mail.app.Entities.Files;
using mail.app.Entities.Protocols;
using MimeKit;

namespace mail.app.Services.Extensions
{
    public static class MimeServiceExtensions
    {
        public static MimeService AttachFiles(this MimeService service, IEnumerable<IFile> files)
        {
            foreach (var file in files)
            {
                service.Builder.Attachments.Add(file.FilePath);
            }
            return service;
        }

        public static MimeService AddSender(this MimeService service, string sender)
        {
            service.MimeMessage.From.Add(new MailboxAddress(sender));
            return service;
        }

        public static MimeService AddRecievers(this MimeService service, IEnumerable<string> recievers)
        {
            foreach (var reciever in recievers)
            {
                service.MimeMessage.To.Add(new MailboxAddress(reciever));
            }
            return service;
        }

        public static MimeService AddSubject(this MimeService service, string subject)
        {
            service.MimeMessage.Subject = subject;
            return service;
        }

        public static MimeService AddMessage(this MimeService service, string mailMessage)
        {
            service.Builder.TextBody = mailMessage;
            return service;
        }

        public static MimeMessage Build(this MimeService service)
        {
            service.MimeMessage.Body = service.Builder.ToMessageBody();
            return service.MimeMessage;
        }

        public static void Send(this MimeMessage message, IProtocol protocol)
        {
            protocol.Send();
        }
    }
}