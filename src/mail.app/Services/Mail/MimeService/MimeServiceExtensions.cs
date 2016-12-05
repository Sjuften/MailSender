using System.Collections.Generic;
using System.IO;
using System.Linq;
using mail.app.Models.Entities.Files;
using mail.app.Models.Entities.Protocols;
using MimeKit;

namespace mail.app.Services.Mail.MimeService
{
    public static class MimeServiceExtensions
    {
        public static MimeMessage AttachFiles(this MimeMessage message, IEnumerable<IFile> files, BodyBuilder builder)
        {
            var multipart = new Multipart("mixed")
            {
                new TextPart("plain") {Text = message.TextBody},
            };
            foreach (var file in files)
            {
                var attachment = Create(file);

                multipart.Add(attachment);
            }

            message.Body = multipart;
            return message;
        }

        private static MimePart Create(IFile file)
        {
            return new MimePart("", "")
            {
                ContentObject =
                    new ContentObject(File.OpenRead(file.FilePath), ContentEncoding.Default),
                ContentDisposition = new ContentDisposition(ContentDisposition.Attachment),
                FileName = Path.GetFileName(file.FilePath)
            };
        }

        public static MimeMessage AddSender(this MimeMessage message, string sender)
        {
            message.From.Add(new MailboxAddress(sender));
            return message;
        }

        public static MimeMessage AddRecievers(this MimeMessage message, IEnumerable<string> recievers)
        {
            foreach (var reciever in recievers)
            {
                message.To.Add(new MailboxAddress(reciever));
            }
            return message;
        }

        public static MimeMessage AddSubject(this MimeMessage message, string subject)
        {
            message.Subject = subject;
            return message;
        }

        public static MimeMessage AddMessage(this MimeMessage message, string mailMessage)
        {
            message.Body = new TextPart("plain") {Text = mailMessage};
            return message;
        }

        public static void Send(this MimeMessage message, IProtocol protocol)
        {
            protocol.Send();
        }

        private static void OverrideMimeBodyMessage(BodyBuilder builder, string message)
        {
            builder.TextBody = message;
        }
    }
}