using mail.app.Entities.Mails;

namespace mail.app.Services.Mail
{
    public interface IMailService
    {
        void Send(IMail mail);
    }
}