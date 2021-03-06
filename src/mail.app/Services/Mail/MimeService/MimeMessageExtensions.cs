﻿using System.Collections.Generic;
using mail.app.Models.Files;
using mail.app.Services.Protocols;
using MimeKit;

namespace mail.app.Services.Mail.MimeService
{
    public static class MimeMessageExtensions
    {
        public static MimeMessage AttachFiles(this MimeMessage message, IEnumerable<IFile> files)
        {
            message.Body = MultipartExtensions.MultiPartCreate()
                .AddTextPart(message.TextBody)
                .AttachFiles(files);
            return message;
        }


        public static MimeMessage AddSender(this MimeMessage message, string sender)
        {
            message.From.Add(new MailboxAddress(sender));
            return message;
        }

        public static MimeMessage AddRecievers(this MimeMessage message, IEnumerable<string> recievers)
        {
            foreach (var reciever in recievers){message.To.Add(new MailboxAddress(reciever));}
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
    }
}
