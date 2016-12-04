using MailProgram.App.Entities.Mails;

namespace MailProgram.App.Services
{
    public interface IMailService
    {
        void Send(IMail mail);
    }
}