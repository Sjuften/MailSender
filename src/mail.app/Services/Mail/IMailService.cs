using mail.app.Models.Entities.Mails;

namespace mail.app.Services.Mail
{
    public interface IMailService
    {
        void Send(IMail mail);
    }
}