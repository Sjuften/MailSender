using MailProgram.Entities.Mails;

namespace MailProgram.Services
{
    public interface IMailService
    {
        void Send(IMail mail);
    }
}