using MailProgram.Entities.Mails;

namespace MailProgram.Entities.Protocols
{
    public interface IProtocol
    {
        void Send(IMail mail);
    }
}