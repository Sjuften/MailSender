using mail.app.Entities.Mails;

namespace mail.app.Services
{
    public interface IMailService
    {
        void Send(IMail mail);
    }
}