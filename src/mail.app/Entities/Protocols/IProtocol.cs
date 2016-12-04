using mail.app.Entities.Mails;

namespace mail.app.Entities.Protocols
{
    public interface IProtocol
    {
        void Send(IMail mail);
    }
}