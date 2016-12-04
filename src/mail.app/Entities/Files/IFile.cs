using mail.app.Entities.Files.Enums;

namespace mail.app.Entities.Files
{
    public interface IFile
    {
        Format Format { get; set; }
        string FilePath { get; set; }

    }
}