using mail.app.Entities.Mails;
using mail.app.Entities.Protocols;
using mail.app.Entities.ServerSettings;
using mail.app.Entities.UserAuthentications;
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
            _mimeMessage = DefaultMessage(mail).AttachFiles(mail.Files, _builder);
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