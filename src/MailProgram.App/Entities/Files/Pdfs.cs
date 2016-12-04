using MailProgram.App.Entities.Files.Enums;

namespace MailProgram.App.Entities.Files
{
    public class Pdfs : IFile
    {
        public Format Format { get; set; }
        public string FilePath { get; set; }
    }
}