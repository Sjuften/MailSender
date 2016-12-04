using MailProgram.Entities.Files.Enums;

namespace MailProgram.Entities.Files
{
    public class Pdfs : IFile
    {
        public Format Format { get; set; }
        public string FilePath { get; set; }
    }
}