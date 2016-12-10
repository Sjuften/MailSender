using System.Collections.Generic;
using System.IO;
using mail.app.Models.Files;
using MimeKit;

namespace mail.app.Services.Mail.MimeService
{
    public static class MultipartExtensions
    {
        public static Multipart MultiPartCreate()
        {
            return new Multipart();
        }

        public static Multipart AddTextPart(this Multipart part, string message)
        {
            part.Add(new TextPart("plain") {Text = message});
            return part;
        }

        public static Multipart AttachFiles(this Multipart part, IEnumerable<IFile> files)
        {
            foreach (var file in files){ part.Add(Create(file));}
            return part;
        }

        private static MimePart Create(IFile file)
        {
            return new MimePart("", "")
            {
                ContentObject =
                    new ContentObject(File.OpenRead(file.FilePath)),
                ContentDisposition = new ContentDisposition(ContentDisposition.Attachment),
                FileName = Path.GetFileName(file.FilePath)
            };
        }
    }
}