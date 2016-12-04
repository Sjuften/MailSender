﻿using mail.app.Entities.Mails;
using mail.app.Entities.Protocols.Extensions;
using mail.app.Entities.ServerSettings;
using mail.app.Entities.UserAuthentications;
using MailKit.Net.Smtp;
using MimeKit;

namespace mail.app.Entities.Protocols
{
    public class Smtp : IProtocol
    {
        private readonly SmtpClient _client;
        private readonly IServerSetting _server;
        private readonly IUserAuthentication _user;
        private readonly MimeMessage _mimeMessage;
        private BodyBuilder _builder;

        public Smtp(IServerSetting settings, IUserAuthentication user)
        {
            _client = new SmtpClient();
            _mimeMessage = new MimeMessage();
            _builder = new BodyBuilder();

            _server = settings;
            _user = user;
        }

        public void Send(IMail mail)
        {
            _mimeMessage.Create(mail, _builder).AttachFile(mail.File, _builder).Build(_builder);
            Connect();
            Authenticate();
            Send();
            Disconnect();
            Dispose();
        }

        private void Send() => _client.Send(_mimeMessage);
        private void Connect() => _client.Connect(_server.Url, _server.Port);
        private void Disconnect() => _client.Disconnect(true);
        private void Authenticate() => _client.Authenticate(_user.Username, _user.Password);
        private void Dispose() => _client.Dispose();
    }
}