using mail.app.Entities.Mails;
using mail.app.Entities.Protocols;
using mail.app.Entities.ServerSettings;
using mail.app.Entities.UserAuthentications;
using mail.app.Services.Extensions;
using MimeKit;

namespace mail.app.Services
{

    public class MimeService : IMailService
    {
        private readonly IProtocol _client;

        public MimeMessage MimeMessage;
        public BodyBuilder Builder;

        public MimeService(IServerSetting settings, IUserAuthentication user)
        {
            MimeMessage = new MimeMessage();
            Builder = new BodyBuilder();

            _client = new Smtp(settings, user, MimeMessage);
        }

        public void Send(IMail mail)
        {
            this.AddMessage(mail.Message)
                .AddSubject(mail.Subject)
                .AddSender(mail.Sender)
                .AddRecievers(mail.Recievers)
                .AttachFiles(mail.Files)
                .Build()
                .Send(_client);
        }
    }
}