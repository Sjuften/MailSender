using mail.app.Mails;

namespace mail.app.Services.Mail
{
    public interface IMailService
    {
        void Send(IMail mail);
    }
}