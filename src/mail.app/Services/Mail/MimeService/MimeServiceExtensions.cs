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
        public static MimeMessage AttachFiles(this MimeMessage message, IEnumerable<IFile> files)
        {
            return MultiPartCreate().
                AddTextPart(message.TextBody).
                AttachFiles(files).
                Build(message);
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

        private static Multipart MultiPartCreate()
        {
            return new Multipart();
        }

        private static MimeMessage Build(this Multipart part, MimeMessage message)
        {
            message.Body = part;
            return message;
        }

        private static Multipart AddTextPart(this Multipart part, string message)
        {
            part.Add(new TextPart("plain") {Text = message});
            return part;
        }

        private static Multipart AttachFiles(this Multipart part, IEnumerable<IFile> files)
        {
            foreach (var file in files)
            {
                var attachment = Create(file);
                part.Add(attachment);
            }
            return part;
        }

        private static MimePart Create(IFile file)
        {
            return new MimePart("", "")
            {
                ContentObject =
                    new ContentObject(File.OpenRead(file.FilePath)),
                ContentDisposition = new ContentDisposition(ContentDisposition.Attachment),
                FileName = Path.GetFileName(file.FilePath)
            };
        }
    }
}