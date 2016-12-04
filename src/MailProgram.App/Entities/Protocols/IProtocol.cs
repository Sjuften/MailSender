using MailProgram.App.Entities.Mails;

namespace MailProgram.App.Entities.Protocols
{
    public interface IProtocol
    {
        void Send(IMail mail);
    }
}