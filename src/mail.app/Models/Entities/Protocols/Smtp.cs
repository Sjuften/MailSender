using mail.app.Models.Entities.ServerSettings;
using mail.app.Models.Entities.UserAuthentications;
using MailKit.Net.Smtp;
using MimeKit;

namespace mail.app.Models.Entities.Protocols
{
    public class Smtp : IProtocol
    {
        private readonly SmtpClient _client;
        private readonly IServerSetting _server;
        private readonly IUserAuthentication _user;
        private readonly MimeMessage _mimeMessage;

        public Smtp(IServerSetting settings, IUserAuthentication user, MimeMessage mimeMessage)
        {
            _client = new SmtpClient();

            _mimeMessage = mimeMessage;
            _server = settings;
            _user = user;
        }

        public void Send()
        {

            Connect();
            Authenticate();
            _client.Send(_mimeMessage);
            Disconnect();
            Dispose();
        }

        private void Send(int test) => _client.Send(_mimeMessage);
        private void Connect() => _client.Connect(_server.Url, _server.Port);
        private void Disconnect() => _client.Disconnect(true);
        private void Authenticate() => _client.Authenticate(_user.Username, _user.Password);
        private void Dispose() => _client.Dispose();
    }
}