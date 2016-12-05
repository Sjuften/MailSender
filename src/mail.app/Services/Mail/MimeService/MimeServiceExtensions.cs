using System.Collections.Generic;
using mail.app.Entities.Files;
using mail.app.Entities.Protocols;
using MimeKit;

namespace mail.app.Services.Mail.MimeService
{
    public static class MimeServiceExtensions
    {
        public static MimeMessage AttachFiles(this MimeMessage message, IEnumerable<IFile> files, BodyBuilder builder)
        {
            builder = new BodyBuilder();
            //With attachfiles, i need to overwrite the text body - so i have attach the message to it
            OverrideMimeBodyMessage(builder, message.TextBody);
            foreach (var file in files)
            {
                builder.Attachments.Add(file.FilePath);
            }
            //Apppend it
            message.Body = builder.ToMessageBody();
            return message;
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