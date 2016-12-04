using MailProgram.App.Entities.Files.Enums;

namespace MailProgram.App.Entities.Files
{
    public interface IFile
    {
        //TEST
        Format Format { get; set; }
        string FilePath { get; set; }

    }
}