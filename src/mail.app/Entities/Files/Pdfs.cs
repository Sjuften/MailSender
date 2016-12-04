using mail.app.Entities.Files.Enums;

namespace mail.app.Entities.Files
{
    public class Pdfs : IFile
    {
        public Format Format { get; set; }
        public string FilePath { get; set; }
    }
}