﻿using mail.app.Models.Mails;
using mail.app.Models.ServerSettings;
using mail.app.Models.UserAuthentications;
using mail.app.Services.Protocols;
using MimeKit;

namespace mail.app.Services.Mail.MimeService
{
    public class MimeService : IMailService
    {
        private readonly IProtocol _client;

        private MimeMessage _mimeMessage;
        private BodyBuilder _builder;

        public MimeService(IServerSetting settings, IUserAuthentication user)
        {
            _mimeMessage = new MimeMessage();
            _client = new Smtp(settings, user, _mimeMessage);
        }

        public void Send(IMail mail)
        {
            _mimeMessage = DefaultMessage(mail).AttachFiles(mail.Files);
            _mimeMessage.Send(_client);
        }

        public MimeMessage DefaultMessage(IMail mail)
        {
            return _mimeMessage.AddMessage(mail.Message)
                .AddSubject(mail.Subject)
                .AddSender(mail.Sender)
                .AddRecievers(mail.Recievers);
        }
    }
}