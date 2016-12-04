using MailProgram.Entities.Files.Enums;

namespace MailProgram.Entities.Files
{
    public interface IFile
    {
        Format Format { get; set; }
        string FilePath { get; set; }

    }
}