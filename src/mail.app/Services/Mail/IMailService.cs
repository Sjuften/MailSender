using mail.app.Models.Mails;

namespace mail.app.Services.Mail
{
    public interface IMailService
    {
        void Send(IMail mail);
    }
}