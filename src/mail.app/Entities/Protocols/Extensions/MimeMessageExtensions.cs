using mail.app.Entities.Files;
using mail.app.Entities.Mails;
using MimeKit;

namespace mail.app.Entities.Protocols.Extensions
{
    public static class MimeMessageExtensions
    {
        public static MimeMessage AttachFile(this MimeMessage message, IFile file, BodyBuilder builder)
        {
            builder.Attachments.Add(file.FilePath);
            return message;
        }

        public static MimeMessage Create(this MimeMessage message, IMail mail, BodyBuilder builder)
        {
            message.From.Add(mail.Sender);
            message.To.AddRange(mail.Recievers);
            message.Subject = mail.Subject;
            builder.TextBody = mail.Message;
            return message;
        }

        public static MimeMessage Build(this MimeMessage message, BodyBuilder builder)
        {
            message.Body = builder.ToMessageBody();
            return message;
        }
    }
}